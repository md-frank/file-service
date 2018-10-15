// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
namespace Mondol.FileService.Service.Models
{
    public class ImageSize
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static readonly ImageSize Raw = new ImageSize() { Name = "raw" };
    }
}
