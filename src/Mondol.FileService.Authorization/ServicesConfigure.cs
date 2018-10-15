// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-01-24
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Authorization.Codecs.Impls;
using Mondol.FileService.Authorization.Options;

namespace Mondol.FileService.Authorization
{
    /// <summary>
    /// FileService的IServiceCollection扩展
    /// </summary>
    public static class ServiceConfigure
    {
        /// <summary>
        /// 添加FileService.Sdk.Server的相关服务
        /// </summary>
        public static void AddAuthorization(IServiceCollection services)
        {
            services.AddSingleton<IOwnerTokenCodec, OwnerTokenCodec>();
            services.AddSingleton<IUrlDataCodec, UrlDataCompatibilityCodec>();
            services.AddSingleton<AppSecretSigner>();
        }

        public static void AddAuthorization(IServiceCollection services, Action<AuthOption> configure)
        {
            AddAuthorization(services);

            services.Configure(configure);
        }
    }
}
