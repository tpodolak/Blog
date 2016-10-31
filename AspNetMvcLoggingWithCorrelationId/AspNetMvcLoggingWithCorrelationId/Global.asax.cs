using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Mvc;

namespace AspNetMvcLoggingWithCorrelationId
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
            IntegrateFluentValidation();
		}

	    private void IntegrateFluentValidation()
	    {
	        CustomFluentValidationModelValidatorProvider.Configure(provider => provider.ValidatorFactory = new AttributedValidatorFactory());
	    }
	}

    public class CustomFluentValidationModelValidatorProvider : FluentValidationModelValidatorProvider
    {
        public CustomFluentValidationModelValidatorProvider(IValidatorFactory factory = null) : base(factory)
        {
        }

        public new static void Configure(Action<FluentValidationModelValidatorProvider> configurationExpression = null)
        {
            configurationExpression = configurationExpression ?? (param0 => { });
            var validatorProvider = new CustomFluentValidationModelValidatorProvider(null);
            configurationExpression(validatorProvider);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(validatorProvider);
        }


        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            return base.GetValidators(metadata, context);
        }

        protected override IValidator CreateValidator(ModelMetadata metadata, ControllerContext context)
        {
	        if(metadata.ContainerType == null && metadata.PropertyName == null && metadata.ModelType!=null)
                return this.ValidatorFactory.GetValidator(metadata.ModelType);
            return null;
        }
    }

}
