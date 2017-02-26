using System;

namespace AspNetCoreInitializingOptions.Services
{
    public class ReservationSettingsService : IReservationSettingsService
    {
        public TimeSpan GetMinimumConnectionTime()
        {
            return TimeSpan.FromMinutes(30);
        }
    }
}