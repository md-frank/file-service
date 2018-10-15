// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace Mondol.WebPlatform.Swagger
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static void UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseMiddleware<SwaggerBeforeHookMiddleware>();

            app.UseSwagger(opts =>
            {
                opts.RouteTemplate = "docs/apis/{documentName}/schema.json";
                opts.PreSerializeFilters.Add((sDoc, httpReq) =>
                {
                    var docName = (string)sDoc.Info.Extensions["docName"];
                    string prefix;
                    switch (docName)
                    {
                        case "client":
                            prefix = "/files"; //结尾不加/，因为文件上传接口结尾无/
                            break;
                        case "server":
                            prefix = "/sapi/";
                            break;
                        default:
                            throw new NotSupportedException("不支持的DocName：" + docName);
                    }
                    sDoc.Paths = sDoc.Paths.Where(p => p.Key.StartsWith(prefix)).ToDictionary(p => p.Key, p => p.Value);
                });                
            });
            app.UseSwaggerUI(opts =>
            {
                opts.RoutePrefix = "docs/apis";
                opts.DocExpansion(DocExpansion.None);
                opts.DocumentTitle = "API文档";
                opts.EnableFilter();

                opts.SwaggerEndpoint("/docs/apis/client/schema.json", "客户端");
                opts.SwaggerEndpoint("/docs/apis/server/schema.json", "服务端");
            });
        }
    }
}
