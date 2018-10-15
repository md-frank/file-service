using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mondol.FileService.Models
{
    /// <summary>
    /// 操作结果接口定义
    /// </summary>
    public interface IResult
    {
        int ErrorCode { get; set; }
        string ErrorMsg { get; set; }
    }
}