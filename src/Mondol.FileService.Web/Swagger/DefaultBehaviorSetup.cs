// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-12-12
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mondol.WebPlatform.Swagger
{
    /// <summary>
    /// 截止Swashbuckle 1.0.0-rc3版本强制要求明确指定API的HTTP方法及参数来源类型，否则异常。
    /// 本类会抑制这种强制行为，未指定时给于默认行为
    /// </summary>
    public class DefaultBehaviorSetup
    {
        /// <summary>
        /// 应用默认行为
        /// </summary>
        public void Apply(ApiDescription apiDesc)
        {
            ApplyDefaultHttpMethod(apiDesc);
            ApplyDefaultParameters(apiDesc);
        }

        private void ApplyDefaultHttpMethod(ApiDescription apiDesc)
        {
            if (string.IsNullOrEmpty(apiDesc.HttpMethod))
                apiDesc.HttpMethod = "GET";
        }

        private void ApplyDefaultParameters(ApiDescription apiDesc)
        {
            var defSource = GetDefaultSourceByHttpMethod(apiDesc.HttpMethod);

            foreach (var apd in apiDesc.ParameterDescriptions)
            {
                if (apd.Source == BindingSource.ModelBinding)
                {
                    apd.Source = defSource;
                }
            }
        }

        private BindingSource GetDefaultSourceByHttpMethod(string httpMethod)
        {
            switch (httpMethod)
            {
                case "PUT":
                case "POST":
                case "PATCH":
                    return BindingSource.Form;
                default:
                    return BindingSource.Query;
            }
        }
    }
}
