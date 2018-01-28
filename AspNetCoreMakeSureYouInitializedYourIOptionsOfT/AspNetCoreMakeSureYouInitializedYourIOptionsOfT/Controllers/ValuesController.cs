using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreMakeSureYouInitializedYourIOptionsOfT.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOptions<PaymentOptions> _paymentOptions;
        private readonly IOptions<NotificationOptions> _notificationOptions;

        public ValuesController(IOptions<PaymentOptions> paymentOptions, IOptions<NotificationOptions> notificationOptions)
        {
            _paymentOptions = paymentOptions ?? throw new ArgumentNullException(nameof(paymentOptions));
            _notificationOptions = notificationOptions ?? throw new ArgumentNullException(nameof(notificationOptions));
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var notificationOptions = _notificationOptions.Value;
            var paymentOptions = _paymentOptions.Value;
            
            return new string[] {"value1", "value2"};
        }
    }
}