// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Text;
using Mondol.FileService.Authorization.Options;

namespace Mondol.FileService.Service.Options
{
    public class GeneralOption : AuthOption
    {
        /// <summary>
        /// 存储用户文件的根目录路径
        /// </summary>
        public string RootPath { get; set; }
        /// <summary>
        /// 是否查询文件名(需要查库)
        /// 当请求/raw下载时是否返回上传时的文件名
        /// </summary>
        public bool QueryFileName { get; set; }
    }
}
