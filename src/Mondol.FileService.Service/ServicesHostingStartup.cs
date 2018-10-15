using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Mondol.FileService.Authorization;
using Mondol.FileService.Service;
using Mondol.FileService.Service.ServiceImpls;

[assembly: HostingStartup(typeof(Mondol.FileService.Service.ServiceHostingStartup))]
namespace Mondol.FileService.Service
{
    /// <summary>
    /// 服务层服务配置
    /// </summary>
    public class ServiceHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IJsonSerializer, DefaultJsonSerializer>();
                services.AddSingleton<ClusterService>();
                services.AddSingleton<IServerElectPolicy, WeightRoundServerElect>();

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    services.AddSingleton<IImageConverter, MagickImageConverter>();
                else
                    services.AddSingleton<IImageConverter, CmdMagickImageConverter>();

                services.AddSingleton<IStorageService, DefaultStorageService>();
                services.AddSingleton<AppSecretSigner>();
                services.AddSingleton<FileUploadService>();
                
                //https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.1
                services.AddHttpClient();
            });
        }
    }
}
