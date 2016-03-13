using System.ServiceModel;

namespace ConcurrencyModeRevisited.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AudioServicePerSessionSingle : AudioService
    {

    }
}