// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2017-03-17
// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Mondol.WebPlatform.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 截止Swashbuckle 1.0.0-rc3
    /// 修复 值类型并且没有DefaultValueAttribute属性的都为必选
    /// 修复 标记了Required标记的属性不好使的问题
    /// </summary>
    public class FixRequiredOperationFilter : IDocumentFilter, IOperationFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            //var dict = new Dictionary<Schema, object>();
            //ForEachResponseParams(swaggerDoc.Definitions.Values, dict);
        }

        public void Apply(Operation operation, OperationFilterContext context)
        {
            foreach (var pd in context.ApiDescription.ParameterDescriptions)
            {
                var op = GetIParameterByName(operation, pd.Name);
                if (!(op?.Required ?? false) && ShouldRequired(pd))
                {
                    op.Required = true;
                }
            }
        }

        private bool ShouldRequired(ApiParameterDescription pd)
        {
            var pProps = (pd.ModelMetadata as DefaultModelMetadata)?.Attributes?.PropertyAttributes;
            var hasRequired = pProps?.Any(p => p.GetType() == typeof(RequiredAttribute)) ?? false;
            if (hasRequired)
            {
                return true;
            }
            else
            {
                var hasDefVal = pProps?.Any(p => p.GetType() == typeof(DefaultValueAttribute)) ?? false;
                var type = pd.Type.GetTypeInfo();
                if (!hasDefVal && (type.IsEnum || type.IsPrimitive))
                    return true;
                return false;
            }
        }

        private IParameter GetIParameterByName(Operation operation, string name)
        {
            return operation.Parameters.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private void ForEachResponseParams(IEnumerable<Schema> schemas, Dictionary<Schema, object> dictExclude)
        {
            foreach (var schema in schemas)
            {
                if (!dictExclude.ContainsKey(schema))
                {
                    dictExclude[schema] = null;

                    //if (schema.Enum?.Any() ?? false)
                    //{
                    //    var enumType = schema.Enum.First().GetType();
                    //    var eVals = _xmlCommentMgr.GetEnumValuesSummary(enumType);
                    //    schema.Enum = eVals.Select(p => $"{p.Value} - {p.Key}" as object).ToList();
                    //}

                    //if (schema.Properties?.Values?.Any() ?? false)
                    //    FixEnums(schema.Properties.Values, dictExclude);
                }
            }
        }
    }
}
