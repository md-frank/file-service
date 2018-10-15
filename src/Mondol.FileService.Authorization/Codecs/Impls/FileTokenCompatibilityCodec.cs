using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mondol.FileService.Authorization.Codecs.Impls
{
    /// <summary>
    /// IFileTokenCodec兼容旧版本的实现
    /// </summary>
    public class FileTokenCompatibilityCodec : IFileTokenCodec
    {
        public FileTokenCompatibilityCodec()
        {
        }

        public FileToken Decode(string tokenStr)
        {
            throw new NotImplementedException();
        }

        public string Encode(FileToken token)
        {
            throw new NotImplementedException();
        }
    }
}
