using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System;
using Microsoft.Extensions.Options;

namespace AspNetCoreMakeSureYouInitializedYourIOptionsOfT
{
    public class ValidatableOptionsFactory<TOptions> : OptionsFactory<TOptions> where TOptions : class, new()
    {
        private static readonly string NamespacePrefix = typeof(Program).Namespace.Split('.').First();

        public ValidatableOptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures)
            : base(setups, postConfigures)
        {
            if (typeof(TOptions).Namespace.StartsWith(NamespacePrefix) && setups.Any() == false &&
                postConfigures.Any() == false)
            {
                throw new InvalidOperationException(
                    $"No configuration options or post configuration options was found to configure {typeof(TOptions)}");
            }
        }
    }
}