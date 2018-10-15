// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-01-23
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mondol.FileService.Authorization.Options;

namespace Mondol.FileService.Server
{
    public class FileServiceOption : AuthOption
    {
        /// <summary>
        /// 服务服务器IP地址
        /// </summary>
        public string Host { get; set; }
    }
}
