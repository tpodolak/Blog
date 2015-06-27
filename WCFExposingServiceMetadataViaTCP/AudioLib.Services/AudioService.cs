using System.ServiceModel.Description;
using AudioLib.Contracts;

namespace AudioLib.Services
{
    public class AudioService : IAudioService
    {
        public Playlist GetPlaylist(string id)
        {
            return new Playlist
            {
                Id = id,
                Name = "Random playlist"
            };
        }
    }
}