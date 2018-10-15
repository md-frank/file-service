// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
namespace Mondol.FileService.Service.Models
{
    /// <summary>
    /// 文件MIME定义
    /// </summary>
    public class Mime
    {
        /// <summary>
        /// MIME唯一ID
        /// </summary>
        public uint Id { get; set; }
        public string ContentType { get; set; }
        public string[] ExtensionNames { get; set; }

        public override int GetHashCode()
        {
            return (int)Id;
        }

        public bool Equals(Mime mime)
        {
            return Id.Equals(mime.Id);
        }

        public override bool Equals(object obj)
        {
            return Equals((Mime)obj);
        }

        public static bool operator ==(Mime mime1, Mime mime2)
        {
            return mime1?.Id == mime2?.Id;
        }

        public static bool operator !=(Mime mime1, Mime mime2)
        {
            return !(mime1 == mime2);
        }

        public bool IsImage => ContentType.StartsWith("image/");
        public bool IsApplication => ContentType.StartsWith("application/");
        public bool IsAudio => ContentType.StartsWith("audio/");
        public bool IsVideo => ContentType.StartsWith("video/");
        public bool IsText => ContentType.StartsWith("text/");        
    }
}