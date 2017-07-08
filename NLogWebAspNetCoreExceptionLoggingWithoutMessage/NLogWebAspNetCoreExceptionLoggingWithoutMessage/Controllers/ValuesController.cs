using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

namespace NLogWebAspNetCoreExceptionLoggingWithoutMessage.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private static readonly ILogger NlogLogger = LogManager.GetCurrentClassLogger();
        
        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var exception = new Exception();
            _logger.LogTrace("Log trace");
            _logger.LogDebug("Log debug");
            _logger.LogInformation("Log information");
            _logger.LogWarning("Log warning");
            _logger.LogError(exception.HResult, exception, string.Empty); // this one will not be logged
            _logger.LogCritical(exception.HResult, exception, string.Empty); // this one will not be logged as well
            
            // you have to specif not empty (might be whitespaced) message when logging exception
            _logger.LogError(exception.HResult, exception, " ");
            _logger.LogCritical(exception.HResult, exception, " ");
//            
            // as opposite to the original behavior of NLog
            // NlogLogger.Error(exception);
            
            return new string[] {"value1", "value2"};
        }
    }
}