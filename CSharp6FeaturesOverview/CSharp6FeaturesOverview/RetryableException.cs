using System;

namespace CSharp6FeaturesOverview
{
    public class RetryableException : Exception
    {
        public bool Retryable { get; private set; }
        public RetryableException(string message, bool retryable) : base(message)
        {
            Retryable = retryable;
        }
    }
}