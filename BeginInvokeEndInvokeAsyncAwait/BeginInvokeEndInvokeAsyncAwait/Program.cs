using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeginInvokeEndInvokeAsynAwait.Legacy;

namespace BeginInvokeEndInvokeAsyncAwait
{
    class Program
    {
        private const string GoogleHost = "www.google.pl",
            YahooHost = "www.yahoo.pl";

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.ReadKey();
        }

        static async Task MainAsync(string[] args)
        {
            GetHostEntryIAsyncResultPattern();

            await GetHostEntryAsync();
        }

        private static async Task GetHostEntryAsync()
        {
            var dnsService = new DnsService();
            var googleHostResult = await Task.Factory.FromAsync((callback, stateObject) => dnsService.BeginGetHostEntry(GoogleHost, callback, stateObject), dnsService.EndGetHostEntry, null);
            Console.WriteLine($"Result from async/await: {GoogleHost} - {FormatHostEntry(googleHostResult)}");

            var yahooHostResult = await Task.Factory.FromAsync((callback, stateObject) => dnsService.BeginGetHostEntry(YahooHost, callback, stateObject), dnsService.EndGetHostEntry, null);
            Console.WriteLine($"Result from async/await: {YahooHost} - {FormatHostEntry(yahooHostResult)}");
        }

        private static void GetHostEntryIAsyncResultPattern()
        {
            DnsService dnsService = new DnsService();
            dnsService.BeginGetHostEntry(GoogleHost, googleAsyncResult =>
            {
                var googleHostResult = dnsService.EndGetHostEntry(googleAsyncResult);
                Console.WriteLine($"Result from IAsyncResultPattern: {GoogleHost} - {FormatHostEntry(googleHostResult)}");
                dnsService.BeginGetHostEntry(YahooHost, yahooAsyncResult =>
                {
                    var yahooHostResult = dnsService.EndGetHostEntry(yahooAsyncResult);
                    Console.WriteLine($"Result from IAsyncResultPattern: {YahooHost} - {FormatHostEntry(yahooHostResult)}");
                }, null);

            }, null);
        }

        private static string FormatHostEntry(IPHostEntry hostEntry)
        {
            return string.Join(",", hostEntry.AddressList.ToList());
        }
    }
}
