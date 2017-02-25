using AspNetCoreInitializingOptions.Models;
using Microsoft.Extensions.Options;

namespace AspNetCoreInitializingOptions.Services
{
    public class AvailabilitySearchOptionsSetupService : IConfigureOptions<AvailabilitySearchOptions>
    {
        private readonly IReservationSettingsService reservationSettingsService;

        public AvailabilitySearchOptionsSetupService(IReservationSettingsService reservationSettingsService)
        {
            this.reservationSettingsService = reservationSettingsService;
        }

        public void Configure(AvailabilitySearchOptions options)
        {
            options.MinimumConnectionTime = reservationSettingsService.GetMinimumConnectionTime();
        }
    }
}