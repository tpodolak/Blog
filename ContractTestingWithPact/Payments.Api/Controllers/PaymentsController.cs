using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Payments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] {string.Empty};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Payment Get(string id)
        {
            return new Payment(); 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Payment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = "name";
        
        public decimal Amount { get; set; }

        public object Transactions = new[]
        {
            new {id = Guid.NewGuid().ToString(), amount = 1},
            new {id = Guid.NewGuid().ToString(), amount = 1},
            new {id = Guid.NewGuid().ToString(), amount = 1}
        };
    }
}