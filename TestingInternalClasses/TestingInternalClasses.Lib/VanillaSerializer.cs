using System;
using System.IO;

namespace TestingInternalClasses.Lib
{
    internal class VanillaSerializer : ISerializer
    {
        public Stream Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // rest of the logic goes here
            return null;
        }

        public T Deserialize<T>(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            // rest of the logic goes here
            return default(T);
        }
    }
}
