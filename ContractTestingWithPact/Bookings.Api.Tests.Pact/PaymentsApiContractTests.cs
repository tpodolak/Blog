using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PactNet;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace Bookings.Api.Tests.Contract
{
    public class PaymentsApiContractTests : IClassFixture<PaymentsApiPact>
    {
        private readonly PaymentsApiPact _paymentsApiPact;

        public PaymentsApiContractTests(PaymentsApiPact paymentsApiPact)
        {
            _paymentsApiPact = paymentsApiPact;
        }

        [Fact]
        public async Task GetPayment_WhenCalled_ReturnsPayment()
        {
            var guidRegex = "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}";
            var paymentId = "5CACC48C-C002-4ADD-BA99-58F7B78BB1B5";
            _paymentsApiPact.MockProviderService.Given("There is booking with id  bookingId")
                .UponReceiving("a request to retrieve booking by id")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = Match.Regex($"/api/Payments/{paymentId}", $"^\\/api/Payments\\/{guidRegex}$"),
                    Headers = new Dictionary<string, object>
                    {
                        {"Accept", "application/json"}
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        {"Content-Type", "application/json; charset=utf-8"}
                    },
                    Body = Match.Type(new
                    {
                        id = Match.Regex(paymentId, $"^{guidRegex}$"),
                        name = "my name",
                        transactions = Match.MinType(new
                        {
                            id = Match.Regex(paymentId, $"^{guidRegex}$"),
                            amount = 0
                        }, 1)
                    })
                });

            var client = new PaymentsApiClient(_paymentsApiPact.MockProviderServiceBaseUri);

            var byId = await client.GetById(paymentId);

            _paymentsApiPact.MockProviderService.VerifyInteractions();
        }
    }
}