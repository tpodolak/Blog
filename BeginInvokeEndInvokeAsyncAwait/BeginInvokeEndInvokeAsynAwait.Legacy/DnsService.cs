using System;
using System.Net;

namespace BeginInvokeEndInvokeAsynAwait.Legacy
{
    public class DnsService
    {
        public IAsyncResult BeginGetHostEntry(string hostNameOrAddress, AsyncCallback requestCallback, object stateObject)
        {
            return Dns.BeginGetHostEntry(hostNameOrAddress, requestCallback, stateObject);
        }

        public IPHostEntry EndGetHostEntry(IAsyncResult asyncResult)
        {
            return Dns.EndGetHostEntry(asyncResult);
        }
    }
}
