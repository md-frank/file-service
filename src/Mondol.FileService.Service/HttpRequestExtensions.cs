using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mondol.FileService.Service.Options;

namespace Mondol.FileService.Service
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// 获取真实的远程客户端IP
        /// </summary>
        /// <remarks>
        /// 在nginx中配置中加入
        /// proxy_set_header Host $host;
        /// proxy_set_header X-Real-IP $remote_addr;
        /// proxy_set_header X-Real-Port $remote_port;
        /// proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        /// </remarks>
        public static string GetRealRemoteIpAddress(this HttpRequest _)
        {
            var httpCtx = _.HttpContext;
            var serverOpts = httpCtx.RequestServices.GetRequiredService<IOptions<ServerOption>>();
            if (serverOpts.Value.ReverseProxy)
            {
                var xff = _.Headers["X-Forwarded-For"];
                if (xff.Count > 0)
                {
                    return xff[0];
                }
                else
                {
                    var xri = _.Headers["X-Real-IP"];
                    if (xri.Count > 0)
                    {
                        return xri[0];
                    }

                    throw new InvalidOperationException("无法获取远程IP，请检查反向代理配置");
                }
            }
            else
            {
                return _.HttpContext.Connection.RemoteIpAddress.ToString();
            }
        }

        /// <summary>
        /// 获取真实的Scheme
        /// </summary>
        /// <remarks>
        /// 在nginx中配置中加入
        /// proxy_set_header X-Real-Scheme $scheme;
        /// </remarks>
        public static string GetRealScheme(this HttpRequest _)
        {
            var httpCtx = _.HttpContext;
            var serverOpts = httpCtx.RequestServices.GetRequiredService<IOptions<ServerOption>>();
            if (serverOpts.Value.ReverseProxy)
            {
                var xff = _.Headers["X-Real-Scheme"];
                if (xff.Count > 0)
                {
                    return xff[0];
                }
                else
                {
                    throw new InvalidOperationException("无法获取远程IP，请检查反向代理配置");
                }
            }
            else
            {
                return _.HttpContext.Request.Scheme;
            }
        }

        public static string GetUri(this HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }
    }
}
