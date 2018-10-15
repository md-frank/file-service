// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Collections.Generic;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service
{
    public interface IMimeProvider
    {
        Mime GetMimeByExtensionName(string extName);
        Mime GetMimeByFile(string filePath, string extName);
        Mime GetMimeById(uint id);
        IEnumerable<string> ImageExtensionNames { get; }
    }
}
