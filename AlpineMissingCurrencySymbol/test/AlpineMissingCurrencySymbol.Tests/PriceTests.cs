using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace AlpineMissingCurrencySymbol.Tests
{
    public class PriceTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PriceTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task GetPrice_ReturnsCorrectCurrency()
        {
            var httpClient = _factory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync("api/Price");
            
            httpResponseMessage.EnsureSuccessStatusCode();
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(content);

            jObject["currencySymbol"].ToObject<string>().Should().Be("€");
        }
    }
}