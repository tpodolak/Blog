using System;
using System.Configuration;
using System.Reflection;
using Autofac;

namespace StronglyTypedAppSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new SettingsModule(ConfigurationManager.AppSettings, Assembly.GetExecutingAssembly()));
            var container = builder.Build();
            var masterPassSettings = container.Resolve<IMasterPassSettings>();
            var payPalSettings = container.Resolve<IPayPalSettings>();
            Console.WriteLine(masterPassSettings.AccessTokenUrl);
            Console.WriteLine(payPalSettings.RequestTokenUrl);
            Console.ReadKey();
        }
    }
}
