using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Options;

namespace Mondol.FileService.Server
{
    /// <summary>
    /// 默认IHttpClientFactory实现
    /// </summary>
    public class DefaultHttpClientFactory : IHttpClientFactory
    {
        private readonly IServiceProvider _services;
        private readonly IOptions<HttpClientFactoryOptions> _opts;
        private readonly ConcurrentDictionary<string, HttpMessageHandler> _activeHandlers;

        public DefaultHttpClientFactory(IServiceProvider services, IOptions<HttpClientFactoryOptions> opts)
        {
            _services = services;
            _opts = opts;
            _activeHandlers = new ConcurrentDictionary<string, HttpMessageHandler>(StringComparer.Ordinal);
        }

        public HttpClient CreateClient(string name)
        {
            if (name == null)
                name = _opts.Value.HttpClientName;

            var opts = _opts.Value;
            if (opts.OnCreateClient != null)
            {
                return opts.OnCreateClient(name, _services);
            }

            var handler = _activeHandlers.GetOrAdd(name, key => opts.OnCreateHandler != null ? opts.OnCreateHandler(key, _services) : new System.Net.Http.HttpClientHandler());
            var client = new HttpClient(handler, disposeHandler: false);

            return client;
        }
    }
}
