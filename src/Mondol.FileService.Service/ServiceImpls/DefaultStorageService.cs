// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mondol.FileService.Authorization;
using Mondol.FileService.Db.Entities;
using Mondol.FileService.Db.Options;
using Mondol.FileService.Db.Repositories;
using Mondol.FileService.Service.Models;
using Mondol.Security.Cryptography.Utils;
using Mondol.FileService.Service.Options;
using Mondol.IO.Utils;
using File = Mondol.FileService.Db.Entities.File;

namespace Mondol.FileService.Service
{
    /// <summary>
    /// 默认存储服务
    /// </summary>
    public class DefaultStorageService : IStorageService
    {
        private readonly ClusterService _clusterSvce;
        private readonly ILogger<DefaultStorageService> _logger;
        private readonly IOptionsMonitor<DbOption> _dbOption;
        private readonly IOptionsMonitor<GeneralOption> _option;
        private readonly IMimeProvider _mimeProvider;
        private readonly IRepositoryAccessor _repoAccessor;

        public DefaultStorageService(ClusterService clusterSvce,
            IOptionsMonitor<GeneralOption> option, IOptionsMonitor<DbOption> dbOption,
            ILogger<DefaultStorageService> logger, IMimeProvider mimeProvider, IRepositoryAccessor repoAccessor)
        {
            _clusterSvce = clusterSvce;
            _logger = logger;
            _mimeProvider = mimeProvider;
            _repoAccessor = repoAccessor;
            _dbOption = dbOption;
            _option = option;
        }

        /// <summary>
        /// 为指定用户创建文件
        /// </summary>
        public async Task<FileStorageInfo> CreateFileAsync(FileOwnerTypeId ownerTypeId, string hash, IFormFile file, string fileName, int periodMinute = 0)
        {
            using (var stream = file?.OpenReadStream())
            {
                return await CreateFileAsync(ownerTypeId, hash, stream, fileName, periodMinute);
            }
        }

        /// <summary>
        /// 为指定用户创建文件
        /// </summary>
        public async Task<FileStorageInfo> CreateFileAsync(FileOwnerTypeId ownerTypeId, string hash, Stream file, string fileName, int periodMinute = 0)
        {
            if (!_clusterSvce.CurrentServer.AllowUpload)
                throw new FriendlyException("请从上传服务器上传");

            string tmpFilePath = null;
            try
            {
                var extName = Path.GetExtension(fileName);
                if (string.IsNullOrEmpty(extName))
                    throw new FriendlyException("文件名缺少扩展名");
                extName = extName.Substring(1).ToLower();
                var mime = _mimeProvider.GetMimeByExtensionName(extName);

                //获取hash
                if (file != null)
                {
                    tmpFilePath = await ReceiveToTempFileAsync(file);
                    //优先使用文件的hash
                    hash = FileUtil.GetSha1(tmpFilePath);
                }
                if (string.IsNullOrWhiteSpace(hash))
                    throw new FriendlyException("file 与 hash 必需至少指定一个");

                Task tSync = null;
                var pseudoId = GeneratePseudoId(hash);
                var fileInfo = await FileRepo.GetFileByHashAsync(pseudoId, hash);
                //文件不存在，并且没有传file流
                if (fileInfo == null && tmpFilePath == null)
                    throw new FileNotFoundException("File does not exist");

                //检查所有者剩余配额
                var fileSize = fileInfo?.Length ?? new System.IO.FileInfo(tmpFilePath).Length;
                var remainQuota = await OwnerRepo.GetOwnerRemainQuotaAsync(ownerTypeId.OwnerType, ownerTypeId.OwnerId);
                if (remainQuota < fileSize)
                    throw new FriendlyException("您已经没有足够的空间上传该文件");

                Service.Options.Server recServer = null;
                //检查存在否
                if (fileInfo == null)
                {
                    //插入新文件记录
                    recServer = _clusterSvce.ElectServer();
                    fileInfo = new File
                    {
                        ServerId = recServer.Id,
                        Length = new System.IO.FileInfo(tmpFilePath).Length,
                        MimeId = (int)mime.Id,
                        SHA1 = hash,
                        ExtInfo = string.Empty,
                        CreateTime = DateTime.Now
                    };
                    await FileRepo.AddFileAsync(fileInfo, pseudoId);

                    tSync = _clusterSvce.SyncFileToServerAsync(this, tmpFilePath, fileInfo, pseudoId, recServer);
                }
                else
                {
                    recServer = _clusterSvce.GetServerById(fileInfo.ServerId);
                    var fileExists = await _clusterSvce.RawFileExistsAsync(this, recServer, pseudoId, fileInfo.CreateTime, fileInfo.Id);
                    if (!fileExists)
                    {
                        //通过hash进来的，并且文件不存在
                        if (string.IsNullOrEmpty(tmpFilePath))
                            throw new FriendlyException("File does not exist");

                        //文件被删或意外丢失重传
                        tSync = _clusterSvce.SyncFileToServerAsync(this, tmpFilePath, fileInfo, pseudoId, recServer);
                    }
                }

                var fileOwner = new FileOwner
                {
                    FileId = fileInfo.Id,
                    Name = fileName,
                    OwnerType = ownerTypeId.OwnerType,
                    OwnerId = ownerTypeId.OwnerId,
                    CreateTime = DateTime.Now
                };
                await FileRepo.AddFileOwnerAsync(fileOwner, pseudoId);
                if (tSync != null)
                    await tSync;

                //添加配额使用量
                await OwnerRepo.AddOwnerUsedQuotaAsync(ownerTypeId.OwnerType, ownerTypeId.OwnerId, fileSize);

                return new FileStorageInfo
                {
                    File = fileInfo,
                    Owner = fileOwner,
                    Server = recServer,
                    PseudoId = pseudoId
                };
            }
            finally
            {
                if (tmpFilePath != null)
                    FileUtil.TryDelete(tmpFilePath);
            }
        }

