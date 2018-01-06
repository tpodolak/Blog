using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using static System.Uri;

namespace AspNetCoreManuallyRetrieveSwaggerSchema.Tests
{
    public class SchemaRetrieverTests
    {
        private readonly SchemaRetriever _subject;
        private readonly string _swaggerDocumentName;

        public SchemaRetrieverTests()
        {
            _subject = new SchemaRetriever();
            _swaggerDocumentName = "Sample API";
        }

        [Fact]
        public void RetrieveSchema_RetrievesSwaggerSchema()
        {
            var result = _subject.RetrieveSchema(_swaggerDocumentName);

            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task RetrieveSchema_RetrievesSwaggerSchema_SameAsDeployedSchema()
        {
            var swaggerSchemaWithoutHosting = _subject.RetrieveSchema(_swaggerDocumentName);
            using (var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>()))
            {
                using (var httpClient = testServer.CreateClient())
                {
                    var response = await httpClient.GetAsync($"swagger/{EscapeDataString(_swaggerDocumentName)}/swagger.json");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();

                    swaggerSchemaWithoutHosting.Should().Be(content);
                }
            }
        }
    }
}