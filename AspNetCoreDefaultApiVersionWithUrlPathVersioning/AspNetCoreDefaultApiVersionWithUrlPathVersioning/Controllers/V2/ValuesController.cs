using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDefaultApiVersionWithUrlPathVersioning.Controllers.V2
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"V2"};
        }
    }
}