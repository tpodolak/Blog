using System;
using System.ServiceModel;
using AudioLib.Services;

namespace AudioLib.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(AudioService));
            serviceHost.Open();
            Console.WriteLine("Service host listening");
            Console.ReadKey();
            serviceHost.Close();
        }
    }
}
