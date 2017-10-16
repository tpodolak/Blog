using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASP.NETCoreCuriousCaseOfMissingIOptionsOfTArrayItem.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;

        public ValuesController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
        
        // GET api/values
        [HttpGet]
        public List<PaymentMethod> Get()
        {
            return _appSettings.Value.PaymentMethods;
        }
    }
}
