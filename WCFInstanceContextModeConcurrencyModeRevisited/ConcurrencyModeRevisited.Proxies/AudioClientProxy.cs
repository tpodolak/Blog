using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using ConcurrencyModeRevisited.Contracts;

namespace ConcurrencyModeRevisited.Proxies
{
    public abstract class AudioClientProxy : ClientBase<IAudioService>, IAudioService
    {
        protected AudioClientProxy(string endpoint) : base(endpoint)
        {
        }

        public Playlist GetPlaylist(GetPlaylistRequest request)
        {
            return this.Channel.GetPlaylist(request);
        }
    }
}