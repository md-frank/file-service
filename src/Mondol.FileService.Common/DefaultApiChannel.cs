using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mondol.FileService
{
    public class DefaultApiChannel : IApiChannel
    {
        private readonly string _host;
        private readonly HttpClient _httpClient;
        private readonly HttpClientHandler _hcHandler;

        public DefaultApiChannel(string host)
        {
            if (host.EndsWith("/"))
                throw new ArgumentException("host 不能以/结尾");

            _host = host;
            _hcHandler = new HttpClientHandler()
            {
                UseCookies = true
            };
            _httpClient = new HttpClient(_hcHandler);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            _hcHandler?.Dispose();
        }

        public IWebProxy Proxy
        {
            get => _hcHandler.Proxy;
            set
            {
                _hcHandler.UseProxy = value != null;
                _hcHandler.Proxy = value;
            }
        }

        public async Task<TextReader> GetTextReaderAsync(HttpMethod method, string apiPath, HttpContent reqContent = null)
        {
            var url = _host + apiPath;
            using (var reqMsg = new HttpRequestMessage(method, url))
            {
                reqMsg.Content = reqContent;
                var rspMsg = await _httpClient.SendAsync(reqMsg);

                rspMsg.EnsureSuccessStatusCode();

                var rspStream = await rspMsg.Content.ReadAsStreamAsync();
                return new DelayDisposeStream(rspStream, rspMsg);
            }
        }

        /// <summary>
        /// 延迟释放HttpResponseMessage的流
        /// 因为HttpResponseMessage释放后Content也会释放
        /// </summary>
        private class DelayDisposeStream : StreamReader
        {
            private static readonly UTF8Encoding UTF8NoBOM = new UTF8Encoding(false, true);

            private readonly HttpResponseMessage _rspMsg;

            public DelayDisposeStream(Stream stream, HttpResponseMessage rspMsg)
                :base(stream, UTF8NoBOM)
            {
                _rspMsg = rspMsg;
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                _rspMsg.Dispose();
            }
        }        
    }
}
