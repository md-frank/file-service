using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mondol.FileService
{
    /// <summary>
    /// API传输通道接口定义
    /// </summary>
    public interface IApiChannel : IDisposable
    {
        IWebProxy Proxy { get; set; }

        /// <summary>
        /// 调用API并获取返回结果的流
        /// </summary>
        Task<TextReader> GetTextReaderAsync(HttpMethod method, string apiPath, HttpContent reqContent = null);
    }
}
