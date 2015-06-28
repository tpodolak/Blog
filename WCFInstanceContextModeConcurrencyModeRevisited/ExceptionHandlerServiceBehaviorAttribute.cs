using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace WCFInstanceContextModeConcurrencyModeRevisited
{
    public class ExceptionHandlerServiceBehaviorAttribute : Attribute, IServiceBehavior
    {
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
            foreach (var operation in endpoints.SelectMany(val => val.Contract.Operations.Where(x => x.Behaviors.Find<ExceptionHandlerOperationBehavior>() == null)))
            {
                operation.Behaviors.Add(new ExceptionHandlerOperationBehavior());
            }
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }
    }
}