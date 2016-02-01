using System;
using System.Collections;
using System.Collections.Generic;

namespace AbusingCollectionInitializers
{
    public class StatusMessages : IEnumerable<StatusMessage>
    {
        private List<StatusMessage> messages = new List<StatusMessage>();

        public void Add(string text)
        {
            this.Add(new StatusMessage(text));
        }

        public void Add(int statusCode, string text, string sourceSystem)
        {
            this.Add(new StatusMessage(text) { StatusCode = statusCode,SourceSystem = sourceSystem });
        }

        public void Add(int statusCode, string text)
        {
            this.Add(new StatusMessage(text) { StatusCode = statusCode });
        }

        public void Add(StatusMessage message)
        {
            this.messages.Add(message);
        }

        public IEnumerator<StatusMessage> GetEnumerator()
        {
            return this.messages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.messages.GetEnumerator();
        }
    }
}
