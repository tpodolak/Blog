using System;

namespace NestedPropertyInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var defaultSettings = new CustomWebClient().Settings;
            var webClientReplacedSettings = new CustomWebClient
            {
                Settings = new CustomWebClientSettings
                {
                    Encoding = "UTF-8",
                    Method = "POST"
                }
            };

            Console.WriteLine("Default settings:");
            Console.WriteLine(defaultSettings.Dump());
            PrintComparedSettings(defaultSettings, webClientReplacedSettings.Settings);
            Console.WriteLine();
            // of course we can just set properties Encoding and Method without creating Settings object           
            var webClientDotOperator = new CustomWebClient();
            webClientDotOperator.Settings.Encoding = "UTF-8";
            webClientDotOperator.Settings.Method = "POST";
            // but there is a cooler syntax for that
            Console.WriteLine("Settings nested properties using nested object initializer");
            webClientDotOperator = new CustomWebClient { Settings = { Encoding = "UTF-8", Method = "POST" } };
            PrintComparedSettings(defaultSettings, webClientDotOperator.Settings);
            Console.ReadKey();
        }

        private static void PrintComparedSettings(CustomWebClientSettings defaultSettings, CustomWebClientSettings replacedSettings)
        {
            Console.WriteLine("Replaced setting \"Encoding\" now has value {0} as intended",
                replacedSettings.Encoding);
            Console.WriteLine("Replaced setting \"Method\" now has value {0} as intended",
                replacedSettings.Method);
            Console.WriteLine("Default setting \"Headers\"  {0} replaced settings headers: {1}",
                string.Join(",", defaultSettings.Headers), string.Join(",", replacedSettings.Headers ?? new[] { "NULL" }));
            Console.WriteLine("Default setting \"Timeout\" {0} replaced settings timeout: {1}", defaultSettings.Timeout,
                replacedSettings.Timeout);
        }
    }
}