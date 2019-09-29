using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit;
using Xunit.Abstractions;

namespace Payments.Api.Tests.Contract
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void EnsureEventApiHonoursPactWithConsumer()
        {
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                }
            };

            Program.CreateWebHostBuilder(Array.Empty<string>())
                .UseUrls("http://localhost:9000")
                .Build()
                .Start();

            //Act / Assert
            IPactVerifier pactVerifier = new PactVerifier(config);
            pactVerifier
                .ServiceProvider("PaymentsApi", "http://localhost:9000")
                .HonoursPactWith("BookingsApi")
                .PactUri(Path.Combine(GetLocation("pacts"), "bookingsapi-paymentsapi.json"))
                .Verify();
        }

        private string GetLocation(string directoryName)
        {
            var locations = new[] {"..", "..", "..", "..", directoryName};
            var rulesPath = string.Join(Path.DirectorySeparatorChar, locations);
            return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                rulesPath));
        }
    }
}