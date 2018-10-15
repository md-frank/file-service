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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service.ServiceImpls
{
    public class ImageFileHandler : IFileHandler
    {
        private static readonly char[] ModifierSplit = { '_' };
        private readonly IMimeProvider _mimeProvider;
        private readonly ImageSizeProvider _imgSizeProvider;
        private readonly IImageConverter _imgCvter;

        public ImageFileHandler(IMimeProvider mimeProvider, ImageSizeProvider imgSizeProvider, IImageConverter imgCvter)
        {
            _mimeProvider = mimeProvider;
            _imgSizeProvider = imgSizeProvider;
            _imgCvter = imgCvter;

            var sizes = new List<string>(_imgSizeProvider.Names);
            sizes.Insert(0, "raw");
            var formats = new List<string>(_mimeProvider.ImageExtensionNames);
            formats.Insert(0, "raw");
            ModifierDescribe = new ImageModifierDescribe()
            {
                Sizes = sizes.ToArray(),
                Formats = formats.ToArray()
            };
        }

        public string Name => "image";
        public IModifierDescribe ModifierDescribe { get; }
        public async Task<IActionResult> HandleAsync(FileHandleContext context)
        {
            if (string.IsNullOrEmpty(context.Modifier))
                throw new ArgumentNullException(nameof(context.Modifier));

            var imgMod = ParseModifier(context.Modifier, context.SourceMime);

            if (ShouldRsponseRaw(imgMod, context))
                return new PhysicalFileResult(context.SourcePath, context.SourceMime.ContentType);

            //判断是否有缓存
            var rawDirPath = Path.GetDirectoryName(context.SourcePath);
            var dstFilePath = Path.Combine(rawDirPath, $"image_{imgMod.Size.Name}_{imgMod.Mime.ExtensionNames.First()}");
            if (!File.Exists(dstFilePath))
                await _imgCvter.ConvertAsync(context.SourcePath, context.SourceMime, dstFilePath, imgMod);

            return new PhysicalFileResult(dstFilePath, imgMod.Mime.ContentType);
        }

        private ImageModifier ParseModifier(string modifier, Mime sourceMime)
        {
            var modifierArr = modifier.Split(ModifierSplit);
            var size = modifierArr?.Length > 0 ? modifierArr[0] : "raw";
            var fmtName = modifierArr?.Length > 1 ? modifierArr[1] : "raw";
            if (fmtName != "raw" && sourceMime.ExtensionNames.Any(p => p == fmtName))
                fmtName = "raw";

            var mime = fmtName != "raw" ? _mimeProvider.GetMimeByExtensionName(fmtName) : sourceMime;
            return new ImageModifier()
            {
                Size = size == "raw" ? ImageSize.Raw : _imgSizeProvider.GetImageSizeByName(size),
                Mime = mime
            };
        }

        /// <summary>
        /// 是否应该返回源文件
        /// </summary>
        private bool ShouldRsponseRaw(ImageModifier imgMod, FileHandleContext context)
        {
            if (imgMod.Mime == context.SourceMime)
            {
                if (imgMod.Size == ImageSize.Raw)
                    return true;
            }

            return false;
        }
    }
}
