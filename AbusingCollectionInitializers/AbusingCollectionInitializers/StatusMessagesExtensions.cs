namespace AbusingCollectionInitializers
{
    public static class StatusMessagesExtensions
    {
        public static void Add(this StatusMessages statusMessages, int statusCode)
        {
            statusMessages.Add(new StatusMessage() { StatusCode = statusCode });
        }

        public static void Add(this StatusMessages statusMessages, int statusCode, string text)
        {
            statusMessages.Add(new StatusMessage(text) { StatusCode = statusCode });
        }
    }
}
