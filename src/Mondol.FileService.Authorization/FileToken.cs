// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;

namespace Mondol.FileService.Authorization
{
    /// <summary>
    /// 包含文件基本信息的文件访问令牌
    /// </summary>
    public class FileToken
    {
        /// <summary>
        /// 文件伪ID
        /// </summary>
        public uint PseudoId { get; set; }
        /// <summary>
        /// File表的Id字段
        /// </summary>
        public int FileId { get; set; }
        /// <summary>
        /// FileOwner表的Id字段
        /// </summary>
        public int FileOwnerId { get; set; }

        /// <summary>
        /// MIME类的Id字段
        /// </summary>
        public uint MimeId { get; set; }

        public DateTime FileCreateTime { get; set; }
        public DateTime ExpireTime { get; set; }

        public bool IsExpired => ExpireTime <= DateTime.Now;
    }
}