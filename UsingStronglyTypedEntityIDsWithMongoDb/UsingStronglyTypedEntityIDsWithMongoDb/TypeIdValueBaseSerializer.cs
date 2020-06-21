using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace UsingStronglyTypedEntityIDsWithMongoDb
{
    public class TypeIdValueBaseSerializer<TTypedId> : SerializerBase<TTypedId>
        where TTypedId : TypedIdValueBase
    {
        public override TTypedId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var result = Activator.CreateInstance(args.NominalType, context.Reader.ReadString());

            return (TTypedId)result;
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TTypedId value)
        {
            context.Writer.WriteObjectId(new ObjectId(value.Value));
        }
    }
}