// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 

using System;

namespace Mondol.FileService.Service.Models.Output
{
    /// <summary>
    /// 操作结果接口定义
    /// </summary>
    public interface IResult
    {
        int ErrorCode { get; set; }
        string ErrorMsg { get; set; }
    }
}