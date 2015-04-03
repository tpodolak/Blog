using System;

namespace NInjectInterceptors
{
    public class NotNullAttribute : ArgumentValidationAttribute
    {
        public override void ValidateArgument(object value,string argumentName)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName, string.Format(" \"{0}\" can not be null", argumentName));
        }
    }
}
