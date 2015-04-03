using System;

namespace NInjectInterceptors
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public abstract class ArgumentValidationAttribute : Attribute
    {
        public abstract void ValidateArgument(object value, string argumentName);

    }
}
