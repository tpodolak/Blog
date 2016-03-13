using System.ServiceModel;

namespace ConcurrencyModeRevisited.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AudioServiceSingleSingle : AudioService
    {

    }
}