using System.Runtime.Serialization;

namespace MockingDownstreamServices.Facade.Models
{
    [DataContract]
    public class Price
    {
        [DataMember]
        public TradingDates TradingDates { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public double Strike { get; set; }

        [DataMember]
        public double Spot { get; set; }

        [DataMember]
        public double Calculated { get; set; }
    }
}