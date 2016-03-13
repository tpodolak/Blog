using System.Runtime.Serialization;

namespace ConcurrencyModeRevisited.Contracts
{
    [DataContract]
    public class Playlist
    {
        [DataMember]
        public string Name { get; set; }
    }
}
