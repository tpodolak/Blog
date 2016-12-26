using System;
using Castle.Components.DictionaryAdapter;

namespace StronglyTypedAppSettings
{
    public class SettingsBehavior : IDictionaryKeyBuilder,
        IDictionaryPropertyGetter,
        IPropertyDescriptorInitializer
    {
        public string GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property)
        {
            return $"{dictionaryAdapter.Meta.Type.Name.Remove(0, 1)}.{key}";
        }

        public object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue,
            PropertyDescriptor property, bool ifExists)
        {
            if (storedValue != null) return storedValue;
            throw new InvalidOperationException($"App setting '{key.ToLowerInvariant()}' not found!");
        }

        public void Initialize(PropertyDescriptor propertyDescriptor, object[] behaviors)
        {
            propertyDescriptor.Fetch = true;
        }

        public IDictionaryBehavior Copy()
        {
            return this;
        }

        public int ExecutionOrder { get; } = int.MaxValue;
    }
}