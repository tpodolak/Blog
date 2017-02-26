using AspNetCoreInitializingOptions.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCoreInitializingOptions.Services
{
    public class AvailabilitySearchOptionsSetupService : IConfigureOptions<AvailabilitySearchOptions>
    {
        private readonly ILogger<AvailabilitySearchOptionsSetupService> logger;
        private readonly IReservationSettingsService reservationSettingsService;

        public AvailabilitySearchOptionsSetupService(ILogger<AvailabilitySearchOptionsSetupService> logger ,IReservationSettingsService reservationSettingsService)
        {
            this.logger = logger;
            this.reservationSettingsService = reservationSettingsService;
        }

        public void Configure(AvailabilitySearchOptions options)
        {
            this.logger.LogInformation($"Calling first {typeof(IConfigureOptions<AvailabilitySearchOptions>)} service");
            options.MinimumConnectionTime = reservationSettingsService.GetMinimumConnectionTime();
        }
    }
}