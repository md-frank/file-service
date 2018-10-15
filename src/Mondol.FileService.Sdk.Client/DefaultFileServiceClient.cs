using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mondol.FileService.Models;
using Newtonsoft.Json.Linq;
using Mondol.Security.Cryptography.Utils;
using Newtonsoft.Json;

namespace Mondol.FileService.Client
{
    public class DefaultFileServiceClient : IFileServiceClient, IDisposable
    {
        private readonly IApiChannel _apiChannel;

        public DefaultFileServiceClient(FileServiceOption opts)
        {
            _apiChannel = new DefaultApiChannel(opts.Host);
        }

        public void Dispose()
        {
            _apiChannel.Dispose();
        }

        public IWebProxy Proxy
        {
            get => _apiChannel.Proxy;
            set => _apiChannel.Proxy = value;
        }

        public async Task<DataResult<FileUploadDataResult>> UploadAsync(string ownerToken, Stream fileStream, string fileName, int periodMinute = 0)
        {
            JObject jResult = null;
            var needHash = fileStream.CanSeek;
            if (needHash)
            {
                var hash = HashUtil.Sha1(fileStream);
                var reqDat = new MultipartFormDataContent
                {
                    {new StringContent(ownerToken), "ownerToken"},
                    {new StringContent(fileName), "fileName"},
                    {new StringContent(hash), "hash"},
                    {new StringContent(periodMinute.ToString()), "periodMinute"}
                };
                jResult = await _apiChannel.GetJObjectAsync(HttpMethod.Post, "/files", reqDat);
            }

            if (jResult == null || jResult.Value<int>("errCode") == 100)
            {
                if (needHash)
                    fileStream.Seek(0, SeekOrigin.Begin);

                var reqDat = new MultipartFormDataContent
                {
                    {new StringContent(ownerToken), "ownerToken"},
                    {new StringContent(fileName), "fileName"},
                    {new StringContent(periodMinute.ToString()), "periodMinute"},
                    {new StreamContent(fileStream), "file", fileName}
                };

                jResult = await _apiChannel.GetJObjectAsync(HttpMethod.Post, "/files", reqDat);
            }

            FileUploadDataResult rData = null;
            var jData = jResult["data"];
            if (jData != null && jData.Type == JTokenType.Object)
                rData = new FileUploadDataResult
                {
                    FileToken = jData.Value<string>("fileToken"),
                    Length = jData.Value<long>("length"),
                    Name = jData.Value<string>("name"),
                    Sign = jData.Value<string>("sign"),
                    Url = jData.Value<string>("url")
                };

            return new DataResult<FileUploadDataResult>
            {
                ErrorCode = jResult.Value<int>("errCode"),
                ErrorMsg = jResult.Value<string>("errMsg"),
                Data = rData
            };
        }

        public async Task<DataResult<FileUploadDataResult>> UploadByRemoteAsync(string ownerToken, string fileUrl, string fileName, int periodMinute = 0)
        {
            var hc = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("fileName", fileName),
                new KeyValuePair<string,string>("fileUrl", fileUrl),
                new KeyValuePair<string,string>("periodMinute", periodMinute.ToString()),
                new KeyValuePair<string,string>("ownerToken", ownerToken)
            });
            var url = "/files/fromRemote";
            var jResult = await _apiChannel.GetJObjectAsync(HttpMethod.Post, url, hc);

            FileUploadDataResult rData = null;
            var jData = jResult["data"];
            if (jData != null && jData.Type == JTokenType.Object)
                rData = new FileUploadDataResult
                {
                    FileToken = jData.Value<string>("fileToken"),
                    Length = jData.Value<long>("length"),
                    Name = jData.Value<string>("name"),
                    Sign = jData.Value<string>("sign"),
                    Url = jData.Value<string>("url")
                };

            return new DataResult<FileUploadDataResult>
            {
                ErrorCode = jResult.Value<int>("errCode"),
                ErrorMsg = jResult.Value<string>("errMsg"),
                Data = rData
            };
        }

        public async Task<Result> DeleteAsync(string fileToken, string ownerToken)
        {
            var url = $"/files/{fileToken}?ownerToken={ownerToken}";
            var jResult = await _apiChannel.GetJObjectAsync(HttpMethod.Delete, url);
            return new DataResult<FileUploadDataResult>
            {
                ErrorCode = jResult.Value<int>("errCode"),
                ErrorMsg = jResult.Value<string>("errMsg")
            };
        }
    }
}
