// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Threading.Tasks;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service
{
    /// <summary>
    /// 图像转换器
    /// </summary>
    public interface IImageConverter
    {
        Task ConvertAsync(string srcFilePath, Mime srcMime, string dstFilePath, ImageModifier dstImgMod);
    }
}
