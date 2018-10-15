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
    internal class UrlDataCodecV1 : IUrlDataCodec
    {
        /// <summary>
        /// 容器版本，从1-9, A-Z,a-z 依次递增(ASCII码越来越大)
        /// </summary>
        public const char CurrentVersion = '1';

        private readonly Regex _rexBase64Enc = new Regex(@"[\+/=]", RegexOptions.Singleline | RegexOptions.Compiled);
        private readonly Regex _rexBase64Dec = new Regex(@"[_~\-]", RegexOptions.Singleline | RegexOptions.Compiled);

        public string Encode(byte[] data)
        {
            var encStr = System.Convert.ToBase64String(data);
            return CurrentVersion + _rexBase64Enc.Replace(encStr, m =>
            {
                switch (m.Value)
                {
                    case "+":
                        return "_";
                    case "/":
                        return "~";
                    case "=":
                        return "-";
                    default:
                        throw new InvalidOperationException();
                }
            });
        }

        public byte[] Decode(string encedStr)
        {
            if (encedStr?.Length < 2)
                throw new ArgumentException(nameof(encedStr));
            if (encedStr[0] != CurrentVersion)
                throw new NotSupportedException("bad container version");

            //去掉版本号，从第2个字符开始替换
            encedStr = _rexBase64Dec.Replace(encedStr, m =>
            {
                switch (m.Value)
                {
                    case "_":
                        return "+";
                    case "~":
                        return "/";
                    case "-":
                        return "=";
                    default:
                        throw new InvalidOperationException();
                }
            });

            return System.Convert.FromBase64String(encedStr.Substring(1));
        }
    }
}
