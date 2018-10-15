using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 截止Swashbuckle 2.2.0
    /// 
    /// 修复 调用接口时请求Content-Type为undefined
    /// </summary>
    public class FixContentTypeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            //if (operation.Parameters.Any(x => x is NonBodyParameter && ((NonBodyParameter) x).Type == "file"))
            //{
            //    operation.Consumes = new[] {"application/x-www-form-urlencoded"};
            //}
            //else
            {
                operation.Consumes = new[] { "application/x-www-form-urlencoded" };
            }
        }
    }
}
