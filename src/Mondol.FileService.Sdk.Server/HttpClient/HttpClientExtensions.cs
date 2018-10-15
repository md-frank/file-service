using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mondol.FileService.Server
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializer Serializer;

        static HttpClientExtensions()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = 0,
                DateFormatHandling = 0,
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK"
            };
            Serializer = JsonSerializer.Create(jsonSerializerSettings);
        }

        public static async Task<Stream> GetStreamAsync(this HttpClient _, HttpMethod method, string apiPath, HttpContent reqContent)
        {
            using (var reqMsg = new HttpRequestMessage(method, apiPath))
            {
                reqMsg.Content = reqContent;

                var rspMsg = await _.SendAsync(reqMsg);

                rspMsg.EnsureSuccessStatusCode();

                var rspStream = await rspMsg.Content.ReadAsStreamAsync();
                return new HttpResponseMessageDelayDisposeStream(rspStream, rspMsg);
            }
        }

        public static async Task<TextReader> GetTextReaderAsync(this HttpClient _, HttpMethod method, string apiPath, HttpContent reqContent = null)
        {
            using (var reqMsg = new HttpRequestMessage(method, apiPath))
            {
                reqMsg.Content = reqContent;
                var rspMsg = await _.SendAsync(reqMsg);

                rspMsg.EnsureSuccessStatusCode();

                var rspStream = await rspMsg.Content.ReadAsStreamAsync();
                return new HttpResponseMessageDelayDisposeStreamReader(rspStream, rspMsg);
            }
        }

        public static async Task<JObject> GetJObjectAsync(this HttpClient _, HttpMethod method, string apiPath, HttpContent reqContent = null)
        {
            using (var rspStream = await _.GetTextReaderAsync(method, apiPath, reqContent))
            {
                return await JObject.LoadAsync(new JsonTextReader(rspStream));
            }
        }

        /// <summary>
        /// 取返回结果的
        /// </summary>
        public static async Task<TResult> GetResultAsync<TResult>(this HttpClient _, HttpMethod method, string apiPath, HttpContent reqContent = null)
        {
            using (var rspStream = await _.GetTextReaderAsync(method, apiPath, reqContent))
            {
                return Serializer.Deserialize<TResult>(new JsonTextReader(rspStream));
            }
        }

        /// <summary>
        /// 延迟释放HttpResponseMessage流
        /// </summary>
        private class HttpResponseMessageDelayDisposeStream : Stream
        {
            private readonly Stream _stream;
            private readonly HttpResponseMessage _rspMsg;

            public HttpResponseMessageDelayDisposeStream(Stream stream, HttpResponseMessage rspMsg)
            {
                _stream = stream;
                _rspMsg = rspMsg;
            }

            protected override void Dispose(bool disposing)
            {
                _rspMsg.Dispose();
                base.Dispose(disposing);
            }

            public override void Flush()
            {
                _stream.Flush();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _stream.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _stream.Read(buffer, offset, count);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                _stream.Write(buffer, offset, count);
            }

            public override bool CanRead => _stream.CanRead;

            public override bool CanSeek => _stream.CanSeek;

            public override bool CanWrite => _stream.CanWrite;

            public override long Length => _stream.Length;

            public override long Position
            {
                get => _stream.Position;
                set => _stream.Position = value;
            }
        }

        /// <summary>
        /// 延迟释放HttpResponseMessage的流
        /// 因为HttpResponseMessage释放后Content也会释放
        /// </summary>
        private class HttpResponseMessageDelayDisposeStreamReader : StreamReader
        {
            private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false, true);

            private readonly HttpResponseMessage _rspMsg;

            public HttpResponseMessageDelayDisposeStreamReader(Stream stream, HttpResponseMessage rspMsg)
                : base(stream, Utf8NoBom)
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
