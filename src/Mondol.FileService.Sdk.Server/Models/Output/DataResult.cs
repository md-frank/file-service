// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
namespace Mondol.FileService.Service.Models.Output
{
    public class DataResult<T> : Result, IDataResult<T> where T : class
    {
        public DataResult()
        {
        }

        public DataResult(int errorCode = ResultErrorCodes.Unknown, string errorMsg = null)
            : base(errorCode, errorMsg)
        {
        }

        /// <summary>
        /// API结果的数据内容
        /// </summary>
        public T Data { get; set; }
    }
}