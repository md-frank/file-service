// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-03-17
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mondol.WebPlatform.Swagger
{
    public class XmlCommentManager
    {
        private readonly List<XPathNavigator> _xmlDocs;

        public XmlCommentManager(IOptions<SwaggerGenOptions> options)
        {
            var xmlDocs = GetXmlDocFactories(options.Value);
            _xmlDocs = xmlDocs.Select(p => p().CreateNavigator()).ToList();
        }

        public string GetTypeSummary(string typeFullName)
        {
            foreach (var xmlDoc in _xmlDocs)
            {
                var xnMember = xmlDoc.SelectSingleNode($"/doc/members/member[@name='T:{typeFullName}']");
                if (xnMember != null)
                {
                    var xnSummary = xnMember.SelectSingleNode("summary");
                    return XmlCommentsTextHelper.Humanize(xnSummary.InnerXml);
                }
            }
            return null;
        }

        public IEnumerable<KeyValuePair<string, int>> GetEnumValuesSummary(Type type)
        {
            var lstRetn = new List<KeyValuePair<string, int>>();

            var enumTypeName = type.FullName;
            var xmlDoc = _xmlDocs.FirstOrDefault(p =>
            {
                var xnMember = p.SelectSingleNode($"/doc/members/member[@name='T:{enumTypeName}']");
                return xnMember != null;
            });

            var eVals = Enum.GetValues(type);
            foreach (var eVal in eVals)
            {
                var xnField = xmlDoc?.SelectSingleNode($"/doc/members/member[@name=\'F:{enumTypeName}.{eVal}\']");
                var sStr = xnField != null ? XmlCommentsTextHelper.Humanize(xnField.SelectSingleNode("summary").InnerXml) : eVal.ToString();
                lstRetn.Add(new KeyValuePair<string, int>(sStr, (int)eVal));
            }
            return lstRetn;
        }

        private static IList<Func<XPathDocument>> GetXmlDocFactories(SwaggerGenOptions options)
        {
            var type = options.GetType();
            var fi = type.GetField("_xmlDocFactories", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            return fi.GetValue(options) as IList<Func<XPathDocument>>;
        }
    }
}
