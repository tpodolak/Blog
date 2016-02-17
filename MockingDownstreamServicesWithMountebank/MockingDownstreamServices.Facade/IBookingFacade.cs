using System.ServiceModel;
using System.ServiceModel.Web;
using MockingDownstreamServices.Facade.Models;

namespace MockingDownstreamServices.Facade
{
    [ServiceContract]
    public interface IBookingFacade
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "price")]
        Response<Price> Price(GetPriceRequest request);
    }
}
