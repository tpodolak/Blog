using System;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading.Tasks;
using ConcurrencyModeRevisited.Contracts;
using ConcurrencyModeRevisited.Services;

namespace ConcurrencyModeRevisited.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            var audioServiceContract = typeof(IAudioService);
            var audioServices = Assembly.GetAssembly(typeof(AudioServicePerCallSingle))
                .GetTypes().Where(val => audioServiceContract.IsAssignableFrom(val) && !val.IsAbstract);

            foreach (var audioService in audioServices)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Starting {audioService.Name}");
                    var host = new ServiceHost(audioService);
                    host.Open();
                    Console.WriteLine($"Started {audioService.Name}");
                }, TaskCreationOptions.LongRunning);
            }
            Console.ReadKey();
        }
    }
}
