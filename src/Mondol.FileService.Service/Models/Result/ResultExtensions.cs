// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
namespace Mondol.FileService.Models.Result
{
    /// <summary>
    /// IResult的扩展方法
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// 当前结果是否成功？
        /// </summary>
        public static bool IsSuccess(this IResult result) => result.ErrorCode == ResultErrorCodes.Success;
    }
}
