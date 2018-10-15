using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mondol.FileService.Service;
using Mondol.FileService.Web.Options;
using Mondol.WebPlatform;
using Newtonsoft.Json;
using ControllerBase = Mondol.FileService.Controllers.ControllerBase;

namespace Mondol.FileService.Web.Controllers.UEditor
{
    /// <summary>
    /// UEditor API控制器
    /// </summary>
    [Route("~/ueditor")]
    [EnableCors("AllowAny")]
    public partial class UEditorController : ControllerBase
    {
        private readonly UEditorOption _editorOpts;
        private readonly FileUploadService _fileUpdSvce;

        public UEditorController(UEditorOption editorOpts, FileUploadService fileUpdSvce)
        {
            _editorOpts = editorOpts;
            _fileUpdSvce = fileUpdSvce;
        }

        [Route("api")]
        public async Task<IActionResult> Action([FromQuery]string action)
        {
            switch (action)
            {
                case "config":
                    return GetActionResult(_editorOpts.Items);
                case "uploadimage":
                    return await OnUploadHandleAsync(new UploadConfig()
                    {
                        AllowExtensions = _editorOpts.GetStringList("imageAllowFiles"),
                        PathFormat = _editorOpts.GetString("imagePathFormat"),
                        SizeLimit = _editorOpts.GetInt("imageMaxSize"),
                        UploadFieldName = _editorOpts.GetString("imageFieldName")
                    });
                case "uploadscrawl":
                    return await OnUploadHandleAsync(new UploadConfig()
                    {
                        AllowExtensions = new string[] { ".png" },
                        PathFormat = _editorOpts.GetString("scrawlPathFormat"),
                        SizeLimit = _editorOpts.GetInt("scrawlMaxSize"),
                        UploadFieldName = _editorOpts.GetString("scrawlFieldName"),
                        Base64 = true,
                        Base64Filename = "scrawl.png"
                    });
                case "uploadvideo":
                    return await OnUploadHandleAsync(new UploadConfig()
                    {
                        AllowExtensions = _editorOpts.GetStringList("videoAllowFiles"),
                        PathFormat = _editorOpts.GetString("videoPathFormat"),
                        SizeLimit = _editorOpts.GetInt("videoMaxSize"),
                        UploadFieldName = _editorOpts.GetString("videoFieldName")
                    });
                case "uploadfile":
                    return await OnUploadHandleAsync(new UploadConfig()
                    {
                        AllowExtensions = _editorOpts.GetStringList("fileAllowFiles"),
                        PathFormat = _editorOpts.GetString("filePathFormat"),
                        SizeLimit = _editorOpts.GetInt("fileMaxSize"),
                        UploadFieldName = _editorOpts.GetString("fileFieldName")
                    });
                //case "listimage":
                //    action = new ListFileManager(context, _editorOpts.GetString("imageManagerListPath"), _editorOpts.GetStringList("imageManagerAllowFiles"));
                //    break;
                //case "listfile":
                //    action = new ListFileManager(context, _editorOpts.GetString("fileManagerListPath"), _editorOpts.GetStringList("fileManagerAllowFiles"));
                //    break;
                //case "catchimage":
                //    return OnCatchHandle(null);
                default:
                    return GetActionResult(new { State = "Unsupported operations" });
            }
        }

        private IActionResult GetActionResult(object response)
        {
            var jsonpCallback = Request.Query["callback"];
            var json = JsonConvert.SerializeObject(response);
            if (string.IsNullOrWhiteSpace(jsonpCallback))
            {
                return Content(json, "text/plain");
            }
            else
            {
                json = string.Format("{0}({1});", jsonpCallback, json);
                return Content(json, "application/javascript");
            }
        }

        private string GetParam(string key)
        {
            var val = Request.Query[key];
            if (string.IsNullOrEmpty(val))
                val = Request.Form[key];
            return val;
        }
    }
}
