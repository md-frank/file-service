using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mondol.FileService;
using Microsoft.Extensions.DependencyInjection;
using Mondol;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Client;
using Mondol.FileService.Server;

namespace Test.Console
{
    class Program
    {
        static IServiceProvider Service;

        static async Task Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection();
                services.AddOptions();
                services.AddFileService(cfg =>
                {
                    cfg.Host = "fs-dev.l5zx.com";
                    cfg.AppSecret = "{F43D9A20-69DE-45D6-E298-7DACB57B9C10}";
                });

                Service = services.BuildServiceProvider();

                await OnMain();

                System.Console.WriteLine("press key continue...");
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        private static async Task OnMain()
        {
            var hcFac = Service.GetRequiredService<IHttpClientFactory>();
            hcFac.CreateClient();

            var fsMgr = Service.GetRequiredService<IFileServiceManager>();
            var r1 = await fsMgr.GetFileInfoAsync("1cNhV2O0uYuJK6Lr05mcEgQLAgIFNAAAAEQAAABuwzXNfiUXs6lK0MHGI1eMXJQgFbA--");

            var oToken = fsMgr.GenerateOwnerTokenString(1, 1, TimeSpan.FromSeconds(1111));
            var result = await fsMgr.GetFileInfoAsync("fasdfasdf");

            //System.Console.WriteLine(rs.ErrorCode);
        }
    }
}
