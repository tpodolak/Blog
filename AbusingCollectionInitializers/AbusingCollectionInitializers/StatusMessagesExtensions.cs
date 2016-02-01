namespace AbusingCollectionInitializers
{
    public static class StatusMessagesExtensions
    {
        public static void Add(this StatusMessages statusMessages, int statusCode)
        {
            statusMessages.Add(new StatusMessage() { StatusCode = statusCode });
        }
    }
}
