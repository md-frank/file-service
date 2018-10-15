//// Copyright (c) Mondol. All rights reserved.
//// 
//// Author:  frank
//// Email:   frank@mondol.info
//// Created: 2016-11-17
//// 
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Security.Cryptography;
//using Microsoft.Extensions.Options;
//using Mondol.FileService.Codecs;
//using Mondol.FileService.Options;
//using Mondol.FileService.Service.Models;
//using Mondol.Utils;

//namespace Mondol.FileService.Codecs.Impls
//{
//    public class FileTokenV1Codec : IFileTokenCodec
//    {
//        private readonly IOptionsMonitor<GeneralOption> _generalOption;
//        public const byte CurrentVersion = 1;

//        public FileTokenV1Codec(IOptionsMonitor<GeneralOption> generalOption)
//        {
//            _generalOption = generalOption;
//        }

//        public string Encode(FileToken token)
//        {
//            var pseudoIdBys = NetBitConverter.GetBytes(token.PseudoId);
//            var fileIdBys = NetBitConverter.GetBytes(token.FileId);
//            var ownerIdBys = NetBitConverter.GetBytes(token.FileOwnerId);
//            var mimeBys = NetBitConverter.GetBytes(token.MimeId);
//            var expireTimeBys = GetBytes(token.ExpireTime);
//            var fileCreateTimeBys = GetBytes(token.FileCreateTime);

//            var lstLen = 1 + pseudoIdBys.Length + fileIdBys.Length + ownerIdBys.Length + mimeBys.Length + expireTimeBys.Length + fileCreateTimeBys.Length;
//            var mdatLst = new List<byte>(lstLen);
//            mdatLst.Add(CurrentVersion);
//            mdatLst.AddRange(pseudoIdBys);
//            mdatLst.AddRange(fileIdBys);
//            mdatLst.AddRange(ownerIdBys);
//            mdatLst.AddRange(mimeBys);
//            mdatLst.AddRange(expireTimeBys);
//            mdatLst.AddRange(fileCreateTimeBys);

//            var mdatBys = mdatLst.ToArray();

//            //签名
//            var signBys = ArrayUtil.Addition(_generalOption.CurrentValue.GetAppSecretBytes(), mdatBys);
//            var hashBys = Md5(signBys);

//            //编码成字符串
//            var encBys = ArrayUtil.Addition(hashBys, mdatBys);
//            var encStr = System.Convert.ToBase64String(encBys);
//            encStr = encStr.Replace('+', '-').Replace('/', '_').Replace('=', '.');

//            return encStr;
//        }

//        public FileToken Decode(string tokenStr)
//        {
//            if (string.IsNullOrEmpty(tokenStr))
//                throw new ArgumentNullException(nameof(tokenStr));

//            var encStr = tokenStr.Replace('-', '+').Replace('_', '/').Replace('.', '=');
//            var encBys = System.Convert.FromBase64String(encStr);

//            //校验签名
//            var hashLen = 16;
//            var mdatBys = new byte[encBys.Length - hashLen];
//            Array.Copy(encBys, hashLen, mdatBys, 0, mdatBys.Length);
//            var signBys = ArrayUtil.Addition(_generalOption.CurrentValue.GetAppSecretBytes(), mdatBys);
//            var hashBys = Md5(signBys);
//            if (!ArrayUtil.Equals(hashBys, 0, encBys, 0, hashLen))
//                throw new InvalidDataException("bad sign");

//            //解析成对象
//            var index = 1; //忽略版本
//            var pseudoId = NetBitConverter.ToUInt32(mdatBys, index);
//            index += 4;
//            var fileId = NetBitConverter.ToInt32(mdatBys, index);
//            index += 4;
//            var ownerId = NetBitConverter.ToInt32(mdatBys, index);
//            index += 4;
//            var mimeId = NetBitConverter.ToUInt32(mdatBys, index);
//            index += 4;
//            var expireTime = ToDateTime(mdatBys, index);
//            index += sizeof(long);
//            var fileCreateTime = ToDateTime(mdatBys, index);

//            return new FileToken
//            {
//                PseudoId = pseudoId,
//                FileId = fileId,
//                FileOwnerId = ownerId,
//                MimeId = mimeId,
//                ExpireTime = expireTime,
//                FileCreateTime = fileCreateTime
//            };
//        }

//        private static byte[] GetBytes(DateTime dt)
//        {
//            return NetBitConverter.GetBytes(dt.ToBinary());
//        }

//        private static DateTime ToDateTime(byte[] bytes, int startIndex)
//        {
//            var l = NetBitConverter.ToInt64(bytes, startIndex);
//            return DateTime.FromBinary(l);
//        }

//        private static byte[] Md5(byte[] bytes)
//        {
//            return Md5(bytes, 0, bytes.Length);
//        }

//        private static byte[] Md5(byte[] bytes, int offset, int count)
//        {
//            using (var hashAlgo = MD5.Create())
//            {
//                return hashAlgo.ComputeHash(bytes, offset, count);
//            }
//        }
//    }
//}
