// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-01-23
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Mondol.FileService.Authorization.Options;
using Mondol.Utils;

namespace Mondol.FileService.Authorization.Codecs.Impls
{
    /// <summary>
    /// OwnerToken编解码器
    /// </summary>
    internal class OwnerTokenCodec : IOwnerTokenCodec
    {
        private readonly byte[] _appSecretBytes;
        public const byte CurrentVersion = 2;
        readonly IUrlDataCodec _urlDataCodec;

        public OwnerTokenCodec(IOptions<AuthOption> tokenOpt, IUrlDataCodec urlDataCodec)
        {
            _appSecretBytes = tokenOpt.Value.GetAppSecretBytes();
            _urlDataCodec = urlDataCodec;
        }

        public string Encode(OwnerToken token)
        {
            var ownerTypeBys = NetBitConverter.GetBytes(token.OwnerType);
            var ownerIdBys = NetBitConverter.GetBytes(token.OwnerId);
            var expireTimeBys = GetBytes(token.ExpireTime);


            var lstLen = 1 + ownerTypeBys.Length + ownerIdBys.Length + expireTimeBys.Length;
            var mdatLst = new List<byte>(lstLen);
            mdatLst.Add(CurrentVersion);
            mdatLst.AddRange(ownerTypeBys);
            mdatLst.AddRange(ownerIdBys);
            mdatLst.AddRange(expireTimeBys);
            var mdatBys = mdatLst.ToArray();

            //签名
            var signBys = ArrayUtil.Addition(_appSecretBytes, mdatBys);
            var hashBys = Sha1(signBys);

            //编码成字符串
            var encBys = ArrayUtil.Addition(hashBys, mdatBys);
            return _urlDataCodec.Encode(encBys);
        }

        public OwnerToken Decode(string tokenStr)
        {
            var encBys = _urlDataCodec.Decode(tokenStr);

            //校验签名
            var hashLen = 20;
            var mdatBys = new byte[encBys.Length - hashLen];
            Array.Copy(encBys, hashLen, mdatBys, 0, mdatBys.Length);
            var signBys = ArrayUtil.Addition(_appSecretBytes, mdatBys);
            var hashBys = Sha1(signBys);
            if (!ArrayUtil.Equals(hashBys, 0, encBys, 0, hashLen))
                throw new InvalidDataException("bad sign");

            if (mdatBys[0] != CurrentVersion)
                throw new NotSupportedException("bad token version");

            //解析成对象
            var index = 1; //忽略版本
            var ownerType = NetBitConverter.ToInt32(mdatBys, index);
            index += 4;
            var ownerId = NetBitConverter.ToInt32(mdatBys, index);
            index += 4;
            var expireTime = ToDateTime(mdatBys, index);

            return new OwnerToken
            {
                OwnerType = ownerType,
                OwnerId = ownerId,
                ExpireTime = expireTime
            };
        }

        private static byte[] GetBytes(DateTime dt)
        {
            return NetBitConverter.GetBytes(DateTimeUtil.DateTimeToUnixTimestamp(dt));
        }

        private static DateTime ToDateTime(byte[] bytes, int startIndex)
        {
            var l = NetBitConverter.ToInt64(bytes, startIndex);
            return DateTimeUtil.UnixTimestampToDateTime(l);
        }

        private static byte[] Sha1(byte[] bytes)
        {
            return Sha1(bytes, 0, bytes.Length);
        }

        private static byte[] Sha1(byte[] bytes, int offset, int count)
        {
            using (var hashAlgo = SHA1.Create())
            {
                return hashAlgo.ComputeHash(bytes, offset, count);
            }
        }
    }
}
