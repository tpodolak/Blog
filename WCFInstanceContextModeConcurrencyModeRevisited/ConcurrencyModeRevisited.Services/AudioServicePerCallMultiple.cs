using System.ServiceModel;
using ConcurrencyModeRevisited.Contracts;

namespace ConcurrencyModeRevisited.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AudioServicePerCallMultiple : AudioService
    {
        public override Playlist GetPlaylist(GetPlaylistRequest request)
        {
            return base.GetPlaylist(request);
        }
    }
}
