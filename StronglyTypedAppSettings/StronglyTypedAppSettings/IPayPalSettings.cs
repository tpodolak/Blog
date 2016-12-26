namespace StronglyTypedAppSettings
{
    public interface IPayPalSettings : ISettings
    {
        string ConsumerSecret { get; }

        string RequestTokenUrl { get; }
    }
}