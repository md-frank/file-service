// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-13
// 
namespace Mondol.FileService.Service.Models
{
    /// <summary>
    /// 转换修饰信息描述
    /// </summary>
    public interface IModifierDescribe
    {
        /// <summary>
        /// 参数拼接语法，参数间用_分隔
        /// </summary>
        string Syntax { get; }
    }
}
