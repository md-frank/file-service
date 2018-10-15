// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-02-01
// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Mondol.FileService.Web.Models.Input.User
{
    public class UploadFileInput : BaseOwnerTokenInput
    {
        /// <summary>
        /// 文件名（包含扩展名），不传则从文件流中读取。例如：test.jpg
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 待上传的文件流
        /// </summary>
        public IFormFile File { get; set; }
        /// <summary>
        /// 待上传文件的SHA1值。例如：c64376a0d4677f0d4df563fe23f0c8239a45c17d
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// 链接有效期（分钟）,0则不过期
        /// </summary>
        [DefaultValue(0)]
        public int PeriodMinute { get; set; } = 0;
    }

    public class BaseOwnerTokenInput
    {
        /// <summary>
        /// 文件所有者令牌，此参数通过其它服务获取
        /// </summary>
        [Required]
        public string OwnerToken { get; set; }
    }

    public class UploadFileByRemoteInput : BaseOwnerTokenInput
    {
        /// <summary>
        /// 文件名（包含扩展名），不传则从文件流中读取。例如：test.jpg
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件下载地址
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// 链接有效期（分钟）,0则不过期
        /// </summary>
        [DefaultValue(0)]
        public int PeriodMinute { get; set; } = 0;
    }
}
