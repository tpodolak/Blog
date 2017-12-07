using System;
using System.Linq;
using System.Threading;
using AspNetCoreMemoryCacheIsPopulatedMultipleTimes.Infrastructure.Caching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using NSubstitute;
using Xunit;

namespace AspNetCoreMemoryCacheIsPopulatedMultipleTimes.Tests
{
    public class CacheServiceTests
    {
        // this one will fail as implementation purely based on _memoryCache.GetOrCreate allows for calling
        // factory method multiple times
        [Fact]
        public void GetOrAdd_CallsFactoryMethodOnce()
        {
            var factoryMock = Substitute.For<Func<string>>();
            var optionsMock = Substitute.For<IOptions<MemoryCacheOptions>>();
            optionsMock.Value.Returns(callInfo => new MemoryCacheOptions());
            var memoryCache = new MemoryCache(optionsMock);

            var subject = new CacheService(memoryCache);

            var threads = Enumerable.Range(0, 10)
                .Select(_ => new Thread(() => subject.GetOrAdd("key", factoryMock, DateTime.MaxValue))).ToList();
            
            threads.ForEach(thread => thread.Start());
            threads.ForEach(thread => thread.Join());

            factoryMock.Received(1)();
        }
    }
}