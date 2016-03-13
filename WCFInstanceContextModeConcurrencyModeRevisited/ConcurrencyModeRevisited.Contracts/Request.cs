using System;
using System.Runtime.Serialization;

namespace ConcurrencyModeRevisited.Contracts
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public DateTime ClientTime { get; set; } 
    }
}