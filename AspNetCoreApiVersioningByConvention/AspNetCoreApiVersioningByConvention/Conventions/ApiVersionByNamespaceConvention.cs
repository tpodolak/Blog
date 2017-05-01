using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

namespace AspNetCoreApiVersioningByConvention.Conventions
{
    public class ApiVersionByNamespaceConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controllerModel in application.Controllers)
            {
                var version = DeduceControllerVersion(controllerModel);
                var builder = new ControllerApiVersionConventionBuilder<ControllerModel>();
                builder.HasApiVersion(new ApiVersion(version, 0));
                builder.ApplyTo(controllerModel);
            }
        }

        private int DeduceControllerVersion(ControllerModel model)
        {
            // super trivial way of retrieving version number from namespace
            if (!int.TryParse(model.ControllerType.Namespace.Last().ToString(), out var version))
            {
                throw new InvalidOperationException("Unable to retrieve version information from namespace");
            }

            return version;
        }
    }
}