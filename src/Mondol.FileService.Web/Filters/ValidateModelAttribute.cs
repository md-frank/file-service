// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mondol.FileService.Models.Result;
using Mondol.WebPlatform;

namespace Mondol.FileService.Filters
{
    /// <summary>
    /// 确保当前Action的Model是已验证的，否则返回错误响应结果
    /// </summary>
    public class ValidateModelAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = new Result(ResultErrorCodes.ArgumentBad, context.ModelState.GetFirstErrorMessage());
                context.Result = new JsonResult(result);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
