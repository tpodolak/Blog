using System.IO;

namespace TestingInternalClasses.Lib
{
    internal interface ISerializer
    {
        Stream Serialize(object obj);
        T Deserialize<T>(Stream stream);
    }
}