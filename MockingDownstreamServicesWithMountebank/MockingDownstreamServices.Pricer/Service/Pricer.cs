using System.Configuration;
using System.Net;
using MockingDownstreamServices.Externals.Pricer.Models;
using Newtonsoft.Json;

namespace MockingDownstreamServices.Externals.Pricer.Service
{
    public class Pricer : IPricer
    {
        public TradingDates GetTradingDates()
        {
            using (var webClient = new WebClient())
            {
                var result = webClient.DownloadString(ConfigurationManager.AppSettings["MockingDownstreamServices.Externals.Pricer.GetTradingDates"]);
                return JsonConvert.DeserializeObject<TradingDates>(result);
            }
        }

        public Price GetPrice(GetPriceRequest request)
        {
            using (var webClient = new WebClient())
            {
                var result = webClient.UploadString(ConfigurationManager.AppSettings["MockingDownstreamServices.Externals.Pricer.GetPrice"], JsonConvert.SerializeObject(request));
                return JsonConvert.DeserializeObject<Price>(result);
            }
        }
    }
}