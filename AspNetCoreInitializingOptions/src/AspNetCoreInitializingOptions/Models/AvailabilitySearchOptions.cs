using System;

namespace AspNetCoreInitializingOptions.Models
{
    public class AvailabilitySearchOptions
    {
        public int FlexDaysIn { get; set; }

        public int FlexDaysOut { get; set; }

        public TimeSpan MinimumConnectionTime { get; set; }

        public TimeSpan MinimumDepartureTime { get; set; }
    }
}