using System;
using System.Runtime.Serialization;

namespace MockingDownstreamServices.Facade.Models
{
    [DataContract]
    public class TradingDates
    {
        [DataMember]
        public DateTime MaturityDate { get; set; }

        [DataMember]
        public DateTime SettlementDate { get; set; }
    }
}