using System;
using System.Threading;
using System.Threading.Tasks;
using ConcurrencyModeRevisited.Proxies;

//using ConcurrencyModeRevisited.Contracts;
//using ConcurrencyModeRevisited.Proxies;

namespace ConcurrencyModeRevisited.Client
{
    public class Program
    {
        static void Main(string[] args)
        {

            var audioClientProxy = new AudioClientProxyPerCallMultiple();


            TaskScheduler.UnobservedTaskException += (sender, eventArgs) => Console.WriteLine("unobserved");

            Task.Factory.StartNew(() => { throw new Exception(); }, TaskCreationOptions.LongRunning);
            using (var autoResetEvent = new AutoResetEvent(false))
            {
                autoResetEvent.WaitOne(TimeSpan.FromSeconds(10));
            }
            Console.WriteLine("Collecting");
            GC.Collect();
            GC.WaitForPendingFinalizers();


            Console.WriteLine("Still working ");
            Console.ReadKey();
            Console.WriteLine("Still working ");
            Console.WriteLine("Still working ");
            Console.ReadKey();
        }

        private static async Task Foo()
        {
            await Task.FromResult(1);
        }

        //        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //        {
        //
        //        }
        //
        //        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        //        {
        //            Console.WriteLine("unobserved");
        //        }
        //
        //        //        private static Task MakeMultipleServiceCalls<TProxy>(TProxy proxy, int callsCount = 5) where TProxy : AudioClientProxy
        //        //        {
        //        //            var tasks =
        //        //                Enumerable.Range(0, callsCount)
        //        //                    .Select((val, idx) => Task.Factory.StartNew(() => proxy.GetPlaylist(new GetPlaylistRequest
        //        //                    {
        //        //                        ClientTime = DateTime.Now,
        //        //                        Id = $"Request {idx + 1}",
        //        //                        Name = $"Playlist {idx + 1}"
        //        //                    }), TaskCreationOptions.LongRunning));
        //        //
        //        //            return Task.WhenAll(tasks);
        //        //        }
        //        //
        //        //        private static Task MakeMultipleServiceCalls<TProxy>(int callsCount = 5) where TProxy : AudioClientProxy, new()
        //        //        {
        //        //            var tasks =
        //        //                Enumerable.Range(0, callsCount)
        //        //                    .Select((val, idx) => Task.Factory.StartNew(() => new TProxy().GetPlaylist(new GetPlaylistRequest
        //        //                    {
        //        //                        ClientTime = DateTime.Now,
        //        //                        Id = $"Request {idx + 1}",
        //        //                        Name = $"Playlist {idx + 1}"
        //        //                    }), TaskCreationOptions.LongRunning));
        //        //
        //        //            return Task.WhenAll(tasks);
        //        //        }
    }
}
