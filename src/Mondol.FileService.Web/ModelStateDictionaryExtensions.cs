// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mondol.WebPlatform
{
    public static class ModelStateDictionaryExtensions
    {
        /// <summary>
        /// 获取第1个错误消息
        /// </summary>
        public static string GetFirstErrorMessage(this ModelStateDictionary modelState)
        {
            return modelState.Values
                .First(p => p.ValidationState == ModelValidationState.Invalid)
                .Errors.First()
                .ErrorMessage;
        }
    }
}
