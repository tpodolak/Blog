using MockingDownstreamServices.Pricer.Models;

namespace MockingDownstreamServices.Pricer.Service
{
    public interface IPricer
    {
        Price GetPrice(GetPriceRequest request);
        TradingDates GetTradingDates();
    }
}
