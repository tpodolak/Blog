using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RequestNullValueHandling.Models;

namespace AspNetCoreRequestPropertyNullParsing.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public IEnumerable<string> Post([FromBody] CreatePassengerRequest request)
        {
            return new string[] 
            {
                request.PassengerNumber.ToString(),
                request.PassengerType.ToString()
            };
        }
    }
}