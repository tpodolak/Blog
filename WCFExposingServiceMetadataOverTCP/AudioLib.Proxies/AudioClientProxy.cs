using System.ServiceModel;
using AudioLib.Contracts;

namespace AudioLib.Proxies
{
    public class AudioClientProxy : ClientBase<IAudioService>,IAudioService
    {
        public Playlist GetPlaylist(string id)
        {
            return this.Channel.GetPlaylist(id);
        }
    }
}