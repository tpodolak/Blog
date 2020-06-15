using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace WeatherApi.IntegrationTests
{
    public class MvcOptionsConfigurationTests
    {
        [Fact]
        public async Task DoesNotReturnBadRequest_WhenNonNullableTypeHasNoValue()
        {
            var webApplicationFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(
                    builder => builder.WithAdditionalControllers(typeof(MvcOptionsTestController)));
            var client = webApplicationFactory.CreateClient();

            var expectedResponse = new Request
            {
                Id = "1"
            };

            var httpResponseMessage = await client.GetAsync("test?id=1");

            httpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            var rawContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Request>(rawContent);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [ApiController]
        private class MvcOptionsTestController : ControllerBase
        {
            [HttpGet("test")]
            public object Get([FromQuery] Request request)
            {
                return request;
            }
        }

        private class Request
        {
            public string Id { get; set; }

            public string OtherId { get; set; }
        }
    }
}