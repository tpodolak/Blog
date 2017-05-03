using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspNetCoreDefaultApiVersionWithUrlPathVersioning.Conventions
{
    public class DefaultRoutePrefixConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var applicationController in application.Controllers)
            {
                applicationController.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = "[controller]"
                    }
                });
            }
        }
    }
}