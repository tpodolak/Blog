using System.Runtime.Serialization;

namespace MockingDownstreamServices.Facade.Models
{
    [DataContract]
    public class GetPriceRequest
    {
         [DataMember]
         public bool IsAdvised { get; set; }
    }
}