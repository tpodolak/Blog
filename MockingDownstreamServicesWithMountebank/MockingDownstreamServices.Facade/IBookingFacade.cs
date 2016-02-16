using System.ServiceModel;
using System.ServiceModel.Web;
using MockingDownstreamServices.Facade.Models;

namespace MockingDownstreamServices.Facade
{
    [ServiceContract]
    public interface IBookingFacade
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "price")]
        Price Price();
    }
}
