// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-19
// 
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Mondol.FileService.Authorization.Options;
using Mondol.Security.Cryptography.Utils;

namespace Mondol.FileService.Authorization
{
    /// <summary>
    /// AppSecret签名器
    /// </summary>
    public class AppSecretSigner
    {
        private readonly IOptions<AuthOption> _opt;

        public AppSecretSigner(IOptions<AuthOption> opt)
        {
            _opt = opt;
        }

        public string Sign(IEnumerable<KeyValuePair<string, object>> values)
        {
            var vals = values.OrderBy(p => p.Key).Select(p => p.Value);
            var appSecret = _opt.Value.AppSecret;
            var signOriStr = $"{appSecret}|{string.Join("|", vals)}";
            return HashUtil.Sha1(signOriStr);
        }

        public bool Verify(IEnumerable<KeyValuePair<string, object>> values, string sign)
        {
            var vals = values.OrderBy(p => p.Key).Select(p => p.Value);
            var appSecret = _opt.Value.AppSecret;
            var signOriStr = $"{appSecret}|{string.Join("|", vals)}";
            return HashUtil.Sha1(signOriStr) == sign;
        }
    }    
}
