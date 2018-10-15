// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-13
// 

using Mondol.FileService.Authorization;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service
{
    /// <summary>
    /// 文件处理上下文
    /// </summary>
    public class FileHandleContext
    {
        public string SourcePath { get; set; }
        public Mime SourceMime { get; set; }
        public string Modifier { get; set; }
        public FileToken FileToken { get; set; }
    }
}
