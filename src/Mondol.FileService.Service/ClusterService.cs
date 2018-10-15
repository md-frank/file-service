// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Db.Entities;
using Mondol.FileService.Service.Options;
using Newtonsoft.Json.Linq;
using Mondol.Net.Http;
using HttpClient = Mondol.Net.Http.HttpClient;

namespace Mondol.FileService.Service
{
    /// <summary>
    /// 群集服务
    /// </summary>
    public class ClusterService
    {
        private readonly IFileTokenCodec _fileTokenCodec;
        private readonly IServerElectPolicy _serverElectPolicy;
        private readonly IOptionsMonitor<GeneralOption> _generalOption;
        private readonly IOptionsMonitor<ClusterOption> _option;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpCtxAccessor;

        public ClusterService(IFileTokenCodec fileTokenCodec, IServerElectPolicy serverElectPolicy,
            IOptionsMonitor<ClusterOption> option, IOptionsMonitor<GeneralOption> generalOption, IHttpContextAccessor httpCtxAccessor)
        {
            _fileTokenCodec = fileTokenCodec;
            _serverElectPolicy = serverElectPolicy;
            _generalOption = generalOption;
            _httpCtxAccessor = httpCtxAccessor;
            _option = option;
            _httpClient = new HttpClient();

            CurrentServer = _option.CurrentValue.Servers.First(p => p.Id == _option.CurrentValue.SelfServerId);
        }

        public Service.Options.Server CurrentServer { get; }

        public Service.Options.Server ElectServer()
        {
            return _serverElectPolicy.ElectServer();
        }

        public Service.Options.Server GetServerById(int id)
        {
            return _option.CurrentValue.Servers.First(p => p.Id == id);
        }

        public async Task<bool> RawFileExistsAsync(IStorageService storageSvce, Service.Options.Server server, uint pseudoId, DateTime fileCreateTime, int fileId)
        {
            //如果目标服务器就是当前服务器，则直接移动文件
            if (CurrentServer.Id == server.Id)
            {
                return storageSvce.RawFileExists(pseudoId, fileCreateTime, fileId);
            }
            else
            {
                var fct = Uri.EscapeDataString(fileCreateTime.ToString(CultureInfo.CurrentCulture));
                var url = $"{GetCurrentScheme()}://{server.Host}/api/cluster/files/{fileId}/exists?pseudoId={pseudoId}&fileCreateTime={fct}";

                var rspStr = await _httpClient.GetStringAsync(url);
                var json = JObject.Parse(rspStr);
                var errCode = json.Value<int>("errCode");
                if (errCode != 0 && errCode != 100)
                    throw new InvalidProgramException($"获取文件存在状态：{json.Value<string>("errMsg")}");
                return errCode == 0;
            }
        }

        public async Task SyncFileToServerAsync(IStorageService storageSvce, string filePath, File file, uint pseudoId, Service.Options.Server server)
        {
            //如果目标服务器就是当前服务器，则直接移动文件
            if (CurrentServer.Id == server.Id)
            {
                var realFilePath = storageSvce.GetRawFilePath(pseudoId, file.CreateTime, file.Id);
                await storageSvce.MoveToPathAsync(filePath, realFilePath, true);
            }
            else
            {
                //var fTokenStr = _fileTokenCodec.Encode(fToken);

                //var url = $"{server.Host}/api/cluster/files";
                //var mfdCont = new MultipartFormDataContent();
                //mfdCont.AddByString("fileToken", fTokenStr);
                //mfdCont.AddByFile("file", filePath);

                //var rspMsg = await _httpClient.PostAsync(url, mfdCont);
                //rspMsg.EnsureSuccessStatusCode();
                //var rspStr = await rspMsg.Content.ReadAsStringAsync();
                //var json = JObject.Parse(rspStr);
                //if (json.Value<int>("errCode") != 0)
                //    throw new InvalidProgramException($"同步失败：{json.Value<string>("errMsg")}");
                throw new NotImplementedException();
            }
        }

        public async Task DeleteFileAsync(IStorageService storageSvce, uint pseudoId, DateTime fileCreateTime, int fileId, Service.Options.Server server)
        {
            if (CurrentServer.Id == server.Id)
            {
                await storageSvce.DeleteFileAsync(pseudoId, fileCreateTime, fileId);
            }
            else
            {
                throw new NotImplementedException("暂未实现");
            }
        }

        private string GetCurrentScheme()
        {
            return _httpCtxAccessor.HttpContext?.Request.GetRealScheme() ?? "http";
        }
    }
}
