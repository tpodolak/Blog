using JetBrains.Annotations;

namespace ResharperAnnotations
{
    public class CustomLogger
    {
        [StringFormatMethod("format")]
        public string LogError(string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}