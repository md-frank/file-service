using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mondol.WebPlatform.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 截止Swashbuckle 1.0.0-rc3
    /// 修复 如果参数是枚举类型并且未写参数注释则使用枚举的注释
    /// 修复 枚举取值加上键/值说明
    /// </summary>
    public class FixEnumOperationFilter : IDocumentFilter, IOperationFilter
    {
        private readonly XmlCommentManager _xmlCommentMgr;

        public FixEnumOperationFilter(XmlCommentManager xmlCommentMgr)
        {
            _xmlCommentMgr = xmlCommentMgr;
        }

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var dict = new Dictionary<Schema, object>();
            FixEnums(swaggerDoc.Definitions.Values, dict);
        }

        public void Apply(Operation operation, OperationFilterContext context)
        {
            foreach (var pd in context.ApiDescription.ParameterDescriptions)
            {
                IParameter op;
                Type enumType = null;
                if ((enumType = GetRealEnumType(pd.Type)) != null &&
                    (op = operation.Parameters.FirstOrDefault(p => p.Name.Equals(pd.Name, StringComparison.OrdinalIgnoreCase))) != null)
                {
                    if (string.IsNullOrWhiteSpace(op.Description))
                        op.Description = _xmlCommentMgr.GetTypeSummary(enumType.FullName);

                    var eVals = _xmlCommentMgr.GetEnumValuesSummary(enumType);
                    op.Description += "\r\n" + string.Join(" | ", eVals.Select(p => $"{p.Value} - {p.Key}"));
                    //var ops = (PartialSchema)op;
                    ////ops.Enum = eVals.Select(p => $"{p.Value} - {p.Key}" as object).ToList();
                }
            }
        }

        private Type GetRealEnumType(Type type)
        {
            if (type == null)
                return null;

            var tInfo = type.GetTypeInfo();
            if (tInfo.IsArray)
            {
                type = tInfo.GetElementType();
            }
            else if (tInfo.IsGenericType)
            {
                //Nullable<>, IEnumerable<>
                type = tInfo.GetGenericArguments().First();
            }

            tInfo = type.GetTypeInfo();
            return tInfo.IsEnum ? type : null;
        }

        private void FixEnums(IEnumerable<Schema> schemas, Dictionary<Schema, object> dictExclude)
        {
            foreach (var schema in schemas)
            {
                if (!dictExclude.ContainsKey(schema))
                {
                    dictExclude[schema] = null;

                    if (schema.Enum?.Any() ?? false)
                    {
                        var enumType = schema.Enum.First().GetType();
                        var eVals = _xmlCommentMgr.GetEnumValuesSummary(enumType);
                        schema.Description += "\r\n" + string.Join(" | ", eVals.Select(p => $"{p.Value} - {p.Key}"));
                    }

                    if (schema.Properties?.Values?.Any() ?? false)
                        FixEnums(schema.Properties.Values, dictExclude);
                }
            }
        }
    }
}
