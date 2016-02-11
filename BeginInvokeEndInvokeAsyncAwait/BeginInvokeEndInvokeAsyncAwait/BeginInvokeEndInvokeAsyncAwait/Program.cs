using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeginInvokeEndInvokeAsynAwait.Legacy;

namespace BeginInvokeEndInvokeAsyncAwait
{
    class Program
    {
        private const string HostName = "www.google.pl";

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var dnsService = GetHostEntryBeginInvokeEndInvokePattern();

            await GetHostEntryAsync(dnsService);
        }

        private static async Task GetHostEntryAsync(DnsService dnsService)
        {
            var result = await Task.Factory.FromAsync((callback, o) => dnsService.BeginGetHostEntry(HostName, callback, o), dnsService.EngGetHostEntry, null);
            Console.WriteLine(result);
        }

        private static DnsService GetHostEntryBeginInvokeEndInvokePattern()
        {
            DnsService dnsService = new DnsService();
            dnsService.BeginGetHostEntry(HostName, ar =>
            {
                var result = dnsService.EngGetHostEntry(ar);
                Console.WriteLine(result);

            }, null);
            return dnsService;
        }
    }
}
