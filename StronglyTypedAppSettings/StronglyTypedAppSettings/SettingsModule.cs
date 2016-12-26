using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using Autofac;
using Castle.Components.DictionaryAdapter;
using Module = Autofac.Module;

namespace StronglyTypedAppSettings
{
    public class SettingsModule : Module
    {
        private readonly Assembly[] _assemblies;
        private readonly NameValueCollection _appSettings;

        public SettingsModule(NameValueCollection appSettings, params Assembly[] assemblies)
        {
            _assemblies = assemblies;
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var factory = new DictionaryAdapterFactory();
            var appSettingsAdapter = new NameValueCollectionAdapter(_appSettings);
            var descriptor = new PropertyDescriptor().AddBehavior(new SettingsBehavior());

            foreach (var type in _assemblies.SelectMany(val => val.ExportedTypes)
                .Where(val => val.IsInterface && val.IsAssignableTo<ISettings>() && val != typeof(ISettings)))
            {
                builder.RegisterInstance(factory.GetAdapter(type, appSettingsAdapter, descriptor)).As(type);
            }
        }
    }
}