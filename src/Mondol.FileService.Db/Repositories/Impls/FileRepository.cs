// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Mondol.FileService.Db.Entities;
using Dapper;
using Mondol.FileService.Db.Options;
using System.Linq;

namespace Mondol.FileService.Db.Repositories.Impls
{
    internal class FileRepository : Repository, IFileRepository
    {
        private readonly MasterDbContext _masterDb;
        private readonly DbOption _option;

        public FileRepository(MasterDbContext masterDb, IOptionsMonitor<DbOption> option)
        {
            _option = option.CurrentValue;
            _masterDb = masterDb;
        }

        public Task<string> GetFileNameByIdAsync(uint pseudoId, int fileOwnerId)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            string sql = null;
            if (_option.DbType == DatabaseType.SqlServer)
                sql = $"select top 1 Name from FileOwner_{tabInex} where Id = @id";
            else if (_option.DbType == DatabaseType.MySql)
                sql = $"select Name from FileOwner_{tabInex} where Id = @id limit 1";
            return _masterDb.Connection.QueryFirstOrDefaultAsync<string>(sql, new { id = fileOwnerId });
        }

        public Task<File> GetFileByIdAsync(uint pseudoId, int id)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            string sql = null;
            if (_option.DbType == DatabaseType.SqlServer)
                sql = $"select top 1 * from File_{tabInex} where Id = @id";
            else if (_option.DbType == DatabaseType.MySql)
                sql = $"select * from File_{tabInex} where Id = @id limit 1";
            return _masterDb.Connection.QueryFirstOrDefaultAsync<File>(sql, new { id });
        }

        public Task<File> GetFileByOwnerIdAsync(uint pseudoId, int fileOwnerId)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            string sql = null;
            if (_option.DbType == DatabaseType.SqlServer)
                sql = $"select top 1 tf.*,tfo.* from fileowner_{tabInex} as tfo left join file_{tabInex} as tf on tfo.FileId = tf.Id where tfo.Id = @fileOwnerId";
            else if (_option.DbType == DatabaseType.MySql)
                sql = $"select tf.*,tfo.* from fileowner_{tabInex} as tfo left join file_{tabInex} as tf on tfo.FileId = tf.Id where tfo.Id = @fileOwnerId limit 1";

            return Task.Run(() =>
            {
                return ((List<File>) _masterDb.Connection.Query<File, FileOwner, File>(sql, (f, fo) =>
                {
                    f.FileOwner = fo;
                    return f;
                }, new {fileOwnerId}, buffered: true, splitOn: "Id")).FirstOrDefault();
            });
        }

        public Task<File> GetFileByHashAsync(uint pseudoId, string hash)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            string sql = null;
            if (_option.DbType == DatabaseType.SqlServer)
                sql = $"select top 1 * from File_{tabInex} where SHA1 = @hash";
            else if (_option.DbType == DatabaseType.MySql)
                sql = $"select * from File_{tabInex} where SHA1 = @hash limit 1";
            return _masterDb.Connection.QueryFirstOrDefaultAsync<File>(sql, new { hash });
        }

        public Task AddFileAsync(File file, uint pseudoId)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            var sql = $"insert into File_{tabInex}(Length,ServerId,MimeId,SHA1,ExtInfo,CreateTime) values " +
                      "(@Length,@ServerId,@MimeId,@SHA1,@ExtInfo,@CreateTime)";
            return InsertAsync(_masterDb.Connection, _option.DbType, sql, file, id => file.Id = id);
        }

        public Task AddFileOwnerAsync(FileOwner fileOwner, uint pseudoId)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            var sql = $"insert into FileOwner_{tabInex}(FileId,Name,OwnerType,OwnerId,CreateTime) values " +
                      "(@FileId,@Name,@OwnerType,@OwnerId,@CreateTime)";
            return InsertAsync(_masterDb.Connection, _option.DbType, sql, fileOwner, id => fileOwner.Id = id);
        }

        public Task<FileOwner> GetFileOwnerByOwnerAsync(uint pseudoId, int fileId, int ownerType, int ownerId)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            string sql = null;
            if (_option.DbType == DatabaseType.SqlServer)
                sql = $"select top 1 * from FileOwner_{tabInex} where FileId = @fileId and OwnerType = @ownerType and OwnerId = @ownerId";
            else if (_option.DbType == DatabaseType.MySql)
                sql = $"select * from FileOwner_{tabInex} where FileId = @fileId and OwnerType = @ownerType and OwnerId = @ownerId limit 1";
            return _masterDb.Connection.QueryFirstOrDefaultAsync<FileOwner>(sql, new { fileId, ownerType, ownerId });
        }

        public Task<FileOwner> GetFileOwnerByIdAsync(int id, uint pseudoId)
        {
            var tabInex = pseudoId % _option.FileTableCount;
            string sql = null;
            if (_option.DbType == DatabaseType.SqlServer)
                sql = $"select top 1 * from FileOwner_{tabInex} where Id = @id";
            else if (_option.DbType == DatabaseType.MySql)
                sql = $"select * from FileOwner_{tabInex} where Id = @id limit 1";
            return _masterDb.Connection.QueryFirstOrDefaultAsync<FileOwner>(sql, new { id });
        }

        public Task<int> DeleteFileAsync(int ownerId, int fileId, uint pseudoId)
        {
            return Task.Run(() =>
            {
                var tabInex = pseudoId % _option.FileTableCount;

                var sql = $"select count(1) from FileOwner_{tabInex} where FileId = @fileId";
                var refCount = _masterDb.Connection.ExecuteScalar<int>(sql, new { fileId });

                using (var trans = _masterDb.Connection.Transaction())
                {
                    sql = $"delete from FileOwner_{tabInex} where Id = @p0";
                    _masterDb.Connection.Execute(sql, new object[] { ownerId });
                    if (refCount <= 1)
                    {
                        sql = $"delete from File_{tabInex} where Id = @p0";
                        _masterDb.Connection.Execute(sql, new object[] { ownerId });
                    }

                    trans.Complete();
                }

                return refCount - 1;
            });
        }
    }
}
