using Xunit;
using Xunit.Abstractions;

namespace XunitSharingFixtureDataAcrossAssembly
{
    public class FirstClassTests : TestBase
    {
        public FirstClassTests(ITestOutputHelper testOutputHelper, TestFixture fixture) : base(testOutputHelper, fixture)
        {
        }

        [Fact]
        public void FirstTest()
        {
            DisplayInitializationCount();
        }

        [Fact]
        public void SecondTest()
        {
            DisplayInitializationCount();
        }
    }
}