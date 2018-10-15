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
    /// IResult的扩展方法
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// 当前结果是否成功？
        /// </summary>
        public static bool IsSuccess(this IResult result) => result.ErrorCode == ResultErrorCodes.Success;

        /// <summary>
        /// 确保ErrorCode为Success否则抛出<see cref="InvalidOperationException"/>异常
        /// </summary>
        public static T EnsureSuccess<T>(this T _) where T : IResult
        {
            if (_.ErrorCode != ResultErrorCodes.Success)
                throw new InvalidOperationException($"errCode={_.ErrorCode}, errMsg={_.ErrorMsg}");
            return _;
        }
    }
}
