// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 

namespace Mondol.FileService.Authorization.Codecs
{
    /// <summary>
    /// FileToken编解码器
    /// </summary>
    public interface IFileTokenCodec
    {
        string Encode(FileToken token);
        FileToken Decode(string tokenStr);
    }

    public static class FileTokenCodecExtensions
    {
        public static bool TryDecode(this IFileTokenCodec codec, string tokenStr, out FileToken token)
        {
            try
            {
                token = codec.Decode(tokenStr);
                return true;
            }
            catch
            {
                token = null;
                return false;
            }
        }
    }
}
