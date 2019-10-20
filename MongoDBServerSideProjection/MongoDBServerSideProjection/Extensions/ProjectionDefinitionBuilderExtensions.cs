using MongoDB.Driver;
using MongoDBServerSideProjection.Projections;

namespace MongoDBServerSideProjection.Extensions
{
    public static class ProjectionDefinitionBuilderExtensions
    {
        public static ServerSideProjectionDefinition<TSource, TResult> ServerSide<TSource, TResult>(this ProjectionDefinitionBuilder<TSource> builder)
        {
            return new ServerSideProjectionDefinition<TSource, TResult>();
        }
    }
}