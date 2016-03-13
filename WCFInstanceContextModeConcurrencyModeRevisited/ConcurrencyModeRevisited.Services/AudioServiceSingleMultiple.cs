using System.ServiceModel;

namespace ConcurrencyModeRevisited.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AudioServiceSingleMultiple : AudioService
    {
         
    }
}