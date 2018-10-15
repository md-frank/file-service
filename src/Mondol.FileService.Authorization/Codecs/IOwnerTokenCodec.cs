// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-01-23
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mondol.FileService.Authorization.Codecs
{
    /// <summary>
    /// OwnerToken编解码器
    /// </summary>
    public interface IOwnerTokenCodec
    {
        string Encode(OwnerToken token);
        OwnerToken Decode(string tokenStr);
    }

    public static class OwnerTokenCodecExtensions
    {
        public static bool TryDecode(this IOwnerTokenCodec codec, string tokenStr, out OwnerToken token)
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
