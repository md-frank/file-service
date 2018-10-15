// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service
{
    /// <summary>
    /// 文件处理器定义
    /// </summary>
    public interface IFileHandler
    {
        /// <summary>
        /// 文件处理器名字，全局唯一。
        /// 将来体现在URL中，例如：xxxxxxxxxxxxx/{name}/xxxx
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 转换修饰符描述
        /// </summary>
        IModifierDescribe ModifierDescribe { get; }

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context">请求上下文信息</param>
        Task<IActionResult> HandleAsync(FileHandleContext context);
    }
}
