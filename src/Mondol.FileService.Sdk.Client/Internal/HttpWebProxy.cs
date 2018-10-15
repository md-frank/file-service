using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Mondol.FileService
{
    internal class HttpWebProxy : IWebProxy
    {
        private readonly Uri _uri;

        public HttpWebProxy(string host, int port)
        {
            _uri = new Uri($"http://{host}:{port}");
        }

        public Uri GetProxy(Uri destination)
        {
            return _uri;
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        public ICredentials Credentials { get; set; }
    }
}
