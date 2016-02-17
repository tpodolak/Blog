using System;
using MockingDownstreamServices.Externals.Pricer.Service;
using MockingDownstreamServices.Facade.Models;
using GetPriceRequest = MockingDownstreamServices.Externals.Pricer.Models.GetPriceRequest;
using Price = MockingDownstreamServices.Facade.Models.Price;
using TradingDates = MockingDownstreamServices.Facade.Models.TradingDates;

namespace MockingDownstreamServices.Facade
{
    public class BookingFacade : IBookingFacade
    {
        public Response<Price> Price(Models.GetPriceRequest request)
        {
            // in real life scenario Pricer should be injected
            var pricerService = new Pricer();
            var response = new Response<Price>();
            double spot;

            try
            {
                var tradingDates = pricerService.GetTradingDates();
                var price = pricerService.GetPrice(new GetPriceRequest
                {
                    IsAdvised = request.IsAdvised
                });

                spot = price.Strike;
                // some fancy logic based on downstream response
                if (spot > 1)
                {
                    spot += 0.05;
                    response.Messages.Add(new Message { StatusCode = StatusCodes.Warning, Text = "Spot was adjusted" });
                }
                response.Result = new Price
                {
                    TradingDates = new TradingDates
                    {
                        MaturityDate = tradingDates.MaturityDate,
                        SettlementDate = tradingDates.SettlementDate
                    },
                    Spot = spot
                };
            }
            catch (Exception ex)
            {
                response.Messages.Add(new Message { StatusCode = StatusCodes.Error, Text = "Could not retrieve the price" });
            }

            return response;
        }
    }
}