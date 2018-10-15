using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mondol.FileService.Service.Options
{
    /// <summary>
    /// 图片转换器选项
    /// </summary>
    public class ImageConverterOption
    {
        public string ConverterPath { get; set; }
        /// <summary>
        /// convert的Resize参数
        /// </summary>
        public string ResizeArgs { get; set; }
        /// <summary>
        /// 转换超时（秒）
        /// </summary>
        public int ConvertTimeout { get; set; }
    }
}
