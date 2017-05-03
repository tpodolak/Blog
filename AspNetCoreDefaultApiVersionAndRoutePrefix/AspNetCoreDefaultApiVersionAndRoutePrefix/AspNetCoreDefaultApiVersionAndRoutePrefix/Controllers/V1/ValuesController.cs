using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDefaultApiVersionAndRoutePrefix.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"V1"};
        }
    }
}