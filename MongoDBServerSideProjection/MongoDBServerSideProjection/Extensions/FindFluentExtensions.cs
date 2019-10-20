using MongoDB.Driver;

namespace MongoDBServerSideProjection.Extensions
{
    public static class FindFluentExtensions
    {
        public static IFindFluent<TSource, TResult> ProjectTo<TSource, TResult>(this IFindFluent<TSource, TSource> findFluent)
        {
            var serverSideProjectionDefinition = Builders<TSource>.Projection.ServerSide<TSource, TResult>();
            return findFluent.Project(serverSideProjectionDefinition);
        }
    }
}