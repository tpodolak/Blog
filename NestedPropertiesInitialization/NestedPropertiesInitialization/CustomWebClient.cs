using System;

namespace NestedPropertyInitialization
{
    /// <summary>
    /// Some exemplary class to show nested property initializer
    /// </summary>
    public class CustomWebClient
    {
        public CustomWebClientSettings Settings { get; set; }

        public CustomWebClient()
        {
            Settings = new CustomWebClientSettings
            {
                Encoding = "UTF-8",
                Headers = new[] { "FirstHeader", "SecondHeader" },
                Timeout = TimeSpan.FromSeconds(30),
                Method = "GET"
            };
        }
    }
}