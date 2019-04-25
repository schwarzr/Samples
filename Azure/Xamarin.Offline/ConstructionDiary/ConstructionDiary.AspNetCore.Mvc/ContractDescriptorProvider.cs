using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;

namespace ConstructionDiary.AspNetCore.Mvc
{
    public class ContractDescriptorProvider : IActionDescriptorProvider

    {
        private readonly IApplicationModelProvider[] _applicationModelProviders;
        private readonly IEnumerable<IApplicationModelConvention> _conventions;
        private readonly ApplicationPartManager _partManager;

        public ContractDescriptorProvider(
                ApplicationPartManager partManager,
                IEnumerable<IApplicationModelProvider> applicationModelProviders,
                IOptions<MvcOptions> optionsAccessor)

        {
            if (partManager == null)
            {
                throw new ArgumentNullException(nameof(partManager));
            }

            if (applicationModelProviders == null)

            {
                throw new ArgumentNullException(nameof(applicationModelProviders));
            }

            if (optionsAccessor == null)

            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }

            _partManager = partManager;
            _applicationModelProviders = applicationModelProviders.OrderBy(p => p.Order).ToArray();
            _conventions = optionsAccessor.Value.Conventions;
        }

        public int Order => -1000;

        public void OnProvidersExecuted(ActionDescriptorProviderContext context)
        {
            var keys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (var i = 0; i < context.Results.Count; i++)
            {
                var action = context.Results[i];

                foreach (var key in action.RouteValues.Keys)
                {
                    keys.Add(key);
                }
            }

            for (var i = 0; i < context.Results.Count; i++)
            {
                var action = context.Results[i];

                foreach (var key in keys)
                {
                    if (!action.RouteValues.ContainsKey(key))
                    {
                        action.RouteValues.Add(key, null);
                    }
                }
            }
        }

        public void OnProvidersExecuting(ActionDescriptorProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            foreach (var descriptor in GetDescriptors())
            {
                context.Results.Add(descriptor);
            }
        }

        protected internal ApplicationModel BuildModel()
        {
            var controllerTypes = GetControllerTypes();
            var context = new ApplicationModelProviderContext(controllerTypes);

            for (var i = 0; i < _applicationModelProviders.Length; i++)
            {
                _applicationModelProviders[i].OnProvidersExecuting(context);
            }

            for (var i = _applicationModelProviders.Length - 1; i >= 0; i--)
            {
                _applicationModelProviders[i].OnProvidersExecuted(context);
            }

            return context.Result;
        }

        protected internal IEnumerable<ControllerActionDescriptor> GetDescriptors()
        {
            var applicationModel = BuildModel();

            foreach (var controller in applicationModel.Controllers)
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
                        action.Selectors.First().AttributeRouteModel = new AttributeRouteModel(targetAttribute);
                    }
                }
            }

            ApplicationModelConventions.ApplyConventions(applicationModel, _conventions);

            return ControllerActionDescriptorBuilder.Build(applicationModel);
        }

        private IEnumerable<TypeInfo> GetControllerTypes()
        {
            var types = _partManager.ApplicationParts.OfType<IApplicationPartTypeProvider>().SelectMany(p => p.Types);

            var backendServices = types
                                    .Where(p => p.GetCustomAttribute<RestRouteAttribute>() != null ||
                                                    p.GetInterfaces().Any(x => x.GetTypeInfo().GetCustomAttribute<RestRouteAttribute>() != null));

            return backendServices;
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