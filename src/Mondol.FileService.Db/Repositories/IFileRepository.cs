// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Threading.Tasks;
using Mondol.FileService.Db.Entities;

namespace Mondol.FileService.Db.Repositories
{
    /// <summary>
    /// 文件相关的数据访问接口
    /// </summary>
    public interface IFileRepository : IRepository
    {
        Task<File> GetFileByIdAsync(uint pseudoId, int id);
        Task<File> GetFileByOwnerIdAsync(uint pseudoId, int fileOwnerId);
        Task<File> GetFileByHashAsync(uint pseudoId, string hash);
        Task AddFileAsync(File file, uint pseudoId);
        Task AddFileOwnerAsync(FileOwner fileOwner, uint pseudoId);
        Task<FileOwner> GetFileOwnerByIdAsync(int id, uint pseudoId);
        Task<FileOwner> GetFileOwnerByOwnerAsync(uint pseudoId, int fileId, int ownerType, int ownerId);
        Task<string> GetFileNameByIdAsync(uint pseudoId, int fileOwnerId);
        /// <summary>
        /// 删除一个文件
        /// </summary>
        /// <returns>剩余引用计数</returns>
        Task<int> DeleteFileAsync(int ownerId, int fileId, uint pseudoId);
    }
}
