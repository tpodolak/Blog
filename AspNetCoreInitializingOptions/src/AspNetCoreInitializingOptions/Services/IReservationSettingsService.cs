using System;

namespace AspNetCoreInitializingOptions.Services
{
    public interface IReservationSettingsService
    {
        TimeSpan GetMinimumConnectionTime();
    }
}