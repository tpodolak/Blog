using System;

namespace MockingDownstreamServices.Externals.Pricer.Models
{
    public class TradingDates
    {
        public DateTime MaturityDate { get; set; } 
        public DateTime SettlementDate { get; set; }
    }
}