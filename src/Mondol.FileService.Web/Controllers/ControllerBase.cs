// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;

namespace Mondol.FileService.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private volatile ILogger _logger;

        /// <summary>
        /// 返回当前类的日志记录器
        /// </summary>
        protected ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    var resolver = HttpContext.RequestServices;
                    if (resolver == null)
                        throw new InvalidOperationException($"{nameof(HttpContext.RequestServices)} is null");

                    _logger = resolver.GetRequiredService<ILoggerFactory>().CreateLogger(GetType().Name);
                }
                return _logger;
            }
        }

        public IServiceProvider RequestService => HttpContext.RequestServices;
        public ISession Session => HttpContext.Session;
    }
}
