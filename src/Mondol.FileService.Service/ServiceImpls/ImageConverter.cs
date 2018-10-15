//// Copyright (c) Mondol. All rights reserved.
//// 
//// Author:  frank
//// Email:   frank@mondol.info
//// Created: 2016-11-17
//// 
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using ImageMagick;
//using Mondol.FileService.Service.Models;

//namespace Mondol.FileService.Service.ServiceImpls
//{
//    public class ImageConverter : IImageConverter
//    {
//        /// <summary>
//        /// 转换中的任务
//        /// </summary>
//        private readonly Dictionary<string, TaskInfo> _convertingTasks = new Dictionary<string, TaskInfo>();

//        public Task ConvertAsync(string srcFilePath, Mime srcMime, string dstFilePath, ImageModifier dstImgMod)
//        {
//            return Task.Run(() =>
//            {
//                TaskInfo taskInfo = null;
//                lock (_convertingTasks)
//                {
//                    //用dstFilePath作为任务唯一ID，多次转换请求自动合并
//                    if (!_convertingTasks.TryGetValue(dstFilePath, out taskInfo))
//                    {
//                        taskInfo = new TaskInfo()
//                        {
//                            CompleteEvent = new ManualResetEvent(false)
//                        };
//                        _convertingTasks[dstFilePath] = taskInfo;

//                        ConvertInternalAsync(srcFilePath, dstFilePath, dstImgMod, taskInfo);
//                    }
//                }

//                //等待任务转换完成
//                taskInfo.CompleteEvent.WaitOne();
//                if (taskInfo.Error != null)
//                    throw taskInfo.Error;
//            });
//        }

//        private Task ConvertInternalAsync(string srcFilePath, string dstFilePath, ImageModifier imgMod, TaskInfo taskInfo)
//        {
//            return Task.Run(() =>
//            {
//                Exception eError = null;
//                try
//                {
//                    //dstFilePath是任务唯一ID，是判断任务已完成的标志，因此不能存在未完全完成的文件
//                    //转换完成前先用临时文件名
//                    var dstTmpFilePath = $"{dstFilePath}.cvting.{imgMod.Mime.ExtensionNames.First()}";

//                    using (var img = new MagickImage(srcFilePath))
//                    {
//                        img.Thumbnail(imgMod.Size.Width, imgMod.Size.Height);

//                        //magick会自动根据扩展名决定文件格式
//                        img.Write(dstTmpFilePath);
//                    }

//                    File.Move(dstTmpFilePath, dstFilePath);
//                }
//                catch (Exception ex)
//                {
//                    eError = ex;
//                }

//                lock (_convertingTasks)
//                {
//                    _convertingTasks.Remove(dstFilePath);
//                }
//                taskInfo.Error = eError;
//                taskInfo.CompleteEvent.Set();
//                taskInfo.CompleteEvent.Dispose();
//            });
//        }

//        private class TaskInfo
//        {
//            public ManualResetEvent CompleteEvent { get; set; }
//            public Exception Error { get; set; }
//        }
//    }
//}
