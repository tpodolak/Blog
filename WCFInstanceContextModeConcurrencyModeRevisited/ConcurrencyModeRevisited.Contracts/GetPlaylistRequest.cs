using System.Runtime.Serialization;

namespace ConcurrencyModeRevisited.Contracts
{
    [DataContract]
    public class GetPlaylistRequest : Request
    {
        [DataMember]
        public string Name { get; set; }
    }
}