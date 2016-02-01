namespace AbusingCollectionInitializers
{
    public class StatusMessage
    {
        public string Text { get; set; } = string.Empty;
        public string SourceSystem { get; set; } = string.Empty;
        public int StatusCode { get; set; }

        public StatusMessage()
        {
        }

        public StatusMessage(string text)
        {
            this.Text = text;
        }

        public override string ToString()
        {
            return $"Text: {this.Text} StatusCode: {this.StatusCode} SourceSystem: {this.SourceSystem}";
        }
    }
}
