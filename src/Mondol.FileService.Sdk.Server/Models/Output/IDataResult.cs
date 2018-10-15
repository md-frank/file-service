// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
namespace Mondol.FileService.Service.Models.Output
{
    /// <summary>
    /// 带附加Data的操作结果接口定义
    /// </summary>
    public interface IDataResult<T> : IResult where T : class
    {
        T Data { get; set; }
    }
}