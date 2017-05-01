using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspNetCoreApiVersioningByConvention.Conventions
{
    public class ApiVersionRoutePrefixConvention : IApplicationModelConvention
    {
        private readonly string _versionConstraintTemplate;
        private readonly string _versionedControllerTemplate;

        public ApiVersionRoutePrefixConvention()
        {
            _versionConstraintTemplate = "v{version:apiVersion}";
            _versionedControllerTemplate = $"{_versionConstraintTemplate}/[controller]";
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var applicationController in application.Controllers)
            {
                foreach (var applicationControllerSelector in applicationController.Selectors)
                {
                    if (applicationControllerSelector.AttributeRouteModel != null)
                    {
                        var versionedConstraintRouteModel = new AttributeRouteModel
                        {
                            Template = _versionConstraintTemplate
                        };

                        applicationControllerSelector.AttributeRouteModel =
                            AttributeRouteModel.CombineAttributeRouteModel(versionedConstraintRouteModel,
                                applicationControllerSelector.AttributeRouteModel);
                    }
                    else
                    {
                        applicationControllerSelector.AttributeRouteModel = new AttributeRouteModel
                        {
                            Template = _versionedControllerTemplate
                        };
                    }
                }
            }
        }
    }
}