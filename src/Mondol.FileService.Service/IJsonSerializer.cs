// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.IO;
using System.Text;

namespace Mondol.FileService.Service
{
    /// <summary>
    /// JSON序列化器
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// 序列化对象到流中
        /// </summary>
        /// <param name="writer">输出流</param>
        /// <param name="value">待序列化的对象</param>
        /// <param name="objectType">对象类型（当使用基类时）</param>
        void Serialize(TextWriter writer, object value, Type objectType = null);

        /// <summary>
        /// 从流中反序列化对象
        /// </summary>
        /// <param name="reader">已序列化的流</param>
        /// <param name="objectType">对象类型（当使用基类时）</param>
        object Deserialize(TextReader reader, Type objectType = null);
    }

    public static class JsonSerializerExtensions
    {
        public static string SerializeToString(this IJsonSerializer serializer, object value, Type objectType = null)
        {
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, value, objectType);
                return sw.ToString();
            }
        }

        public static object DeserializeFromString(this IJsonSerializer serializer, string jsonStr, Type objectType = null)
        {
            using (var sr = new StringReader(jsonStr))
            {
                return serializer.Deserialize(sr, objectType);
            }
        }

        public static T DeserializeFromString<T>(this IJsonSerializer serializer, string jsonStr)
        {
            return (T)serializer.DeserializeFromString(jsonStr, typeof(T));
        }

        public static string SerializeToBase64String(this IJsonSerializer serializer, object value, Type objectType = null)
        {
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms, Encoding.UTF8))
                {
                    serializer.Serialize(sw, value, objectType);
                }

                return System.Convert.ToBase64String(ms.ToArray());
            }
        }

        public static object DeserializeFromBase64String(this IJsonSerializer serializer, string base64Str, Type objectType = null)
        {
            var jsonBys = System.Convert.FromBase64String(base64Str);
            using (var ms = new MemoryStream(jsonBys, false))
            {
                using (var sr = new StreamReader(ms, Encoding.UTF8))
                {
                    return serializer.Deserialize(sr, objectType);
                }
            }
        }

        public static T DeserializeFromBase64String<T>(this IJsonSerializer serializer, string jsonStr)
        {
            return (T)serializer.DeserializeFromBase64String(jsonStr, typeof(T));
        }
    }
}