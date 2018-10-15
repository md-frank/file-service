using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mondol.FileService.Db;
using Mondol.FileService.Db.Entities;
using Mondol.FileService.Service;
using Mondol.FileService.Service.Models;
using Mondol.IO.Utils;
using File = Mondol.FileService.Db.Entities.File;
using Microsoft.Extensions.Logging;
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;


using Mondol.FileService.Db.Repositories;
using Mondol.FileService.Models.Result;

namespace Mondol.FileService.Service
{
    public class FileUploadService
    {
        private readonly ILogger<FileUploadService> _logger;

        private readonly IStorageService _storageSvce;
        private readonly ClusterService _clusterSvce;
        private readonly IFileTokenCodec _fileTokenCodec;
        private readonly IOwnerTokenCodec _ownerTokenCodec;
        private readonly IMimeProvider _mimeProvider;
        private readonly IRepositoryAccessor _dataAccessor;
        private readonly AppSecretSigner _appSecretSigner;
        private readonly IHttpContextAccessor _httpCtxAccessor;

        public FileUploadService(IStorageService storageSvce, ClusterService clusterSvce, ILogger<FileUploadService> logger,
            IMimeProvider mimeProvider, IRepositoryAccessor dataAccessor, AppSecretSigner appSecretSigner, IFileTokenCodec fileTokenCodec, IOwnerTokenCodec ownerTokenCodec, IHttpContextAccessor httpCtxAccessor)
        {
            _storageSvce = storageSvce;
            _clusterSvce = clusterSvce;
            _logger = logger;
            _mimeProvider = mimeProvider;
            _dataAccessor = dataAccessor;
            _appSecretSigner = appSecretSigner;
            _fileTokenCodec = fileTokenCodec;
            _ownerTokenCodec = ownerTokenCodec;
            _httpCtxAccessor = httpCtxAccessor;
        }

        public async Task<DataResult<UploadResultData>> UploadAsync(string ownerToken, IFormFile file, string fileName, string hash, int periodMinute)
        {
            using (var stream = file?.OpenReadStream())
            {
                return await UploadAsync(ownerToken, stream, fileName, hash, periodMinute);
            }
        }

        public Task<DataResult<UploadResultData>> UploadAsync(string ownerToken, Stream file, string fileName,
            string hash, int periodMinute)
        {
            if (!DecodeAndCheckOwnerToken(ownerToken, out var oToken, out DataResult<UploadResultData> result))
                return Task.FromResult(result);

            var foti = new FileOwnerTypeId
            {
                OwnerType = oToken.OwnerType,
                OwnerId = oToken.OwnerId
            };
            return UploadAsync(foti, file, fileName, hash, periodMinute);
        }

        public async Task<DataResult<UploadResultData>> UploadAsync(FileOwnerTypeId foti, IFormFile file, string fileName, string hash, int periodMinute)
        {
            using (var stream = file?.OpenReadStream())
            {
                return await UploadAsync(foti, stream, fileName, hash, periodMinute);
            }
        }

        public async Task<DataResult<UploadResultData>> UploadAsync(FileOwnerTypeId foti, Stream file, string fileName, string hash, int periodMinute)
        {
            try
            {
                var fileInfo = await _storageSvce.CreateFileAsync(foti, hash, file, fileName, periodMinute);
                var etAddMinute = periodMinute > 0 ? periodMinute : 52560000; //最大100年
                var fToken = new FileToken
                {
                    PseudoId = fileInfo.PseudoId,
                    FileId = fileInfo.File.Id,
                    FileOwnerId = fileInfo.Owner.Id,
                    MimeId = (uint)fileInfo.File.MimeId,
                    FileCreateTime = fileInfo.File.CreateTime,
                    ExpireTime = DateTime.Now.AddMinutes(etAddMinute)
                };
                var fTokenStr = _fileTokenCodec.Encode(fToken);

                var urDat = new UploadResultData
                {
                    FileToken = fTokenStr,
                    Url = $"{GetCurrentScheme()}://{fileInfo.Server.Host}/files/{fTokenStr}",
                    Name = fileInfo.Owner.Name,
                    Length = fileInfo.File.Length
                };
                var signLst = new[]
                {
                    new KeyValuePair<string, object>(nameof(UploadResultData.FileToken), urDat.FileToken),
                    new KeyValuePair<string, object>(nameof(UploadResultData.Url), urDat.Url),
                    new KeyValuePair<string, object>(nameof(UploadResultData.Name), urDat.Name),
                    new KeyValuePair<string, object>(nameof(UploadResultData.Length), urDat.Length)
                };
                urDat.Sign = _appSecretSigner.Sign(signLst);

                return new DataResult<UploadResultData>(ResultErrorCodes.Success)
                {
                    Data = urDat
                };
            }
            catch (FileNotFoundException)
            {
                return new DataResult<UploadResultData>(100, "文件不存在，请直接上传");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new DataResult<UploadResultData>(ResultErrorCodes.SystemError, ex.Message);
            }
        }

        private bool DecodeAndCheckOwnerToken<TData>(string ownerTokenStr, out OwnerToken oToken, out DataResult<TData> errorResult) where TData : class
        {
            oToken = null;
            errorResult = null;
            if (string.IsNullOrEmpty(ownerTokenStr) || !TryDecode(_ownerTokenCodec, ownerTokenStr, out oToken))
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

        public bool TryDecode(IOwnerTokenCodec codec, string tokenStr, out OwnerToken token)
        {
            try
            {
                token = codec.Decode(tokenStr);
                return true;
            }
            catch (Exception ex)
            {
                token = null;
                _logger.LogTrace(ex.ToString());
                return false;
            }
        }

        private string GetCurrentScheme()
        {
            return _httpCtxAccessor.HttpContext?.Request.GetRealScheme() ?? "http";
        }
    }
}
