using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 截止Swashbuckle 1.2.1版本控制器类的注释不会显示在类别栏里，此类可以解决
    /// </summary>
    public class FixTagsDocOperationFilter : IOperationFilter
    {
        private readonly XmlCommentManager _xmlCommentMgr;

        public FixTagsDocOperationFilter(XmlCommentManager xmlCommentMgr)
        {
            _xmlCommentMgr = xmlCommentMgr;
        }

        public void Apply(Operation operation, OperationFilterContext context)
        {
            var fullName = ((ControllerActionDescriptor)context.ApiDescription.ActionDescriptor).ControllerTypeInfo.FullName;
            var tagSummary = _xmlCommentMgr.GetTypeSummary(fullName);
            if (!string.IsNullOrEmpty(tagSummary))
            {
                operation.Tags[0] = tagSummary;
            }
        }
    }
}
