using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoDBServerSideProjection.Projections
{
    public class ServerSideProjectionDefinition<TSource, TResult> : ProjectionDefinition<TSource, TResult>
    {
        private readonly ProjectionDefinition<TSource> _projectionDefinition;

        public ServerSideProjectionDefinition()
        {
            _projectionDefinition = BuildProjectionDefinition();
        }

        public override RenderedProjectionDefinition<TResult> Render(IBsonSerializer<TSource> sourceSerializer, IBsonSerializerRegistry serializerRegistry)
        {
            var bsonDocument = _projectionDefinition.Render(sourceSerializer, serializerRegistry);

            return new RenderedProjectionDefinition<TResult>(bsonDocument, sourceSerializer as IBsonSerializer<TResult> ?? serializerRegistry.GetSerializer<TResult>());
        }

        private static ProjectionDefinition<TSource> BuildProjectionDefinition()
        {
            var sourceProperties = ProjectionPropertyCache<TSource>.PropertyNames;
            var resultProperties = ProjectionPropertyCache<TResult>.PropertyNames;

            var projectionDefinitionBuilder = Builders<TSource>.Projection;

            var projectionDefinitions = resultProperties.Intersect(sourceProperties).Select(
                name => projectionDefinitionBuilder.Include(new StringFieldDefinition<TSource>(name)));

            return projectionDefinitionBuilder.Combine(projectionDefinitions);
        }

        private class ProjectionPropertyCache<T>
        {
            static ProjectionPropertyCache()
            {
                PropertyNames = GetProperties();
            }

            public static IReadOnlyCollection<string> PropertyNames { get; }

            private static ReadOnlyCollection<string> GetProperties()
            {
                return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => !prop.IsSpecialName).Select(prop => prop.Name).ToList().AsReadOnly();
            }
        }
    }
}