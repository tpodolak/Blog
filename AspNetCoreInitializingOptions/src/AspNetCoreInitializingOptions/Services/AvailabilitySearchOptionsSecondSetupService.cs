using System;
using AspNetCoreInitializingOptions.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCoreInitializingOptions.Services
{
    public class AvailabilitySearchOptionsSecondSetupService : IConfigureOptions<AvailabilitySearchOptions>
    {
        private readonly ILogger<AvailabilitySearchOptionsSecondSetupService> logger;

        public AvailabilitySearchOptionsSecondSetupService(ILogger<AvailabilitySearchOptionsSecondSetupService> logger)
        {
            this.logger = logger;
        }

        public void Configure(AvailabilitySearchOptions options)
        {
            this.logger.LogInformation($"Calling second {typeof(IConfigureOptions<AvailabilitySearchOptions>)} service");
            options.MinimumDepartureTime = options.MinimumConnectionTime.Add(TimeSpan.FromMinutes(30));
        }
    }
}