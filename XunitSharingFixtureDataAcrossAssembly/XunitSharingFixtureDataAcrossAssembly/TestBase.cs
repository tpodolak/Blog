using Xunit;
using Xunit.Abstractions;

namespace XunitSharingFixtureDataAcrossAssembly
{
    public class TestBase : IAssemblyFixture<TestFixture>
    {
        protected readonly ITestOutputHelper TestOutputHelper;
        protected readonly TestFixture Fixture;

        protected TestBase(ITestOutputHelper testOutputHelper, TestFixture fixture)
        {
            this.TestOutputHelper = testOutputHelper;
            this.Fixture = fixture;
        }

        protected void DisplayInitializationCount()
        {
            TestOutputHelper.WriteLine($"Initialization count: {TestFixture.InitializationCounter}");
        }
    }
}