using System;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;
using MockingDownstreamServices.Facade;
using NUnit.Framework;

namespace MockingDownstreamServices.Tests.Integration
{
    [TestFixture]
    public class Test
    {
        private ServiceHost serviceHost;

        [SetUp]
        public void SetUp()
        {
            this.serviceHost = new ServiceHost(typeof(BookingFacade));
            serviceHost.Open();

        }

        [TearDown]
        public void TearDown()
        {
            serviceHost.Close();
        }

        [Test]
        public async Task TestConnection()
        {
            await Task.Delay(TimeSpan.FromHours(1));
            using (var webClient = new WebClient())
            {
                var resultString = webClient.DownloadString("http://localhost:8080/BookingFacade/Price");
            }
        }
    }
}
