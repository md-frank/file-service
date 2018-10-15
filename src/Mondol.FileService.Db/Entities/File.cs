// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;

namespace Mondol.FileService.Db.Entities
{
    /// <summary>
    /// 文件基本信息
    /// </summary>
    public class File
    {
        public int Id { get; set; }
        public long Length { get; set; }
        public int ServerId { get; set; }
        public int MimeId { get; set; }
        public string SHA1 { get; set; }
        /// <summary>
        /// 文件扩展信息
        /// </summary>
        public string ExtInfo { get; set; }
        public DateTime CreateTime { get; set; }

        public FileOwner FileOwner { get; set; }
    }
}
