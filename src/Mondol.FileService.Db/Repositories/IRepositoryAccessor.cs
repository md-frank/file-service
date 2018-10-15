// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;

namespace Mondol.FileService.Db.Repositories
{
    /// <summary>
    /// IXXXRepository访问器（XXX表示具体的业务数据模块）
    /// 
    /// IRepository生命周期是请求作用域级别的，
    /// 此访问器是单例的，可以方便的获取IRepository
    /// </summary>
    public interface IRepositoryAccessor
    {
        /// <summary>
        /// 获取指定类型的IRepository，不存在返回null
        /// </summary>
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
    }

    public static class RepositoryAccessorExtensions
    {
        /// <summary>
        /// 获取指定类型的IRepository，不存在抛出InvalidOperationException异常
        /// </summary>
        public static TRepository GetRequiredRepository<TRepository>(this IRepositoryAccessor dataAccessor) where TRepository : IRepository
        {
            var repo = dataAccessor.GetRepository<TRepository>();
            if (repo == null)
                throw new InvalidOperationException($"类型 {typeof(TRepository).FullName} 未找到");
            return repo;
        }
    }
}