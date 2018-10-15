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
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Authorization.Options;

namespace Mondol.FileService.Server
{
    /// <summary>
    /// FileService的IServiceCollection扩展
    /// </summary>
    public static class ServiceServiceCollectionSdkExtensions
    {
        /// <summary>
        /// 添加FileService.Sdk.Server的相关服务
        /// </summary>
        public static void AddFileService(this IServiceCollection services)
        {
            ServiceConfigure.AddAuthorization(services);
            services.AddSingleton<IFileServiceManager, FileServiceManager>();
            services.AddSingleton<IHttpClientFactory, DefaultHttpClientFactory>();

            services.Configure<HttpClientFactoryOptions>(opt => { });
        }

        public static void AddFileService(this IServiceCollection services, Action<FileServiceOption> configure)
        {
            AddFileService(services);

            services.Configure(configure);

            var opt = new FileServiceOption();
            configure(opt);
            services.Configure<AuthOption>(x =>
            {
                x.AppSecret = opt.AppSecret;
            });
        }
    }
}
