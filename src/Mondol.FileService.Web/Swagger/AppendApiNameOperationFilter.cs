using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Mondol.WebPlatform.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 在接口说明中追加API英文名
    /// </summary>
    public class AppendApiNameOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var actionName = ((ControllerActionDescriptor)context.ApiDescription.ActionDescriptor).ActionName;
            if (actionName.EndsWith("Async"))
                actionName = actionName.Substring(0, actionName.Length - 5);
            operation.Summary = $"{actionName} - {operation.Summary}";
        }
    }
}
