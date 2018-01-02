using FluentAssertions;
using Xunit;

namespace AspNetCoreManuallyRetrieveSwaggerSchema.Tests
{
    public class SchemaRetrieverTests
    {
        [Fact]
        public void RetrieveSchema_RetrievesSwaggerSchema()
        {
            var subject = new SchemaRetriever();
            
            var result = subject.RetrieveSchema("Sample API");

            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}