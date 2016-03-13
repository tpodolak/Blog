using System.ServiceModel;

namespace ConcurrencyModeRevisited.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AudioServicePerSessionMultiple : AudioService
    {

    }
}