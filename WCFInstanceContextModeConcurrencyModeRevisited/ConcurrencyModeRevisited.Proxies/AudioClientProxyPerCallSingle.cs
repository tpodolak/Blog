using System.ServiceModel;
using ConcurrencyModeRevisited.Contracts;

namespace ConcurrencyModeRevisited.Proxies
{
    public class AudioClientProxyPerCallSingle : AudioClientProxy
    {
        public AudioClientProxyPerCallSingle() : base("PerCallSingle")
        {
        }
    }
}
