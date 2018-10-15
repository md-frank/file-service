using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mondol.FileService.Authorization.Codecs.Impls
{
    /// <summary>
    /// IUrlDataCodec兼容新旧版本的实现
    /// </summary>
    public class UrlDataCompatibilityCodec : IUrlDataCodec
    {
        private readonly IUrlDataCodec _codecV1 = new UrlDataCodecV1();
        private readonly IUrlDataCodec _codecV2 = new UrlDataCodecV2();

        public string Encode(byte[] data)
        {
            return _codecV2.Encode(data);
        }

        public byte[] Decode(string encedStr)
        {
            if (encedStr == null || encedStr.Length < 2)
                throw new ArgumentException(nameof(encedStr));
            if (encedStr[0] == UrlDataCodecV1.CurrentVersion)
                return _codecV1.Decode(encedStr);
            else
                return _codecV2.Decode(encedStr);
        }
    }
}
