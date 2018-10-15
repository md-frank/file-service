// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-01-23
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Server.Models.Output;
using Mondol.FileService.Service.Models.Output;
using Mondol.Security.Cryptography.Utils;
using Mondol.Net.Http;

namespace Mondol.FileService.Server
{
    /// <summary>
    /// 文件服务器管理接口
    /// </summary>
    class FileServiceManager : IFileServiceManager
    {
        private readonly IOptionsMonitor<FileServiceOption> _option;
        private readonly IOwnerTokenCodec _ownerTokenCodec;
        private readonly IHttpClientFactory _httpClientFac;
        private readonly string _fsApiHost;

        public FileServiceManager(IOptionsMonitor<FileServiceOption> option, IOwnerTokenCodec ownerTokenCodec, IHttpClientFactory httpClientFac)
        {
            _option = option;
            _ownerTokenCodec = ownerTokenCodec;

            _httpClientFac = httpClientFac;

            _fsApiHost = "http://" + _option.CurrentValue.Host;
        }

        public string GenerateOwnerTokenString(int ownerType, int ownerId, TimeSpan validTime)
        {
            if (validTime.TotalSeconds < 1)
                throw new ArgumentOutOfRangeException(nameof(validTime));

            var oToken = new OwnerToken
            {
                OwnerType = ownerType,
                OwnerId = ownerId,
                ExpireTime = DateTime.Now.Add(validTime)
            };
            return _ownerTokenCodec.Encode(oToken);
        }

        /// <summary>
        /// 验证文件信息
        /// </summary>
        public bool VerifyFileInfo(IEnumerable<KeyValuePair<string, object>> values, string sign)
        {
            var vals = values.Where(p => "Sign".Equals(p.Key, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Key).Select(p => p.Value);
            var appSecret = _option.CurrentValue.AppSecret;
            var signOriStr = $"{appSecret}|{string.Join("|", vals)}";
            return HashUtil.Sha1(signOriStr).Equals(sign, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 设置指定用户的配额信息
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="max">最大配额数（字节）</param>
        public async Task<Result> SetOwnerQuotaAsync(int ownerType, int ownerId, ulong max)
        {
            using (var hc = _httpClientFac.CreateClient())
            {
                var reqDat = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("max", max.ToString())
                });
                var url = $"{_fsApiHost}/sapi/ownersQuota/{ownerType}/{ownerId}";

                var jResult = await hc.GetJObjectAsync(HttpMethod.Post, url, reqDat);
                return new Result(jResult.Value<int>("errCode"), jResult.Value<string>("errMsg"));
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="periodMinute">链接有效期（分钟）,0则不过期</param>
        public async Task<DataResult<UploadResultData>> UploadAsync(int ownerType, int ownerId, string filePath, int periodMinute = 0)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var fileName = Path.GetFileName(filePath);
                return await UploadAsync(ownerType, ownerId, fs, fileName, null, periodMinute);
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="file">文件路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="hash">小写hex sha1值。如果为空并且file.CanSeek则自动计算sha1值</param>
        /// <param name="periodMinute">链接有效期（分钟）,0则不过期</param>
        public async Task<DataResult<UploadResultData>> UploadAsync(int ownerType, int ownerId, Stream file, string fileName, string hash = null, int periodMinute = 0)
        {
            using (var httpClient = _httpClientFac.CreateClient())
            {
                if (string.IsNullOrEmpty(hash) && file.CanSeek)
                {
                    hash = HashUtil.Sha1(file);
                    file.Seek(0, SeekOrigin.Begin);
                }

                var url = _fsApiHost + "/sapi/files";
                DataResult<UploadResultData> result = null;
                if (!string.IsNullOrEmpty(hash))
                {
                    var mfdc = new MultipartFormDataContent();
                    mfdc.AddByString("ownerType", ownerType.ToString());
                    mfdc.AddByString("ownerId", ownerId.ToString());
                    mfdc.AddByString("fileName", fileName);
                    mfdc.AddByString("hash", hash);
                    mfdc.AddByString("periodMinute", periodMinute.ToString());

                    result = await httpClient.GetResultAsync<DataResult<UploadResultData>>(HttpMethod.Post, url, mfdc);
                }

                if (result == null || result.ErrorCode == 100)
                {
                    var mfdc = new MultipartFormDataContent();
                    mfdc.AddByString("ownerType", ownerType.ToString());
                    mfdc.AddByString("ownerId", ownerId.ToString());
                    mfdc.AddByString("fileName", fileName);
                    mfdc.AddByString("periodMinute", periodMinute.ToString());

                    //StreamContent会自动释放Stream
                    var sc = new StreamContent(file);
                    sc.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    mfdc.Add(sc, "file", fileName);
                    result = await httpClient.GetResultAsync<DataResult<UploadResultData>>(HttpMethod.Post, url, mfdc);
                }

                return result;
            }
        }

        /// <summary>
        /// 从远程拉取文件并存储
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="fileUrl">文件下载地址</param>
        /// <param name="fileName">文件名</param>
        /// <param name="periodMinute">链接有效期（分钟）,0则不过期</param>
        public async Task<DataResult<UploadResultData>> UploadByRemoteAsync(int ownerType, int ownerId, string fileUrl, string fileName, int periodMinute = 0)
        {
            using (var hc = _httpClientFac.CreateClient())
            {
                var reqDat = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("ownerType", ownerType.ToString()),
                    new KeyValuePair<string, string>("ownerId", ownerId.ToString()),
                    new KeyValuePair<string, string>("fileUrl", fileUrl),
                    new KeyValuePair<string, string>("fileName", fileName),
                    new KeyValuePair<string, string>("periodMinute", periodMinute.ToString())
                });
                var url = _fsApiHost + "/sapi/files/fromRemote";
                return await hc.GetResultAsync<DataResult<UploadResultData>>(HttpMethod.Post, url, reqDat);
            }
        }

        /// <summary>
        /// 获取指定文件的信息
        /// </summary>
        /// <param name="fileToken">fileToken</param>
        public async Task<DataResult<FileDetailData>> GetFileInfoAsync(string fileToken)
        {
            using (var hc = _httpClientFac.CreateClient())
            {
                var url = $"{_fsApiHost}/sapi/files/{fileToken}/info";
                return await hc.GetResultAsync<DataResult<FileDetailData>>(HttpMethod.Get, url);
            }
        }

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="fileToken">fileToken</param>
        public async Task<Result> DeleteFileAsync(string fileToken)
        {
            using (var hc = _httpClientFac.CreateClient())
            {
                var url = $"{_fsApiHost}/sapi/files/{fileToken}";
                return await hc.GetResultAsync<Result>(HttpMethod.Delete, url);
            }
        }
    }
}