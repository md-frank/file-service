// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Mondol.FileService.Models.Result;
using Mondol.FileService.Options;

namespace Mondol.FileService.Controllers
{
    public abstract class BaseServerApiController : ControllerBase
    {
        private readonly IOptionsMonitor<ManageOption> _manageOption;

        protected BaseServerApiController(IOptionsMonitor<ManageOption> manageOption)
        {
            _manageOption = manageOption;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var connInfo = context.HttpContext.Connection;
            var cIpAddr = connInfo.RemoteIpAddress.ToString();

            var mgrOpt = _manageOption.CurrentValue;
            if (!mgrOpt.IsLocalIp(cIpAddr) && !mgrOpt.IpWhitelist.Any(p => p == "*" || p == cIpAddr))
                context.Result = new JsonResult(new Result(ResultErrorCodes.Unauthorized, $"您的IP({cIpAddr})没有权限访问"));
            else
                base.OnActionExecuting(context);
        }
    }
}
