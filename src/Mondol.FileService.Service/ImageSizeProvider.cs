// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service
{
    public class ImageSizeProvider
    {
        private readonly IConfiguration _configuration;
        private volatile Dictionary<string, ImageSize> _nameDict;

        public ImageSizeProvider(IConfiguration configuration)
        {
            _configuration = configuration;

            OnConfigChanged(null);
        }

        public ImageSize GetImageSizeByName(string name)
        {
            if (!_nameDict.TryGetValue(name, out var imgSize))
                throw new KeyNotFoundException("不支持的图片尺寸 " + name);

            return imgSize;
        }

        public IEnumerable<string> Names => _nameDict.Keys;

        private void LoadConfigs(out Dictionary<string, ImageSize> nameDict)
        {
            nameDict = new Dictionary<string, ImageSize>();

            var cImgSizes = _configuration.GetSection("ImageSizes").GetChildren();
            foreach (var cImgSize in cImgSizes)
            {
                var imgSize = new ImageSize()
                {
                    Name = cImgSize.GetValue<string>("Name"),
                    Width = cImgSize.GetValue<int>("Width"),
                    Height = cImgSize.GetValue<int>("Height")
                };
                if (imgSize.Width < 1)
                    throw new InvalidDataException("bad ImageSaze width: " + imgSize.Name);

                //添加到字典
                if (nameDict.TryGetValue(imgSize.Name, out var imgSize2))
                    throw new InvalidDataException($"{imgSize.Name} 与 {imgSize2.Name} 的Name重名");
                nameDict[imgSize.Name] = imgSize;
            }
        }

        private void OnConfigChanged(object state)
        {
            try
            {
                LoadConfigs(out var nameDict);

                _nameDict = nameDict;
            }
            finally
            {
                _configuration.GetReloadToken().RegisterChangeCallback(OnConfigChanged, null);
            }
        }
    }
}
