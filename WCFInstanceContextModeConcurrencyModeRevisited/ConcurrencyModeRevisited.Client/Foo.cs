using System;

namespace ConcurrencyModeRevisited.Client
{
    public class Foo: IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}