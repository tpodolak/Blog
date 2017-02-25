namespace AspNetCoreInitializingOptions.Services
{
    public class ReservationSettingsService : IReservationSettingsService
    {
        public int GetMinimumConnectionTime()
        {
            return 1;
        }
    }
}