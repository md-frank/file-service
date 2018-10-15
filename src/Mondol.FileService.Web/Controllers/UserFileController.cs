// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;
using Mondol.Security.Cryptography.Utils;
using Mondol.FileService.Db;
using Mondol.FileService.Db.Entities;
using Mondol.FileService.Db.Repositories;
using Mondol.FileService.Filters;
using Mondol.FileService.Models.Result;
using Mondol.FileService.Options;
using Mondol.FileService.Service;
using Mondol.FileService.Service.Models;
using Mondol.FileService.Web.Models.Input.User;
using Mondol.IO.Utils;
using File = Mondol.FileService.Db.Entities.File;

namespace Mondol.FileService.Controllers
{
    /// <summary>
    /// 文件操作相关接口
    /// </summary>
    [Route("~/files")]
    [EnableCors("AllowAny")]
    public class UserFileController : ControllerBase
    {
        private readonly IStorageService _storageSvce;
        private readonly ClusterService _clusterSvce;
        private readonly IFileRepository _fileData;
        private readonly IOwnerRepository _ownerData;
        private readonly IFileTokenCodec _fileTokenCodec;
        private readonly IOwnerTokenCodec _ownerTokenCodec;
        private readonly FileUploadService _fileUpdSvce;
        private readonly FileHandlerManager _fileHandlerMgr;
        private readonly IMimeProvider _mimeProvider;
        private readonly AppSecretSigner _appSecretSigner;

