using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCustomLoggerAndNLogCallsiteIssue.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogTrace("Get method called trace");
            _logger.LogWarning("Get method called warning");
            _logger.LogError("Get method called error");
            _logger.LogInformation("Get method called information");

            return new string[] {"value1", "value2"};
        }
    }
}