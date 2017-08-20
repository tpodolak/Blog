using RequestNullValueHandling.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace AspNetWebApiRequestPropertyNullParsing.Controllers
{
    public class ValuesController : ApiController
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
