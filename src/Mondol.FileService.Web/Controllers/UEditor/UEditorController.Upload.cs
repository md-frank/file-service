using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Mondol.FileService.Options;
using Microsoft.Extensions.Logging;

namespace Mondol.FileService.Web.Controllers.UEditor
{
    public partial class UEditorController
    {
        private async Task<IActionResult> OnUploadHandleAsync(UploadConfig updCfg)
        {
            var ownerToken = GetParam("ownerToken");
            Stream fileStream = null;

            try
            {
                string uploadFileName = null;
                if (updCfg.Base64)
                {
                    uploadFileName = updCfg.Base64Filename;
                    var uploadFileBytes = System.Convert.FromBase64String(GetParam(updCfg.UploadFieldName));
                    fileStream = new MemoryStream(uploadFileBytes, false);
                }
                else
                {
                    IFormFile file = null;
                    try
                    {
                        file = Request.Form.Files[updCfg.UploadFieldName];
                    }
                    catch
                    {
                        ;
                    }
                    if (file == null)
                        return GetUploadResult(new UploadResult
                        {
                            State = UploadState.Unknown,
                            ErrorMessage = "Unspecified file"
                        });

                    uploadFileName = file.FileName;
                    fileStream = file.OpenReadStream();

                    if (!CheckFileType(updCfg, uploadFileName))
                    {
                        return GetUploadResult(new UploadResult { State = UploadState.TypeNotAllow });
                    }
                    if (!CheckFileSize(updCfg, file.Length))
                    {
                        return GetUploadResult(new UploadResult { State = UploadState.SizeLimitExceed });
                    }
                }

                var updRs = await _fileUpdSvce.UploadAsync(ownerToken, fileStream, uploadFileName, null, 0);
                return GetUploadResult(new UploadResult
                {
                    State = UploadState.Success,
                    OriginFileName = uploadFileName,
                    Url = updRs.Data.Url + "/raw"
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return GetUploadResult(new UploadResult { State = UploadState.Unknown, ErrorMessage = ex.Message });
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        private IActionResult GetUploadResult(UploadResult result)
        {
            return GetActionResult(new
            {
                state = GetStateMessage(result.State),
                url = result.Url,
                title = result.OriginFileName,
                original = result.OriginFileName,
                error = result.ErrorMessage
            });
        }

        private string GetStateMessage(UploadState state)
        {
            switch (state)
            {
                case UploadState.Success:
                    return "SUCCESS";
                case UploadState.FileAccessError:
                    return "文件访问出错，请检查写入权限";
                case UploadState.SizeLimitExceed:
                    return "文件大小超出服务器限制";
                case UploadState.TypeNotAllow:
                    return "不允许的文件格式";
                case UploadState.NetworkError:
                    return "网络错误";
            }
            return "未知错误";
        }

        private bool CheckFileType(UploadConfig updCfg, string filename)
        {
            var fileExtension = Path.GetExtension(filename).ToLower();
            return updCfg.AllowExtensions.Select(x => x.ToLower()).Contains(fileExtension);
        }

        private bool CheckFileSize(UploadConfig updCfg, long size)
        {
            return size < updCfg.SizeLimit;
        }


        public class UploadConfig
        {
            /// <summary>
            /// 文件命名规则
            /// </summary>
            public string PathFormat { get; set; }

            /// <summary>
            /// 上传表单域名称
            /// </summary>
            public string UploadFieldName { get; set; }

            /// <summary>
            /// 上传大小限制
            /// </summary>
            public int SizeLimit { get; set; }

            /// <summary>
            /// 上传允许的文件格式
            /// </summary>
            public string[] AllowExtensions { get; set; }

            /// <summary>
            /// 文件是否以 Base64 的形式上传
            /// </summary>
            public bool Base64 { get; set; }

            /// <summary>
            /// Base64 字符串所表示的文件名
            /// </summary>
            public string Base64Filename { get; set; }
        }

        public class UploadResult
        {
            public UploadState State { get; set; }
            public string Url { get; set; }
            public string OriginFileName { get; set; }

            public string ErrorMessage { get; set; }
        }

        public enum UploadState
        {
            Success = 0,
            SizeLimitExceed = -1,
            TypeNotAllow = -2,
            FileAccessError = -3,
            NetworkError = -4,
            Unknown = 1,
        }
    }
}
