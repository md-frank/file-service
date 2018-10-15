using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mondol.FileService.Server.Models.Input
{
    public class UploadFileInput
    {
        public int OwnerType { get; set; }
        public int OwnerId { get; set; }
        /// <summary>
        /// 文件名（包含扩展名），不传则从文件流中读取。例如：test.jpg
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 待上传的文件流
        /// </summary>
        public Stream File { get; set; }
        /// <summary>
        /// 待上传文件的SHA1值。例如：c64376a0d4677f0d4df563fe23f0c8239a45c17d
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// 链接有效期（分钟）,0则不过期
        /// </summary>
        public int PeriodMinute { get; set; } = 0;
    }
}
