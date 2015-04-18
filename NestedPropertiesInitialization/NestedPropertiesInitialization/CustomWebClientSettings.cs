using System;

namespace NestedPropertyInitialization
{
    /// <summary>
    /// Some exemplary class to show nested property initializer
    /// </summary>
    public class CustomWebClientSettings
    {
        public TimeSpan Timeout { get; set; }
        public string Method { get; set; }
        public string[] Headers { get; set; }
        public string Encoding { get; set; }

        public override string ToString()
        {
            return this.Dump();
        }
    }
}