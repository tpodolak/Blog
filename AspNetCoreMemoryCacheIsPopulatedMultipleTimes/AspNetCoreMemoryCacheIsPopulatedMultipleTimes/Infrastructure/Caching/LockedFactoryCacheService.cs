using System;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreMemoryCacheIsPopulatedMultipleTimes.Infrastructure.Caching
{
    public class LockedFactoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public LockedFactoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration)
        {
            // locks get and set internally
            if (_memoryCache.TryGetValue<T>(cacheKey, out var result))
            {
                return result;
            }

            lock (TypeLock<T>.Lock)
            {
                if (_memoryCache.TryGetValue(cacheKey, out result))
                {
                    return result;
                }

                result = factory();
                _memoryCache.Set(cacheKey, result, absoluteExpiration);

                return result;
            }
        }

        private static class TypeLock<T>
        {
            public static object Lock { get; } = new object();
        }
    }
}