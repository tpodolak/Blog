using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherApi.IntegrationTests
{
    internal static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder WithAdditionalControllers(this IWebHostBuilder builder, params Type[] controllers)
        {
            return builder.ConfigureTestServices(
                services =>
                {
                    var partManager = GetApplicationPartManager(services);

                    partManager.FeatureProviders.Add(new ExternalControllersFeatureProvider(controllers));
                });
        }

        private static ApplicationPartManager GetApplicationPartManager(IServiceCollection services)
        {
            var partManager = (ApplicationPartManager)services
                .Last(descriptor => descriptor.ServiceType == typeof(ApplicationPartManager))
                .ImplementationInstance;
            return partManager;
        }

        private class ExternalControllersFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
        {
            private readonly Type[] _controllers;

            public ExternalControllersFeatureProvider(params Type[] controllers)
            {
                _controllers = controllers ?? Array.Empty<Type>();
            }

            public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
            {
                foreach (var controller in _controllers)
                {
                    feature.Controllers.Add(controller.GetTypeInfo());
                }
            }
        }
    }
}