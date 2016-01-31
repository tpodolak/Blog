using System;
using System.Collections;
using System.Collections.Generic;

namespace AbusingCollectionInitializers
{
    public class StatusMessages : IEnumerable<StatusMessage>
    {
        private List<StatusMessage> messages;

        public StatusMessages()
        {
            this.messages = new List<StatusMessage>();
        }

        public StatusMessages(int capacity)
        {
            this.messages = new List<StatusMessage>(capacity);
        }

        public void Add(string text)
        {
            this.Add(new StatusMessage(text));
        }

        public void Add(StatusMessage message)
        {
            this.messages.Add(message);
        }

        public IEnumerator<StatusMessage> GetEnumerator()
        {
            return messages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return messages.GetEnumerator();
        }
    }
}
