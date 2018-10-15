// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NJsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Mondol.FileService.Service.ServiceImpls
{
    class DefaultJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializer _serializer;

        public DefaultJsonSerializer(IOptions<MvcJsonOptions> options)
        {
            var jss = options.Value.SerializerSettings;
            _serializer = JsonSerializer.Create(jss);
        }

        public void Serialize(TextWriter writer, object value, Type objectType = null)
        {
            using (var jtw = new JsonTextWriter(writer))
            {
                jtw.CloseOutput = false;
                if (objectType == null)
                    _serializer.Serialize(jtw, value);
                else
                    _serializer.Serialize(jtw, value, objectType);
            }
        }

        public object Deserialize(TextReader reader, Type objectType = null)
        {
            using (var jtr = new JsonTextReader(reader))
            {
                jtr.CloseInput = false;
                return objectType == null ? _serializer.Deserialize(jtr) : _serializer.Deserialize(jtr, objectType);
            }
        }
    }
}
