using System;

namespace NestedPropertyInitialization
{
    /// <summary>
    /// Some examplorary class to show nested property initializer
    /// </summary>
    public class WebClient
    {
        public WebClientSettings Settings { get; set; }

        public WebClient()
        {
            Settings = new WebClientSettings
            {
                Encoding = "UTF-8",
                Headers = new[] { "FirstHeader", "SecondHeader" },
                Timeout = TimeSpan.FromSeconds(30),
                Method = "GET"
            };
        }
    }
}