using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 截止Swashbuckle 1.0.0
    /// 
    /// 修复 IFormFile类型参数显示为undefined
    /// </summary>
    public class FixFormFileOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var oParams = operation.Parameters;
            foreach (var aParam in context.ApiDescription.ParameterDescriptions)
            {
                if (typeof(IFormFile).IsAssignableFrom(aParam.Type))
                {
                    var pInfo = oParams.First(p => p.Name.Equals(aParam.Name, StringComparison.OrdinalIgnoreCase)) as NonBodyParameter;
                    if (pInfo != null)
                    {
                        pInfo.In = "formData";
                        pInfo.Type = "file";
                    }
                }
            }
        }
    }
}
