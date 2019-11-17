using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace AlpineMissingCurrencySymbol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> Get(string cultureCode = "de-DE")
        {
            var cultureInfo = CultureInfo.CreateSpecificCulture(cultureCode);
            var price = 10m;
            
            return new
            {
                price,
                formattedPrice = price.ToString("C", cultureInfo),
                currencySymbol = cultureInfo.NumberFormat.CurrencySymbol
            };
        }
    }
}