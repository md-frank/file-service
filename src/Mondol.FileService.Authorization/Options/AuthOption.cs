using System;
using System.Collections.Generic;
using System.Text;

namespace Mondol.FileService.Authorization.Options
{
    public class AuthOption
    {
        /// <summary>
        /// 与FileService间通信秘钥
        /// </summary>
        public string AppSecret { get; set; }

        public byte[] GetAppSecretBytes() => Encoding.ASCII.GetBytes(AppSecret);
    }
}
