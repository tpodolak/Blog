using System;
using System.IO;
using System.Reflection;
using PactNet;
using PactNet.Mocks.MockHttpService;
using PactNet.Models;

namespace Bookings.Api.Tests.Contract
{
    public class PaymentsApiPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; }
        public IMockProviderService MockProviderService { get; }
        public int MockServerPort => 9123;
        public string MockProviderServiceBaseUri => $"http://localhost:{MockServerPort}";

        public PaymentsApiPact()
        {
            PactBuilder = new PactBuilder(new PactConfig
                {
                    SpecificationVersion = "2.0.0",
                    LogDir = GetLocation("logs"),
                    PactDir = GetLocation("pacts")
                }).ServiceConsumer("BookingsApi")
                .HasPactWith("PaymentsApi");

            MockProviderService = PactBuilder.MockService(MockServerPort, host: IPAddress.Any);
        }
        
        public void Dispose()
        {
            PactBuilder.Build();
        }

        private string GetLocation(string directoryName)
        {
            var locations = new[] {"..", "..", "..", "..", directoryName };
            var rulesPath = string.Join(Path.DirectorySeparatorChar, locations);
            return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), rulesPath));
        }
    }
}