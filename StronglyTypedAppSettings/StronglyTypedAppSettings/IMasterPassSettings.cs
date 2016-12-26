namespace StronglyTypedAppSettings
{
    public interface IMasterPassSettings : ISettings
    {
        string ConsumerKey { get; }

        string AccessTokenUrl { get; }
    }
}