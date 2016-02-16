using System;

namespace MockingDownstreamServices.Pricer.Models
{
    public class TradingDates
    {
        public DateTime MaturityDate { get; set; } 
        public DateTime SettlementDate { get; set; }
    }
}