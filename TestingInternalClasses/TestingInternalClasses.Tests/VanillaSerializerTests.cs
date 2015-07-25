
using System;
using NUnit.Framework;
using TestingInternalClasses.Lib;

namespace TestingInternalClasses.Tests
{
    [TestFixture]
    public class VanillaSerializerTests
    {
        [Test]
        public void SerializeThrowsArgumentNullExceptionWhenPassingNullValue()
        {
            var vanillaSerializer = new VanillaSerializer();
            Assert.Throws<ArgumentNullException>(() => vanillaSerializer.Serialize(null));
        }

        [Test]
        public void DeserializeThrowsArgumentNullExceptionWhenPassingNullValue()
        {
            var vanillaSerializer = new VanillaSerializer();
            Assert.Throws<ArgumentNullException>(() => vanillaSerializer.Deserialize<object>(null));
        }
    }
}
