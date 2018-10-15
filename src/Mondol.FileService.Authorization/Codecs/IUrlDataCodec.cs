using System;
using System.Collections.Generic;
using System.Text;

namespace Mondol.FileService.Authorization.Codecs
{
    /// <summary>
    /// URL承载的数据编解码器
    /// </summary>
    public interface IUrlDataCodec
    {
        string Encode(byte[] data);
        byte[] Decode(string encedStr);
    }
}
