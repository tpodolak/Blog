using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookings.Api.Tests.Contract
{
    public class PaymentsApiClient
    {
        private readonly HttpClient _httpClient;
        
        public PaymentsApiClient(string baseUri)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<object> GetById(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Payments/{id}");
            request.Headers.Add("Accept", "application/json");
            
            var httpResponseMessage = await _httpClient.SendAsync(request);

            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();

            return readAsStringAsync;
        }
    }
}