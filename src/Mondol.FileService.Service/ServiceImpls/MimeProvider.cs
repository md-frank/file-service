// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Mondol.Security.Cryptography.Utils;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service.ServiceImpls
{
    public class MimeProvider : IMimeProvider
    {
        private readonly IConfiguration _configuration;

        private volatile Dictionary<string, Mime> _extNameDict;
        private volatile Dictionary<uint, Mime> _idDict;

        public MimeProvider(IConfiguration configuration)
        {
            _configuration = configuration;

            OnConfigChanged(null);
        }

        public Mime GetMimeByExtensionName(string extName)
        {
            if (!_extNameDict.TryGetValue(extName, out var mime))
                throw new KeyNotFoundException("不支持的文件类型 ." + extName);

            return mime;
        }

        public Mime GetMimeByFile(string filePath, string extName)
        {
            if (string.IsNullOrEmpty(extName))
                throw new ArgumentException("请指定文件扩展名");

            if (!_extNameDict.TryGetValue(extName, out var mime))
                throw new KeyNotFoundException("不支持的文件类型 ." + extName);

            //if (mime.IsImage)
            //{
            //    try
            //    {
            //        var mrs = new MagickReadSettings()
            //        {

            //        };
            //        using (var img = new MagickImage(filePath, mrs))
            //        {
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new InvalidDataException("不支持的图像格式");
            //    }
            //}

            return mime;
        }

        public Mime GetMimeById(uint id)
        {
            if (!_idDict.TryGetValue(id, out var mime))
                throw new KeyNotFoundException("bad mimeId");

            return mime;
        }

        public IEnumerable<string> ImageExtensionNames => _extNameDict.Keys.Where(p => _extNameDict[p].IsImage);

        private void LoadConfigs(out Dictionary<string, Mime> extNameDict, out Dictionary<uint, Mime> idDict)
        {
            extNameDict = new Dictionary<string, Mime>();
            idDict = new Dictionary<uint, Mime>();

            var mimes = _configuration.GetSection("Mimes").GetChildren();
            foreach (var mime in mimes)
            {
                var extNames = mime.GetSection("ExtensionNames").GetChildren().Select(p => p.Value).ToArray();

                var m = new Mime
                {
                    ContentType = mime.GetValue<string>("ContentType"),
                    ExtensionNames = extNames
                };
                GenerateMimeId(m);

                //添加到字典
                if (idDict.TryGetValue(m.Id, out var m2))
                    throw new InvalidDataException($"{m.ContentType} 与 {m2.ContentType} 的ID冲突");
                idDict[m.Id] = m;

                foreach (var extName in extNames)
                {
                    extNameDict[extName] = m;
                }
            }            
        }

        private void GenerateMimeId(Mime mime)
        {
            mime.Id = HashUtil.Crc32(mime.ContentType);
        }

        private void OnConfigChanged(object state)
        {
            try
            {
                LoadConfigs(out var extNameDict, out var idDict);

                _extNameDict = extNameDict;
                _idDict = idDict;
            }
            finally
            {
                _configuration.GetReloadToken().RegisterChangeCallback(OnConfigChanged, null);
            }            
        }
    }
}
