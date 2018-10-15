// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mondol.Net.Http
{
    /// <summary>
    /// MultipartFormDataContent的扩展方法
    /// </summary>
    public static class MultipartFormDataContentExtensions
    {
        /// <summary>
        /// 添加字符串字段
        /// </summary>
        public static void AddByString(this MultipartFormDataContent this_, string name, string content)
        {
            this_.Add(new StringContent(content), name);
        }

        /// <summary>
        /// 添加文件字段
        /// </summary>
        public static void AddByFile(this MultipartFormDataContent this_, string name, string filePath)
        {
            var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileName = Path.GetFileName(filePath);
            //StreamContent会自动释放Stream
            var sc = new StreamContent(fs);
            sc.Headers.ContentType = GetContentTypeByFile(fileName);
            this_.Add(sc, name, fileName);
        }

        private static MediaTypeHeaderValue GetContentTypeByFile(string fileName)
        {
            var retnVal = "application/octet-stream";
            var feName = string.IsNullOrEmpty(fileName) ? null : Path.GetExtension(fileName);
            if (!string.IsNullOrEmpty(feName))
            {
                feName = feName.Substring(1).ToLower();
                switch (feName)
                {
                    case "jpg":
                        retnVal = "image/jpeg";
                        break;
                    case "bmp":
                    case "png":
                    case "gif":
                    case "jpeg":
                        retnVal = "image/" + feName;
                        break;
                    case "txt":
                        retnVal = "text/plain";
                        break;
                    case "avi":
                    case "asf":
                    case "wmv":
                    case "mp4":
                    case "rm":
                    case "rmvb":
                    case "3gp":
                    case "mpg":
                    case "mov":
                    case "flv":
                        retnVal = "video/" + feName;
                        break;
                    case "wma":
                    case "mp3":
                    case "wav":
                        retnVal = "audio/" + feName;
                        break;
                }
            }

            return new MediaTypeHeaderValue(retnVal);
        }
    }
}
