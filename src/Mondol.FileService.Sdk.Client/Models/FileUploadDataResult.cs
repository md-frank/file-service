using System;
using System.Collections.Generic;
using System.Text;

namespace Mondol.FileService.Models
{
    /// <summary>
    /// 文件上传结果数据
    /// </summary>
    public class FileUploadDataResult
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
