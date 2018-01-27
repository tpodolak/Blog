using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace AspNetCoreMakeSureYouInitializedYourIOptionsOfT.Tests
{
    public class OptionsTests
    {
        private readonly Lazy<IWebHost> _webHost = new Lazy<IWebHost>(Program.BuildWebHost(null));

        // this test will fail as not every option in assembly is configured
        [Fact]
        public void AllConfigurationOptions_HasConfigurationServicesDefined()
        {
            var optionsType = typeof(IOptions<>);
            var constructorParameterTypes = typeof(Program).Assembly.GetExportedTypes()
                .SelectMany(type => type.GetConstructors().SelectMany(ctor => ctor.GetParameters()))
                .Select(parameter => parameter.ParameterType);

            var optionValueTypes = constructorParameterTypes.Where(parameterType => IsAssignableToGenericType(parameterType, optionsType))
                .Select(options => options.GetGenericArguments().Single())
                .Distinct();
            
            var postConfigureOptionsType = typeof(IPostConfigureOptions<>);
            var configureOptionsType = typeof(IConfigureOptions<>);

            var postConfiguration = optionValueTypes.Select(type => new
            {
                optionsType = type,
                configureOptionsType = _webHost.Value.Services.GetServices(configureOptionsType.MakeGenericType(type)),
                postConfigureServices = _webHost.Value.Services.GetServices(postConfigureOptionsType.MakeGenericType(type))
            });

            var emptyConfigurations =
                postConfiguration.Where(item => item.configureOptionsType.Any() == false && item.postConfigureServices.Any() == false)
                    .Select(item => item.optionsType);

            emptyConfigurations.Should().BeEmpty("All options should be configured");
        }

        // https://stackoverflow.com/questions/74616/how-to-detect-if-type-is-another-generic-type/1075059#1075059
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            if (interfaceTypes.Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType))
            {
                return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            var baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }
    }
}