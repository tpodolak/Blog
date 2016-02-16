using MockingDownstreamServices.Externals.Pricer.Models;

namespace MockingDownstreamServices.Externals.Pricer.Service
{
    public interface IPricer
    {
        Price GetPrice(GetPriceRequest request);
        TradingDates GetTradingDates();
    }
}
