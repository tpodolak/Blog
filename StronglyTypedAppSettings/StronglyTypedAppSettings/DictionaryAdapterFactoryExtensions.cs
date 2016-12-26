using System.Collections.Specialized;
using Castle.Components.DictionaryAdapter;

namespace StronglyTypedAppSettings
{
    public static class DictionaryAdapterFactoryExtensions
    {

        public static T GetAdapter<T>(this IDictionaryAdapterFactory factory, NameValueCollection nameValueCollection, PropertyDescriptor propertyDescriptor)
        {
            var settings = (T)factory.GetAdapter(typeof(T), new NameValueCollectionAdapter(nameValueCollection), propertyDescriptor);
            return settings;
        }
    }
}