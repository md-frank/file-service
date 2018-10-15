using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mondol.FileService.Authorization.Codecs.Impls
{
    /// <summary>
    /// URL承载的数据编解码器
    /// </summary>
    public class UrlDataCodecV2 : IUrlDataCodec
    {
        /// <summary>
        /// 容器版本，从1-9, A-Z,a-z 依次递增(ASCII码越来越大)
        /// </summary>
        public const char CurrentVersion = '2';

        private readonly Regex _rexBase64Enc = new Regex(@"[\+/=]", RegexOptions.Singleline | RegexOptions.Compiled);
        private readonly Regex _rexBase64Dec = new Regex(@"[~\-]", RegexOptions.Singleline | RegexOptions.Compiled);

        public string Encode(byte[] data)
        {
            var encStr = System.Convert.ToBase64String(data);
            return CurrentVersion + encStr.Replace('+', '-').Replace('/', '~').TrimEnd('=');
        }

        public byte[] Decode(string encedStr)
        {
            if (encedStr == null || encedStr.Length < 2)
                throw new ArgumentException(nameof(encedStr));
            if (encedStr[0] != CurrentVersion)
                throw new NotSupportedException("bad container version");

            //去掉版本号，从第2个字符开始替换
            encedStr = encedStr.Substring(1);
            encedStr = encedStr.Replace('-', '+').Replace('~', '/');
            if (encedStr.Length % 4 > 0)
            {
                encedStr = encedStr.PadRight(encedStr.Length + (encedStr.Length % 4), '=');
            }

            return System.Convert.FromBase64String(encedStr);
        }
    }
}
