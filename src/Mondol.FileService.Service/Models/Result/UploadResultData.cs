// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
namespace Mondol.FileService.Models.Result
{
    /// <summary>
    /// 文件上传结果数据
    /// </summary>
    public class UploadResultData
    {
        /// <summary>
        /// 文件访问令牌
        /// </summary>
        public string FileToken { get; set; }
        /// <summary>
        /// 文件下载根地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 长度（字节）
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 所有字段的签名
        /// </summary>
        public string Sign { get; set; }
    }
}