using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Mondol.WebPlatform;

namespace Mondol.Extensions.Logging
{
    public static class NLogLoggerFactoryExtensions
    {
        public static void AddNLog(this ILoggingBuilder logBuilder, IHostingEnvironment env, IConfiguration config)
        {
            logBuilder.Services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();
            LoadLogManager(env, config);
        }

        public static void AddNLog(this ILoggerFactory logFac, IHostingEnvironment env, IConfiguration config)
        {
            logFac.AddNLog();

            LoadLogManager(env, config);
        }

        private static void LoadLogManager(IHostingEnvironment env, IConfiguration config)
        {
            /*ConfigureNLog()会忽略异常，此处手动设置*/
            //env.ConfigureNLog("nlog.config");

            var nlogCfgFile = Path.Combine(env.GetConfigPath(), $"nlog.{env.EnvironmentName}.config");
            if (!File.Exists(nlogCfgFile))
                nlogCfgFile = Path.Combine(env.GetConfigPath(), "nlog.config");

            var logsDir = config["Logging:LogsDir"];
            if (string.IsNullOrEmpty(logsDir))
                logsDir = Path.Combine(env.ContentRootPath, "logs");

            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(nlogCfgFile, false);
            NLog.LogManager.Configuration.Variables["logs-dir"] = logsDir;
        }
    }
}
