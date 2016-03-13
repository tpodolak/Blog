using System;
using System.Diagnostics;
using System.Threading;
using ConcurrencyModeRevisited.Contracts;
namespace ConcurrencyModeRevisited.Services
{
    public abstract class AudioService : IAudioService
    {
        private int callPerInstanceCounter = 0;
        public virtual Playlist GetPlaylist(GetPlaylistRequest request)
        {
            // Interlocked.Increment(ref callPerInstanceCounter);
            callPerInstanceCounter++;
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} counter {callPerInstanceCounter}");
            Console.WriteLine($"Service {GetType().Name} started processing request {request.Id} : received at {DateTime.Now} send at {request.ClientTime} calls per insance {callPerInstanceCounter}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var playlist = new Playlist
            {
                Name = request.Name
            };
            Console.WriteLine($"Service {GetType().Name} finished processing request {request.Id} at {DateTime.Now}");
            return playlist;
        }
    }
}