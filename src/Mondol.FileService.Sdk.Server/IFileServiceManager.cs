using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Mondol.FileService.Server.Models.Output;
using Mondol.FileService.Service.Models.Output;

namespace Mondol.FileService.Server
{
    /// <summary>
    /// 文件服务器管理接口
    /// </summary>
    public interface IFileServiceManager
    {
        /// <summary>
        /// 生成所有者访问令牌
        /// </summary>
        /// <param name="ownerType">所有者类型</param>
        /// <param name="ownerId">所有者ID</param>
        /// <param name="validTime">有效期</param>
        string GenerateOwnerTokenString(int ownerType, int ownerId, TimeSpan validTime);

        /// <summary>
        /// 设置指定用户的配额信息
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="max">最大配额数（字节）</param>
        Task<Result> SetOwnerQuotaAsync(int ownerType, int ownerId, ulong max);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="periodMinute">链接有效期（分钟）,0则不过期</param>
        Task<DataResult<UploadResultData>> UploadAsync(int ownerType, int ownerId, string filePath,
            int periodMinute = 0);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="file">文件路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="hash">哈希</param>
        /// <param name="periodMinute">链接有效期（分钟）,0则不过期</param>
        Task<DataResult<UploadResultData>> UploadAsync(int ownerType, int ownerId, Stream file,
            string fileName, string hash = null, int periodMinute = 0);

        /// <summary>
        /// 从远程拉取文件并存储
        /// </summary>
        /// <param name="ownerType">文件所有者类型</param>
        /// <param name="ownerId">文件所有者ID</param>
        /// <param name="fileUrl">文件下载地址</param>
        /// <param name="fileName">文件名</param>
        /// <param name="periodMinute">链接有效期（分钟）,0则不过期</param>
        Task<DataResult<UploadResultData>> UploadByRemoteAsync(int ownerType, int ownerId, string fileUrl, string fileName, int periodMinute = 0);

        /// <summary>
        /// 获取指定文件的信息
        /// </summary>
        /// <param name="fileToken">fileToken</param>
        Task<DataResult<FileDetailData>> GetFileInfoAsync(string fileToken);

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="fileToken">fileToken</param>
        Task<Result> DeleteFileAsync(string fileToken);
        /// <summary>
        /// 验证文件信息
        /// </summary>
        bool VerifyFileInfo(IEnumerable<KeyValuePair<string, object>> values, string sign);
    }
}