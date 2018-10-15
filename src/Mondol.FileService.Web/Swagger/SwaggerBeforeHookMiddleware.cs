using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 用于在Swagger开始生成API前执行代码的Middleware
    /// 
    /// ** 必需放到app.UseSwaggerService() 前 **
    /// </summary>
    public class SwaggerBeforeHookMiddleware
    {
        private readonly RequestDelegate _next;
        private IModelMetadataProvider _mmp;
        private ICompositeMetadataDetailsProvider _cmdp;

        public SwaggerBeforeHookMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            #region 截止Swashbuckle 1.0.0版本参数类型为类数组时，数组不能展开，此方法解决此问题

            _mmp = context.RequestServices.GetRequiredService<IModelMetadataProvider>();
            _cmdp = context.RequestServices.GetRequiredService<ICompositeMetadataDetailsProvider>();

            var apiDescProv = context.RequestServices.GetRequiredService<IApiDescriptionGroupCollectionProvider>();
            var apiDescs = apiDescProv.ApiDescriptionGroups.Items.SelectMany(group => group.Items);
            foreach (var apiDesc in apiDescs)
            {
                var pDels = new List<ApiParameterDescription>();
                var pAdds = new List<ApiParameterDescription>();
                foreach (var apd in apiDesc.ParameterDescriptions)
                {
                    var itemType = GetEnumerableElementType(apd.Type, out var isEnumerable);
                    if (isEnumerable && !IsBaseType(itemType))
                    {
                        pDels.Add(apd);

                        ExpandParam(pAdds, apd.Name + "[0]", apd, itemType);
                    }
                }

                foreach (var pd in pDels)
                    apiDesc.ParameterDescriptions.Remove(pd);
                foreach (var pa in pAdds)
                    apiDesc.ParameterDescriptions.Add(pa);
            }

            #endregion

            await _next.Invoke(context);
        }

        private void ExpandParam(IList<ApiParameterDescription> apds, string name, ApiParameterDescription apdParent, Type modelType)
        {
            var pis = modelType.GetProperties();
            foreach (var pi in pis)
            {
                var itemType = GetEnumerableElementType(pi.PropertyType, out bool isEnumerable);
                var isCombType = IsComboType(pi.PropertyType);
                if (isEnumerable && !IsBaseType(itemType))
                {
                    ExpandParam(apds, $"{name}.{pi.Name}[0]", apdParent, itemType);
                }
                else if (isCombType)
                {
                    ExpandParam(apds, $"{name}.{pi.Name}", apdParent, pi.PropertyType);
                }
                else
                {
                    var dmd = new DefaultMetadataDetails(
                        ModelMetadataIdentity.ForProperty(pi.PropertyType, pi.Name, modelType),
                        new ModelAttributes(new object[0]))
                    {
                        ValidationMetadata = new ValidationMetadata()
                        {
                            IsRequired = false
                        }
                    };
                    var md = new DefaultModelMetadata(_mmp, _cmdp, dmd);

                    var apd = new ApiParameterDescription
                    {
                        Type = pi.PropertyType,
                        ModelMetadata = md,
                        Name = $"{name}.{pi.Name}",
                        RouteInfo = apdParent.RouteInfo,
                        Source = apdParent.Source
                    };
                    apds.Add(apd);
                }
            }
        }

        private static Type GetEnumerableElementType(Type type, out bool isEnumerable)
        {
            isEnumerable = false;

            if (type == null)
                return null;

            if (type.IsArray)
            {
                isEnumerable = true;
                return type.GetElementType();
            }
            else if (type.GetTypeInfo().IsGenericType && typeof(IEnumerable).IsAssignableFrom(type))
            {
                //对应IEnumerable<T>
                isEnumerable = true;
                return type.GetGenericArguments()[0];
            }
            return type;
        }

        private static bool IsComboType(Type type)
        {
            return type.GetTypeInfo().IsClass && type != typeof(string);
        }

        private static bool IsBaseType(Type type)
        {
            return type == typeof(string) || type.GetTypeInfo().IsPrimitive;
        }
    }
}
