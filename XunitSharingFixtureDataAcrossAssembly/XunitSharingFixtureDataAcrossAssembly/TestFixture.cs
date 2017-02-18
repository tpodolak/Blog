namespace XunitSharingFixtureDataAcrossAssembly
{
    public class TestFixture
    {
        public static int InitializationCounter { get; private set; }

        public TestFixture()
        {
            InitializationCounter++;
        }
    }
}
