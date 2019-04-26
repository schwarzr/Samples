using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace ConstructionDiary.AspNetCore.Mvc
{
    public class ContractModelProvider : IApplicationModelProvider
    {
        public int Order => 9999;

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            foreach (var controller in context.Result.Controllers)
            {
                var serviceInterface = controller.ControllerType.GetInterfaces().FirstOrDefault(p => p.GetTypeInfo().GetCustomAttribute<RestRouteAttribute>() != null);

                var att = controller.ControllerType.GetCustomAttribute<RestRouteAttribute>();
                att = att ?? serviceInterface?.GetTypeInfo()?.GetCustomAttribute<RestRouteAttribute>();

                if (att != null)
                {
                    controller.Selectors.First().AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(att.RoutePrefix));
                }

                foreach (var action in controller.Actions)
                {
                    var methodAtt = action.ActionMethod.GetCustomAttributes().OfType<RestOperationAttribute>().FirstOrDefault();
                    methodAtt = methodAtt ?? serviceInterface?.GetTypeInfo().GetMethod(action.ActionMethod.Name, action.ActionMethod.GetParameters().Select(p => p.ParameterType).ToArray())?.GetCustomAttributes().OfType<RestOperationAttribute>().FirstOrDefault();

                    if (methodAtt != null)
                    {
                        var targetAttribute = GetTargetAttribute(methodAtt.HttpMethod(), methodAtt.Template);
                        action.Selectors.Clear();
                        action.Selectors.Add(CreateSelectorModel(targetAttribute));
                    }
                }
            }
        }

        private static SelectorModel CreateSelectorModel(IRouteTemplateProvider route)
        {
            var selectorModel = new SelectorModel();
            if (route != null)
            {
                selectorModel.AttributeRouteModel = new AttributeRouteModel(route);
            }

            selectorModel.EndpointMetadata.Add(route);

            // Simple case, all HTTP method attributes apply
            var httpMethods = new[] { route }
                .OfType<IActionHttpMethodProvider>()
                .SelectMany(a => a.HttpMethods)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (httpMethods.Length > 0)
            {
                selectorModel.ActionConstraints.Add(new HttpMethodActionConstraint(httpMethods));
                selectorModel.EndpointMetadata.Add(new HttpMethodMetadata(httpMethods));
            }

            return selectorModel;
        }

        private IRouteTemplateProvider GetTargetAttribute(string method, string template)
        {
            switch (method)
            {
                case "GET":
                    return template == null ? new HttpGetAttribute() : new HttpGetAttribute(template);

                case "POST":
                    return template == null ? new HttpPostAttribute() : new HttpPostAttribute(template);

                case "PUT":
                    return template == null ? new HttpPutAttribute() : new HttpPutAttribute(template);

                case "DELETE":
                    return template == null ? new HttpDeleteAttribute() : new HttpDeleteAttribute(template);

                default:
                    throw new NotSupportedException($"Http method {method} is not supported by the rest contract package!");
            }
        }
    }
}