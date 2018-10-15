using Mondol.FileService.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mondol.FileService.Client
{
    /// <summary>
    /// 文件服务客户端
    /// </summary>
    public interface IFileServiceClient
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ownerToken">文件所有者令牌</param>
        /// <param name="fileStream">文件流</param>
        /// <param name="fileName">文件名</param>
        /// <param name="periodMinute">有效期（分钟）</param>
        Task<DataResult<FileUploadDataResult>> UploadAsync(string ownerToken, Stream fileStream, string fileName, int periodMinute = 0);
        /// <summary>
        /// 上传文件(通过远程地址)
        /// </summary>
        /// <param name="ownerToken">文件所有者令牌</param>
        /// <param name="uri">文件流</param>
        /// <param name="fileName">文件名</param>
        /// <param name="periodMinute">有效期（分钟）</param>
        Task<DataResult<FileUploadDataResult>> UploadByRemoteAsync(string ownerToken, string uri, string fileName, int periodMinute = 0);
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileToken">上传接口返回的文件访问令牌</param>
        /// <param name="ownerToken">文件所有者令牌</param>
        Task<Result> DeleteAsync(string fileToken, string ownerToken);
    }
}
