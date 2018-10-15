// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;

using Mondol.FileService.Db;
using Mondol.FileService.Db.Entities;
using Mondol.FileService.Db.Repositories;
using Mondol.FileService.Models.Result;
using Mondol.FileService.Options;
using Mondol.FileService.Service;
using Mondol.FileService.Service.Models;
using Mondol.FileService.Web.Models.Input.Server;
using Mondol.FileService.Web.Models.Output.Server;
using Microsoft.Extensions.DependencyInjection;
using Mondol.Net.Http;

namespace Mondol.FileService.Controllers
{
    /// <summary>
    /// 管理端接口
    /// </summary>
    /// <remarks>
    /// server api
    /// </remarks>
    [Route("~/sapi")]
    public class ServerApiController : BaseServerApiController
    {
        private readonly IOwnerRepository _ownerData;
        private readonly IOwnerTokenCodec _ownerTokenCodec;
        private readonly IFileTokenCodec _fileTokenCodec;
        private readonly IStorageService _storageSvce;
        private readonly IFileRepository _fileRepo;
        private readonly FileUploadService _fileUpdSvce;

        public ServerApiController(IOwnerRepository ownerData, IOwnerTokenCodec ownerTokenCodec, IOptionsMonitor<ManageOption> manageOption,
            IFileTokenCodec fileTokenCodec, IStorageService storageSvce, IFileRepository fileRepo, FileUploadService fileUpdSvce) : base(manageOption)
        {
            _ownerData = ownerData;
            _ownerTokenCodec = ownerTokenCodec;
            _fileTokenCodec = fileTokenCodec;
            _storageSvce = storageSvce;
            _fileRepo = fileRepo;
            _fileUpdSvce = fileUpdSvce;
        }

        /// <summary>
        /// 设置指定用户的配额信息
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="max">最大配额数（字节）</param>
        /// <remarks>
        /// 通常在注册用户时调用
        /// </remarks>
        [HttpPost("ownersQuota/{ownerType}/{ownerId}")]
        public async Task<Result> SetOwnerQuotaAsync(int ownerType, long ownerId, long max)
        {
            await _ownerData.SetOwnerMaxQuotaAsync(ownerType, ownerId, max);
            return new Result(ResultErrorCodes.Success);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        [HttpPost("files")]
        public Task<DataResult<UploadResultData>> UploadAsync(UploadFileInput input)
        {
            /*
             * 传文件流的时候可以不指定FileName，从文件流中读取，指定了优先级更高
             * 传Hash的时候必需指定文件名
             */
            var fileName = input.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
                fileName = input.File?.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
                return Task.FromResult(new DataResult<UploadResultData>(ResultErrorCodes.Failure, "文件名不能为空"));

            return _fileUpdSvce.UploadAsync(input, input.File, fileName, input.Hash, input.PeriodMinute);
        }

        /// <summary>
        /// 上传文件(从远程拉取)
        /// </summary>
        [HttpPost("files/fromRemote")]
        public async Task<DataResult<UploadResultData>> UploadByRemoteAsync(UploadFileByRemoteInput input)
        {
            var httpFac = RequestService.GetRequiredService<IHttpClientFactory>();
            using (var hc = httpFac.CreateClient())
            {
                using (var fs = await hc.GetStreamAsync(input.FileUrl))
                {
                    return await _fileUpdSvce.UploadAsync(input, fs, input.FileName, null, input.PeriodMinute);
                }
            }
        }

        /// <summary>
        /// 获取指定文件的信息
        /// </summary>
        [HttpGet("files/{fileToken}/info")]
        public async Task<DataResult<FileDetailData>> GetFileInfoAsync(string fileToken)
        {
            if (!_fileTokenCodec.TryDecode(fileToken, out var tokenInfo))
                return new DataResult<FileDetailData>(ResultErrorCodes.Failure, "bad token");

            var file = await _fileRepo.GetFileByOwnerIdAsync(tokenInfo.PseudoId, tokenInfo.FileOwnerId);

            return new DataResult<FileDetailData>(ResultErrorCodes.Success)
            {
                Data = new FileDetailData
                {
                    File = new FileData
                    {
                        CreateTime = file.CreateTime,
                        Hash = file.SHA1,
                        Length = file.Length,
                        MimeId = file.MimeId,
                        Name = file.FileOwner.Name,
                        ServerId = file.ServerId
                    },
                    Owner = new FileOwnerTypeId
                    {
                        OwnerId = file.FileOwner.OwnerId,
                        OwnerType = file.FileOwner.OwnerType
                    }
                }
            };
        }

        /// <summary>
        /// 删除指定用户文件
        /// </summary>
        [HttpDelete("files/{fileToken}")]
        public async Task<Result> DeleteFileByFileTokenAsync(string fileToken)
        {
            return new Result(ResultErrorCodes.Failure, "暂未实现");
        }

        /// <summary>
        /// 生成一个ownerToken
        /// </summary>
        /// <param name="ownerType"></param>
        /// <param name="ownerId"></param>
        /// <param name="periodDay">有效期（天）</param>
        /// <returns></returns>
        [HttpPost("ownerTokens")]
        [Obsolete("内部使用")]
        public DataResult<string> CreateOwnerToken(int ownerType, int ownerId, int periodDay)
        {
            var tokenStr = _ownerTokenCodec.Encode(new OwnerToken
            {
                OwnerType = ownerType,
                OwnerId = ownerId,
                ExpireTime = DateTime.Now.AddDays(periodDay)
            });
            return new DataResult<string>(ResultErrorCodes.Success)
            {
                Data = tokenStr
            };
        }

        /// <summary>
        /// GetOwnerTokenInfo
        /// </summary>
        [HttpGet("ownerTokens/{token}/info")]
        [Obsolete("内部使用")]
        public DataResult<OwnerToken> GetOwnerTokenInfo(string token)
        {
            if (!_ownerTokenCodec.TryDecode(token, out var tokenInfo))
                return new DataResult<OwnerToken>(ResultErrorCodes.Failure, "bad token");

            return new DataResult<OwnerToken>(ResultErrorCodes.Success)
            {
                Data = tokenInfo
            };
        }
    }
}