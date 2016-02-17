using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MockingDownstreamServices.Facade.Models
{
    [DataContract]
    public class Response<T>
    {
        [DataMember]
        public T Result { get; set; }

        public List<Message> Messages { get; set; }

        public Response()
        {
            this.Messages = new List<Message>();       
        }
    }
}