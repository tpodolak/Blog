using System;

namespace AspNetCoreMemoryCacheIsPopulatedMultipleTimes.Infrastructure.Caching
{
    public interface ICacheService
    {
        T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration);
    }
}