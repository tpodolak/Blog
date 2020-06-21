using System;
using MongoDB.Bson.Serialization;

namespace UsingStronglyTypedEntityIDsWithMongoDb
{
    public class StronglyTypedIdSerializationProvider : IBsonSerializationProvider
    {
        private static readonly Type TypeIdValueBaseType = typeof(TypedIdValueBase);

        public IBsonSerializer GetSerializer(Type type)
        {
            if (!TypeIdValueBaseType.IsAssignableFrom(type))
            {
                return null;
            }

            var serializerType = typeof(TypeIdValueBaseSerializer<>).MakeGenericType(type);

            return (IBsonSerializer)Activator.CreateInstance(serializerType);
        }
    }
}