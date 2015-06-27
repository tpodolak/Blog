using System.ServiceModel;

namespace AudioLib.Contracts
{
    [ServiceContract]
    public interface IAudioService
    {
        [OperationContract]
        Playlist GetPlaylist(string id);
    }
}