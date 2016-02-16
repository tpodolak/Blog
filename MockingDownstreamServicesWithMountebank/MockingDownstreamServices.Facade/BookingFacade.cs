using MockingDownstreamServices.Externals.Pricer.Models;
using MockingDownstreamServices.Externals.Pricer.Service;
using Price = MockingDownstreamServices.Facade.Models.Price;
using TradingDates = MockingDownstreamServices.Facade.Models.TradingDates;

namespace MockingDownstreamServices.Facade
{
    public class BookingFacade : IBookingFacade
    {
        public Price Price()
        {
            var pricerService = new Pricer();
            var price = pricerService.GetPrice(new GetPriceRequest());
            var tradingDates = pricerService.GetTradingDates();
            // do some callculation and business logic
            return new Price
            {
                TradingDates = new TradingDates
                {
                    MaturityDate = tradingDates.MaturityDate,
                    SettlementDate = tradingDates.SettlementDate
                }
            };
        }
    }
}