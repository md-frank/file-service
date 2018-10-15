// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mondol.Extensions.Logging;
using Mondol.WebPlatform;

namespace Mondol.FileService
{
    public class Program
    {
        private static ILogger _logger;

        public static void Main(string[] args)
        {
            try
            {
                var webHost = BuildWebHost(args);

                var hostEnv = webHost.Services.GetRequiredService<IHostingEnvironment>();
                if (!Directory.Exists(hostEnv.GetConfigPath()))
                {
                    Console.WriteLine("Unable to detect the confs path");
                    return;
                }

                //logger
                var logFac = webHost.Services.GetRequiredService<ILoggerFactory>();
                _logger = logFac.CreateLogger<Program>();

                webHost.Run();

                System.Threading.Tasks.TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static IWebHost BuildWebHost(string[] args)
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostCtx, cfg) =>
                {
                    cfg.AddEnvironmentVariables();
                    if (args != null)
                        cfg.AddCommandLine(args);

                    cfg.SetBasePath(hostCtx.HostingEnvironment.GetConfigPath());

                    var env = hostCtx.HostingEnvironment;
                    cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    cfg.AddJsonFile("image-sizes.json", optional: false, reloadOnChange: true);
                    cfg.AddJsonFile("mimes.json", optional: false, reloadOnChange: true);

                    if (env.IsDevelopment())
                    {
                        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            cfg.AddUserSecrets(appAssembly, optional: true);
                        }
                    }
                })
                .ConfigureLogging((ctx, logging) =>
                {
                    logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddNLog(ctx.HostingEnvironment, ctx.Configuration);
                })
                .UseKestrel(opts =>
                {
                    opts.Limits.MaxRequestBodySize = 524288000;
                })
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .UseSetting(WebHostDefaults.HostingStartupAssembliesKey, BuildHostingStartupAssemblies())
                .UseStartup<Startup>();

            return builder.Build();
        }

        private static string BuildHostingStartupAssemblies()
        {
            return string.Join(";", new[]
            {
                "Mondol.FileService.Db",
                //"Mondol.FileService.Caching",
                "Mondol.FileService.Service"
            });
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, System.Threading.Tasks.UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            _logger.LogError($"{nameof(TaskScheduler_UnobservedTaskException)}: {e.Exception}");
        }
    }
}
