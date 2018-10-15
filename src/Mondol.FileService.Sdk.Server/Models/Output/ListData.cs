// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
using System.Collections.Generic;

namespace Mondol.FileService.Service.Models.Output
{
    public class ListData<T>
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public IEnumerable<T> List { get; set; }
    }
}
