using System.Runtime.Serialization;

namespace MockingDownstreamServices.Facade.Models
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public string Text { get; set; }
    }
}