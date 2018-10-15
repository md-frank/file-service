// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-13
// 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Mondol.FileService.Db.Repositories;
using Mondol.FileService.Service.Options;
using Mondol.FileService.Service.Models;

namespace Mondol.FileService.Service.ServiceImpls
{
    /// <summary>
    /// 原始文件处理器
    /// </summary>
    public class RawFileHandler : IFileHandler
    {
        private readonly IOptionsMonitor<GeneralOption> _options;
        private readonly IRepositoryAccessor _repoAccessor;

        public RawFileHandler(IOptionsMonitor<GeneralOption> options, IRepositoryAccessor repoAccessor)
        {
            _options = options;
            _repoAccessor = repoAccessor;
        }

        public string Name => "raw";
        public IModifierDescribe ModifierDescribe { get; } = new RawModifierDescribe();

        public async Task<IActionResult> HandleAsync(FileHandleContext context)
        {
            if (!System.IO.File.Exists(context.SourcePath))
                return new NotFoundResult();

            string fileName = null;
            if (_options.CurrentValue.QueryFileName)
                fileName = await FileRepository.GetFileNameByIdAsync(context.FileToken.PseudoId, context.FileToken.FileOwnerId);
            return new PhysicalFileResult(context.SourcePath, context.SourceMime.ContentType)
            {
                FileDownloadName = fileName
            };
        }

        private IFileRepository FileRepository => _repoAccessor.GetRequiredRepository<IFileRepository>();
    }
}
