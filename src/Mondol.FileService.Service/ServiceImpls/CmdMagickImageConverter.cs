using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mondol.Diagnostics.Utils;
using Mondol.FileService.Service.Options;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service.ServiceImpls
{
    internal class CmdMagickImageConverter : QueuingImageConverter
    {
        private readonly IOptionsMonitor<ImageConverterOption> _option;
        private readonly ILogger<CmdMagickImageConverter> _logger;
        private static readonly Regex RexVar = new Regex(@"\$\{(\w+)\}", RegexOptions.Singleline);

        public CmdMagickImageConverter(IOptionsMonitor<ImageConverterOption> option, ILogger<CmdMagickImageConverter> logger)
        {
            _option = option;
            _logger = logger;
        }

        protected override Task OnConvertAsync(string srcFilePath, Mime srcMime, string dstFilePath, ImageModifier dstImgMod, TaskContext taskCtx)
        {
            return Task.Run(() =>
            {
                Exception eError = null;
                try
                {
                    //转换完成前先用临时文件名，防止中途失败产生坏文件
                    var dstTmpFilePath = $"{dstFilePath}.cvting.{dstImgMod.Mime.ExtensionNames.First()}";
                    ConvertImage(srcFilePath, srcMime, dstTmpFilePath, dstImgMod);
                    File.Move(dstTmpFilePath, dstFilePath);
                }
                catch (Exception ex)
                {
                    eError = ex;
                }
                finally
                {
                    taskCtx.Complete(eError);
                }
            });
        }

        private void ConvertImage(string srcFilePath, Mime srcMime, string dstFilePath, ImageModifier dstImgMod)
        {
            var isSvg = false;
            if (srcMime.ContentType == "image/svg+xml")
            {
                var oldSrcFilePath = srcFilePath;
                srcFilePath += Guid.NewGuid().ToString("N") + ".svg";
                File.Copy(oldSrcFilePath, srcFilePath, true);
                isSvg = true;
            }

            try
            {
                //命令行参考：http://elf8848.iteye.com/blog/382528
                var opt = _option.CurrentValue;
                var pArgs = string.Empty;
                if (dstImgMod.Size != ImageSize.Raw)
                {
                    var size = dstImgMod.Size;
                    if (size.Width < 1 && size.Height < 1)
                        throw new InvalidOperationException("宽与高不能同时小于1");

                    var widthStr = size.Width > 0 ? size.Width.ToString() : "";
                    var heightStr = size.Height > 0 ? size.Height.ToString() : "";
                    var resizeArgs = RexVar.Replace(_option.CurrentValue.ResizeArgs, m =>
                    {
                        var varName = m.Groups[1].Value;
                        switch (varName)
                        {
                            case "width":
                                return widthStr;
                            case "height":
                                return heightStr;
                            default:
                                return m.Value;
                        }
                    });
                    pArgs += "-resize \"" + resizeArgs + "\"";
                }
                pArgs += $" \"{srcFilePath}\" \"{dstFilePath}\"";
                var timeoutSec = opt.ConvertTimeout * 1000;
                var exitCode = ProcessUtil.ExecuteCommand(opt.ConverterPath, pArgs, out var stdOut, out var errOut, timeoutSec);
                if (exitCode != 0)
                {
                    _logger.LogError($"Convert Fail\n CmdArgs: {pArgs}\n StdOut: {stdOut}, ErrOut: {errOut}");
                    throw new InvalidOperationException("convert fail, exitCode=" + exitCode);
                }
            }
            catch
            {
                try
                {
                    File.Delete(dstFilePath);
                }
                catch
                {
                    ;
                }
                throw;
            }
            finally
            {
                if (isSvg)
                    try
                    {
                        File.Delete(srcFilePath);
                    }
                    catch
                    {
                        ;
                    }
            }
        }
    }
}
