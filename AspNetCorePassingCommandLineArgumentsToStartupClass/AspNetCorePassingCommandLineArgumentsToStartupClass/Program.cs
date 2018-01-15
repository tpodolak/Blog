using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCorePassingCommandLineArgumentsToStartupClass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .ConfigureServices(serviceCollection => serviceCollection.AddSingleton<IConfiguration>(new ConfigurationBuilder().AddCommandLine(args).Build()))
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
