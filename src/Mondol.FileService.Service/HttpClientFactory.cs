//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using HttpClient = Mondol.Net.Http.HttpClient;

//namespace Mondol.FileService.Service
//{
//    public class HttpClientFactory : IHttpClientFactory
//    {
//        private volatile HttpClient _default;

//        public HttpClient Default => _default ?? (_default = CreateClient());

//        public HttpClient CreateClient()
//        {
//            var hc = new HttpClient(new HttpClientHandler());
//            return hc;
//        }
//    }
//}
