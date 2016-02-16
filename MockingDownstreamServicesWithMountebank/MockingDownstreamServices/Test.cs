using System.Configuration;
using NUnit.Framework;

namespace MockingDownstreamServices.Tests.Integration
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void AppConfigTest()
        {
            var profile = ConfigurationManager.AppSettings["profile"];
            var commonKey = ConfigurationManager.AppSettings["commonKey"];
        }
    }
}
