using System;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreMemoryCacheIsPopulatedMultipleTimes.Infrastructure.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
        
        public T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration)
        {
            // locks get and set internally but call to factory method is not locked
            return _memoryCache.GetOrCreate(cacheKey, entry => factory());
        }
    }
}