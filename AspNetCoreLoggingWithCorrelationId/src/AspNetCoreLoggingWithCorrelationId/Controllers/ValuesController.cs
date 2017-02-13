using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreLoggingWithCorrelationId.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            logger.LogInformation("Get method requested");

            await PreprocessRequest(nameof(Get));

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task PreprocessRequest(string actionName)
        {
            logger.LogInformation($"Log from {actionName} action, from thread={Thread.CurrentThread.ManagedThreadId}");

            await
                Task.Run(() => logger.LogInformation($"Log from {actionName}, from thread {Thread.CurrentThread.ManagedThreadId} assigned by scheduler"))
                    .ConfigureAwait(continueOnCapturedContext: false);

            logger.LogInformation($"Log from {actionName} action, from async continuation, from thread {Thread.CurrentThread.ManagedThreadId}");

            var thread =
                new Thread(() => logger.LogInformation($"Log from {actionName} action, from explicitly created thread {Thread.CurrentThread.ManagedThreadId}"));
            thread.Start();
            thread.Join();
        }
    }
}
