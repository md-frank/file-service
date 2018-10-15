using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mondol.FileService.Models
{
    /// <summary>
    /// IResult操作结果错误代码，100以下系统保留,100及以上为特定接口的定义
    /// </summary>
    public class ResultErrorCodes
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        public const int Success = 0;
        /// <summary>
        /// 未知错误
        /// </summary>
        public const int Unknown = 1;
        /// <summary>
        /// 操作失败
        /// </summary>
        public const int Failure = 2;
        /// <summary>
        /// 参数错误
        /// </summary>
        public const int ArgumentBad = 3;
        /// <summary>
        /// 系统错误
        /// </summary>
        public const int SystemError = 4;
        /// <summary>
        /// 未授权的访问
        /// </summary>
        public const int Unauthorized = 5;
    }
}
