using AspNetCoreInitializingOptions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreInitializingOptions.Controllers
{
    [Route("api/[controller]")]
    public class OptionsController : Controller
    {
        private readonly IOptions<AvailabilitySearchOptions> availabilitySearchOptions;

        public OptionsController(IOptions<AvailabilitySearchOptions> availabilitySearchOptions)
        {
            this.availabilitySearchOptions = availabilitySearchOptions;
        }

        [HttpGet]
        public AvailabilitySearchOptions Get()
        {
            return availabilitySearchOptions.Value;
        }
    }
}
