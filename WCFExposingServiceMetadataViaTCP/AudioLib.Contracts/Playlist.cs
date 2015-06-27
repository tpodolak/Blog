using System.Runtime.Serialization;

namespace AudioLib.Contracts
{
    [DataContract]
    public class Playlist
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}