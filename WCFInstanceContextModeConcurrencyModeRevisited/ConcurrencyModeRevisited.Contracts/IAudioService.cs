using System.ServiceModel;

namespace ConcurrencyModeRevisited.Contracts
{
    [ServiceContract]
    public interface IAudioService
    {
        [OperationContract]
        Playlist GetPlaylist(GetPlaylistRequest request);
    }
}