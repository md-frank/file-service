// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
#if DEBUG

using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Service;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Controllers
{
    /// <summary>
    /// 调试代码用的控制器
    /// </summary>
    /// <remarks>
    /// 此控制器下的方法只在DEBUG模式下才可使用
    /// </remarks>
    [Route("~/debug/[action]")]
    public class DebugController : ControllerBase
    {
        public async Task<IActionResult> Default()
        {
            var hcFac = RequestService.GetRequiredService<IHttpClientFactory>();
            var hc = hcFac.CreateClient();
            var str = await hc.GetStreamAsync("http://baidu.com/");

            //var fsSvce = RequestService.GetRequiredService<FileService.Sdk.Server.FileService>();
            //fsSvce.GenerateOwnerTokenAsync(1, 1, TimeSpan.FromDays(7));

            var ownerTokenCodec = RequestService.GetRequiredService<IOwnerTokenCodec>();

            var oToken = new OwnerToken()
            {
                OwnerId = 1,
                OwnerType = 2,
                ExpireTime = DateTime.Now.AddDays(1)
            };
            var oTokenStr = ownerTokenCodec.Encode(oToken);
            var oToken2 = ownerTokenCodec.Decode(oTokenStr);

            return Content(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }
    }
}

#endif