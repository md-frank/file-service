// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
namespace Mondol.FileService.Service.Models
{
    /// <summary>
    /// 图像转换修饰信息描述
    /// </summary>
    public class ImageModifierDescribe : IModifierDescribe
    {
        public string Syntax => "[site]_[format]";
        public string[] Sizes { get; set; }
        public string[] Formats { get; set; }
    }
}
