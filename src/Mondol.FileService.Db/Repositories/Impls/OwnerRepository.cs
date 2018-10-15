// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-13
// 
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mondol.FileService.Db.Entities;
using Dapper;

namespace Mondol.FileService.Db.Repositories.Impls
{
    internal class OwnerRepository : Repository, IOwnerRepository
    {
        private readonly MasterDbContext _masterDb;

        public OwnerRepository(MasterDbContext masterDb)
        {
            _masterDb = masterDb;
        }

        public Task<long> GetOwnerRemainQuotaAsync(int ownerType, long ownerId)
        {
            var sql = "select Max-Used from OwnerQuota where OwnerType = @ownerType and OwnerId = @ownerId";
            return _masterDb.Connection.ExecuteScalarAsync<long>(sql, new { ownerType, ownerId });
        }

        public Task AddOwnerUsedQuotaAsync(int ownerType, long ownerId, long fileLength)
        {
            var sql = "update OwnerQuota set Used = Used+@fileLength where OwnerType = @ownerType and OwnerId = @ownerId";
            return _masterDb.Connection.ExecuteAsync(sql, new { fileLength, ownerType, ownerId });
        }

        public Task DecreaseOwnerUsedQuotaAsync(int ownerType, long ownerId, long fileLength)
        {
            var sql = "update OwnerQuota set Used = Used-@fileLength where OwnerType = @ownerType and OwnerId = @ownerId";
            return _masterDb.Connection.ExecuteAsync(sql, new { fileLength, ownerType, ownerId });
        }

        public Task SetOwnerMaxQuotaAsync(int ownerType, long ownerId, long max)
        {
            return Task.Run(() =>
            {
                var sql = "update OwnerQuota set Max = @max where OwnerType = @ownerType and OwnerId = @ownerId";
                var chgCount = _masterDb.Connection.Execute(sql, new { max, ownerType, ownerId });
                if (chgCount < 1)
                {
                    //影响数小于0也可能是新值与旧值相同
                    sql = "select count(*) from OwnerQuota where OwnerType = @ownerType and OwnerId = @ownerId";
                    var exists = 0 < _masterDb.Connection.ExecuteScalar<int>(sql, new { max, ownerType, ownerId });
                    if (!exists)
                    {
                        //不存在则创建
                        var oQuota = new OwnerQuota()
                        {
                            OwnerType = ownerType,
                            OwnerId = ownerId,
                            Max = max,
                            Used = 0
                        };

                        sql = "insert into OwnerQuota(OwnerType,OwnerId,Used,Max) values (@OwnerType,@OwnerId,@Used,@Max)";
                        _masterDb.Connection.Execute(sql, oQuota);
                    }
                }
            });
        }
    }
}