        public uint GeneratePseudoId(string data)
        {
            return HashUtil.Crc32(data);
        }

        public string GetFileDirectoryPath(uint pseudoId, DateTime fileCreateTime, int fileId)
        {
            var pIdBys = NetBitConverter.GetBytes(pseudoId);
            //每个文件有一个独立的目录，用于存放各种尺寸的文件
            //fileDirName = FileTableIndex_FileId
            var fileDirName = $"{pseudoId % _dbOption.CurrentValue.FileTableCount}_{fileId}";

            //dirPath = Root/Year/Month/Day/pseudoId[0]+pseudoId[1]
            var dirPath = Path.Combine(
                _option.CurrentValue.RootPath,
                fileCreateTime.Year.ToString(),
                fileCreateTime.Month.ToString("D2"),
                fileCreateTime.Day.ToString("D2"),
                pIdBys[0].ToString("x") + pIdBys[1].ToString("x"),
                fileDirName
            );
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            return dirPath;
        }

        /// <summary>
        /// 获取文件真实的路径
        /// </summary>
        public string GetRawFilePath(uint pseudoId, DateTime fileCreateTime, int fileId)
        {
            var dirPath = GetFileDirectoryPath(pseudoId, fileCreateTime, fileId);
            return Path.Combine(dirPath, "raw");
        }

        public bool RawFileExists(uint pseudoId, DateTime fileCreateTime, int fileId)
        {
            return System.IO.File.Exists(GetRawFilePath(pseudoId, fileCreateTime, fileId));
        }

        public Task DeleteFileAsync(uint pseudoId, DateTime fileCreateTime, int fileId)
        {
            return Task.Run(() =>
            {
                var dirPath = GetFileDirectoryPath(pseudoId, fileCreateTime, fileId);
                if (Directory.Exists(dirPath))
                {
                    try
                    {
                        Directory.Delete(dirPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"{nameof(DeleteFileAsync)}({dirPath})", ex);
                    }
                }
            });
        }

        /// <summary>
        /// 接收到临时文件
        /// </summary>
        public async Task<string> ReceiveToTempFileAsync(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                return await ReceiveToTempFileAsync(stream);
            }
        }

        /// <summary>
        /// 接收到临时文件
        /// </summary>
        public async Task<string> ReceiveToTempFileAsync(Stream file)
        {
            var filePath = Path.GetTempFileName();
            try
            {
                using (var stream = System.IO.File.OpenWrite(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch
            {
                //接收失败，删除临时文件
                FileUtil.TryDelete(filePath);
                throw;
            }
            return filePath;
        }

        /// <summary>
        /// 接收到指定路径
        /// </summary>
        public async Task<object> ReceiveToPathAsync(IFormFile file, string filePath)
        {
            try
            {
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch
            {
                //接收失败，删除临时文件
                FileUtil.TryDelete(filePath);
                throw;
            }
            return filePath;
        }

        /// <summary>
        /// 移动文件到指定路径
        /// </summary>
        public Task MoveToPathAsync(string srcFilePath, string destFilePath, bool overrideDest)
        {
            return Task.Run(() =>
            {
                if (overrideDest)
                {
                    if (System.IO.File.Exists(destFilePath))
                        System.IO.File.Delete(destFilePath);
                }
                System.IO.File.Move(srcFilePath, destFilePath);
            });
        }

        private IFileRepository FileRepo => _repoAccessor.GetRequiredRepository<IFileRepository>();
        private IOwnerRepository OwnerRepo => _repoAccessor.GetRequiredRepository<IOwnerRepository>();
    }
}
