// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using Microsoft.AspNetCore.Http;
using Mondol.FileService.Db.Repositories;

namespace Mondol.FileService.Db.Repositories.Impls
{
    internal class RepositoryAccessor : IRepositoryAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public TData GetRepository<TData>() where TData : IRepository
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                throw new InvalidOperationException("当前上下文不能执行此操作");

            return (TData)httpContext.RequestServices.GetService(typeof(TData));
        }
    }
}
