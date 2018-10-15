// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Mondol.AutoReview.AspNetCore;
using Mondol.AutoReview.AspNetCore.Asserts;
using Mondol.FileService.Authorization;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Authorization.Codecs.Impls;
using Mondol.FileService.Authorization.Options;
using Mondol.FileService.Db;
using Mondol.FileService.Db.Options;
using Mondol.FileService.Filters;
using Mondol.FileService.Options;
using Mondol.FileService.Service.Options;
using Mondol.FileService.Service;
using Mondol.FileService.Service.ServiceImpls;
using Mondol.FileService.Web.Options;
using Mondol.WebPlatform.Swagger;
using Mondol.WebPlatform;
using Newtonsoft.Json;
using NLog.Extensions.Logging;

namespace Mondol.FileService
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _cfg;

        public Startup(IConfiguration cfg, IHostingEnvironment env)
        {
            _cfg = cfg;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ServiceConfigure.AddAuthorization(services, opt =>
            {
                opt.AppSecret = _cfg["General:AppSecret"];
            });
            
            services.AddSingleton<IFileTokenCodec, FileTokenCodec>();

            services.AddSingleton<IMimeProvider, MimeProvider>();
            services.AddSingleton<ImageSizeProvider>();
            services.AddSingleton<RawFileHandler>();
            services.AddSingleton<ImageFileHandler>();
            services.AddSingleton(svces => new FileHandlerManager(svces));

            //注册内部服务
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //选项
            services.AddOptions();
            services.Configure<ServerOption>(_cfg.GetSection("Server"));
            services.Configure<GeneralOption>(_cfg.GetSection("General"));
            services.Configure<ImageConverterOption>(_cfg.GetSection("ImageConverter"));
            services.Configure<DbOption>(_cfg.GetSection("Db"));
            services.Configure<ManageOption>(_cfg.GetSection("Manage"));
            services.Configure<ClusterOption>(_cfg.GetSection("Cluster"));

            #region UEditor

            services.AddSingleton<UEditorOption>();

            #endregion

            services.AddMvc(opt =>
            {
                opt.Filters.Add<ValidateModelAttribute>();
            }).AddJsonOptions(opt =>
            {
                var setts = opt.SerializerSettings;
                setts.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                setts.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                setts.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAny", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            });

            if (_env.IsDevelopment())
                services.AddSwaggerService(PlatformServices.Default.Application.ApplicationBasePath);
            
            //确保服务依赖的正确性，放到所有注册服务代码后调用
            if (_env.IsDevelopment())
            {
                services.AddAutoReview(
                    new DependencyInjectionAssert()
                    {
                        IgnoreTypes = new[]
                        {
                            "Microsoft.AspNetCore.Mvc.Razor.Internal.TagHelperComponentManager",
                            "Microsoft.Extensions.DependencyInjection.IServiceScopeFactory",
                            "Lwzx.Mengchu.Service.ServiceManager"
                        }
                    }
                );
            }
#if DEBUG_
            var serviceList = services.Dump();
            System.Diagnostics.Debugger.Break();
#endif
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwaggerService();
            }
            else
            {
                app.UseExceptionHandler(new GlobalExceptionHandlerOptions());
            }
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
            app.UseStatusCodePages("text/html", "<div>There is a problem with the page you're visiting, StatusCode: {0}</div>");
        }        
    }
}