        public UserFileController(IStorageService storageSvce, ClusterService clusterSvce, IFileRepository fileData,
            IOwnerRepository ownerData, IFileTokenCodec fileTokenCodec, IOwnerTokenCodec ownerTokenCodec, FileUploadService fileUpdSvce,
            ImageSizeProvider img, FileHandlerManager fileHandlerMgr, IMimeProvider mimeProvider, AppSecretSigner appSecretSigner)
        {
            _storageSvce = storageSvce;
            _clusterSvce = clusterSvce;
            _fileData = fileData;
            _ownerData = ownerData;
            _fileTokenCodec = fileTokenCodec;
            _ownerTokenCodec = ownerTokenCodec;
            _fileUpdSvce = fileUpdSvce;
            _fileHandlerMgr = fileHandlerMgr;
            _mimeProvider = mimeProvider;
            _appSecretSigner = appSecretSigner;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <remarks>
        /// ### 上传步骤：
        /// 1. 在真正上传文件前先计算文件SHA1值
        /// 2. 调用本接口只传hash参数，不传file参数
        /// 3. 如果本文件之前有人传过则接口返回成功(errCode=0)
        ///    1. 跳过后续步骤
        /// 4. 如果本文件之前没人传过，则errCode=100
        ///    1. 再次调用本接口，传file参数，不传hash参数（传也会忽略）
        /// </remarks>
        [HttpPost]
        public Task<DataResult<UploadResultData>> UploadAsync(UploadFileInput model)
        {
            /*
             * 传文件流的时候可以不指定FileName，从文件流中读取，指定了优先级更高
             * 传Hash的时候必需指定文件名
             */
            var fileName = model.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
                fileName = model.File?.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
                return Task.FromResult(new DataResult<UploadResultData>(ResultErrorCodes.Failure, "文件名不能为空"));

            return _fileUpdSvce.UploadAsync(model.OwnerToken, model.File, fileName, model.Hash, model.PeriodMinute);
        }

        /// <summary>
        /// 上传文件（从远程拉取）
        /// </summary>
        [HttpPost("fromRemote")]
        public async Task<DataResult<UploadResultData>> UploadByRemoteAsync(UploadFileByRemoteInput input)
        {
            var httpFac = RequestService.GetRequiredService<IHttpClientFactory>();
            using (var hc = httpFac.CreateClient())
            {
                using (var fs = await hc.GetStreamAsync(input.FileUrl))
                {
                    return await _fileUpdSvce.UploadAsync(input.OwnerToken, fs, input.FileName, null, input.PeriodMinute);
                }
            }
        }

        /// <summary>
        /// 获取文件处理器列表
        /// </summary>
        [HttpGet("handlers")]
        public DataResult<ListData<string>> GetHandlers()
        {
            return new DataResult<ListData<string>>(ResultErrorCodes.Success)
            {
                Data = new ListData<string>
                {
                    List = _fileHandlerMgr.GetHandlersName()
                }
            };
        }

        /// <summary>
        /// 获取指定文件处理器支持的转换修饰符信息
        /// </summary>
        /// <remarks>
        /// 不同处理器返回结构不同。
        /// 花括号（{xxx}）包围的表示必选参数，方括号（[xxx]）包围的表示可选参数
        /// </remarks>
        [HttpGet("handlers/{name}")]
        [ProducesResponseType(typeof(DataResult<RawModifierDescribe>), 200)]
        [ProducesResponseType(typeof(DataResult<ImageModifierDescribe>), 201)]
        public Result GetHandler([Required] string name)
        {
            var fileHandler = _fileHandlerMgr.GetFileHandlerByName(name);
            if (fileHandler == null)
                return new Result(ResultErrorCodes.ArgumentBad, name + " 不存在");

            return new DataResult<object>(ResultErrorCodes.Success)
            {
                Data = fileHandler.ModifierDescribe
            };
        }

        /// <summary>
        /// 下载文件（不指定转换修饰符）
        /// </summary>
        /// <param name="fileToken"><seealso cref="DownloadAsync(string, string, string)"/></param>
        /// <param name="handler"><seealso cref="DownloadAsync(string, string, string)"/></param>
        [HttpGet("{fileToken}/{handler}")]
        public Task<IActionResult> DownloadAsync([Required] string fileToken, [Required] string handler)
        {
            return DownloadAsync(fileToken, handler, null);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileToken">上传接口返回的文件访问令牌</param>
        /// <param name="handler">文件转换处理器名字</param>
        /// <param name="modifier">文件转换修饰符，定义参见对应文件处理器的描述</param>
        /// <remarks>
        /// ### 图片转换实现：
        /// 1. 假设fileToken=8o2YcHjzP-LYDNRdePMrxwE01WcbAAAAAQAAAAHhmsFjiPWwMe-XlA8.，对应的原文件为600x800的一张jpg图片        
        /// 2. 您可以用文件根地址+sizes+formats拼接URL地址以实现转换的目的  
        /// 3. 如果您想请求128x128，png格式的的图片可拼接为：http://file.mondol.info/files/8o2YcHjzP-LYDNRdePMrxwE01WcbAAAAAQAAAAHhmsFjiPWwMe-XlA8./128x128_png
        /// </remarks>
        [HttpGet("{fileToken}/{handler}/{modifier}")]
        public async Task<IActionResult> DownloadAsync([Required] string fileToken, [Required] string handler, string modifier)
        {
            if (!DecodeAndCheckFileToken(fileToken, out FileToken fToken, out DataResult<object> errResult))
                return StatusCode(401, errResult.ErrorMsg);

            var rawPath = _storageSvce.GetRawFilePath(fToken.PseudoId, fToken.FileCreateTime, fToken.FileId);
            if (System.IO.File.Exists(rawPath))
            {
                //如果原文件存在，并且包含缓存头则认为是未修改
                //因为文件只会删除，不会修改
                var reqHeaders = Request.GetTypedHeaders();
                if (reqHeaders.IfNoneMatch?.Any() == true)
                {
                    return StatusCode(304);
                }
            }
            else
            {
                return NotFound("您访问的文件不存在或已被删除啦");
            }

            try
            {
                var fileHandler = _fileHandlerMgr.GetFileHandlerByName(handler);
                if (fileHandler == null)
                    return StatusCode(400, handler + " 不存在");

                //返回文件
                var rawMime = _mimeProvider.GetMimeById(fToken.MimeId);
                var hCtx = new FileHandleContext()
                {
                    SourcePath = rawPath,
                    SourceMime = rawMime,
                    Modifier = modifier,
                    FileToken = fToken
                };
                var result = await fileHandler.HandleAsync(hCtx);

                //添加缓存头
                var rspHeaders = Response.GetTypedHeaders();
                rspHeaders.ETag = new EntityTagHeaderValue($"\"{fToken.PseudoId}\"", true);
                rspHeaders.CacheControl = new CacheControlHeaderValue() { MaxAge = TimeSpan.FromDays(365) };
                rspHeaders.Expires = DateTime.UtcNow.AddYears(1);

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(nameof(DownloadAsync), ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="fileToken">上传接口返回的文件访问令牌</param>
        /// <param name="ownerToken">文件所有者令牌</param>
        [HttpDelete("{fileToken}")]
        public async Task<Result> DeleteAsync([Required] string fileToken, [Required] string ownerToken)
        {
            if (!DecodeAndCheckFileToken(fileToken, out FileToken fToken, out DataResult<object> errResult))
                return errResult;
            if (!DecodeAndCheckOwnerToken(ownerToken, out OwnerToken oToken, out errResult))
                return errResult;

            var fOwner = await _fileData.GetFileOwnerByIdAsync(fToken.FileOwnerId, fToken.PseudoId);
            if (fOwner == null)
                return new Result(ResultErrorCodes.Failure, "记录不存在或已被删除");
            if (fOwner.OwnerId != oToken.OwnerId || fOwner.OwnerType != oToken.OwnerType)
                return new Result(ResultErrorCodes.Unauthorized, "您不是此文件的拥有者");

            var fileInfo = await _fileData.GetFileByIdAsync(fToken.PseudoId, fToken.FileId);
            var remainRefCount = await _fileData.DeleteFileAsync(fOwner.Id, fToken.FileId, fToken.PseudoId);
            if (remainRefCount < 1)
            {
                //引用计数为0，物理删除
                var server = _clusterSvce.GetServerById(fileInfo.ServerId);
                await _clusterSvce.DeleteFileAsync(_storageSvce, fToken.PseudoId, fToken.FileCreateTime, fToken.FileId, server);
            }

            //删除已使用的配额
            await _ownerData.DecreaseOwnerUsedQuotaAsync(oToken.OwnerType, oToken.OwnerId, fileInfo.Length);

            return new Result(ResultErrorCodes.Success);
        }

        private bool DecodeAndCheckFileToken<TData>(string fileTokenStr, out FileToken fToken, out DataResult<TData> errorResult) where TData : class
        {
            errorResult = null;
            if (!_fileTokenCodec.TryDecode(fileTokenStr, out fToken))
            {
                errorResult = new DataResult<TData>(ResultErrorCodes.ArgumentBad, "bad fileToken");
                return false;
            }
            if (fToken.IsExpired)
            {
                errorResult = new DataResult<TData>(100, "fileToken expired");
                return false;
            }
            return true;
        }

        private bool DecodeAndCheckOwnerToken<TData>(string ownerTokenStr, out OwnerToken oToken, out DataResult<TData> errorResult) where TData : class
        {
            errorResult = null;
            if (!_ownerTokenCodec.TryDecode(ownerTokenStr, out oToken))
            {
                errorResult = new DataResult<TData>(ResultErrorCodes.ArgumentBad, "bad ownerToken");
                return false;
            }
            if (oToken.IsExpired)
            {
                errorResult = new DataResult<TData>(100, "ownerToken expired");
                return false;
            }
            return true;
        }
    }
}
