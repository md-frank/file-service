// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mondol.FileService.Models.Result;
using Mondol.FileService.Service;

namespace Mondol.FileService
{
    /// <summary>
    /// 全局异常处理选项
    /// </summary>
    public class GlobalExceptionHandlerOptions : ExceptionHandlerOptions
    {
        private static readonly UTF8Encoding UTF8NoBOM = new UTF8Encoding(false, true);

        public GlobalExceptionHandlerOptions()
        {
            this.ExceptionHandler = OnExceptionHandler;
        }

        public Task OnExceptionHandler(HttpContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var rsp = context.Response;
                if (rsp.HasStarted)
                    throw new Exception("The response has already started, the error page middleware will not be executed.");

                var svces = context.RequestServices;
                var env = svces.GetRequiredService<IHostingEnvironment>();
                var ex = context.Features.Get<IExceptionHandlerFeature>().Error;

                var rJson = ex is FriendlyException ? new Result(ResultErrorCodes.Failure, ex.Message) : env.IsDevelopment() ?
                    new Result(ResultErrorCodes.SystemError, $"Server internal error: {ex}") :
                    new Result(ResultErrorCodes.SystemError, "Server internal error, Please contact system administrator.");
                WriteResult(context, rJson);
            });
        }

        private void WriteResult(HttpContext context, IResult result)
        {
            var rsp = context.Response;

            rsp.Clear();
            rsp.StatusCode = 200;
            rsp.ContentType = "application/json; charset=utf-8";

            var jrs = context.RequestServices.GetRequiredService<IJsonSerializer>();
            using (var sw = new StreamWriter(rsp.Body, UTF8NoBOM, 1024, true))
            {
                jrs.Serialize(sw, result);
            }
        }
    }
}
