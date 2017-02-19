using System;

namespace XunitSharingFixtureDataAcrossAssembly
{
    public class TestFixture : IDisposable
    {
        public static int InitializationCounter { get; private set; }

        public TestFixture()
        {
            InitializationCounter++;
        }

        public void Dispose()
        {
            // free resources if necessary
        }
    }
}
