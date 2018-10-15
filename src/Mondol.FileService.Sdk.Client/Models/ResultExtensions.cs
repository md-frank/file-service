using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mondol.FileService.Models
{
    /// <summary>
    /// IResult的扩展方法
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// 当前结果是否成功？
        /// </summary>
        public static bool IsSuccess(this IResult result) => result.ErrorCode == ResultErrorCodes.Success;
    }
}
