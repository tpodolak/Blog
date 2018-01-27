using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace AspNetCoreMakeSureYouInitializedYourIOptionsOfT
{
    // first attempt of validation
    public class ValidatableOptionsFactory<TOptions> : OptionsFactory<TOptions> where TOptions : class, new()
    {
        private readonly IEnumerable<IConfigureOptions<TOptions>> _setups;
        private readonly IEnumerable<IPostConfigureOptions<TOptions>> _postConfigures;

        public ValidatableOptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures)
            : base(setups, postConfigures)
        {
            _setups = setups;
            _postConfigures = postConfigures;
            if (typeof(TOptions).FullName.StartsWith("AspNetCoreMakeSureYouInitializedYourIOptionsOfT") && setups.Any() == false && postConfigures.Any() == false)
            {
                throw new InvalidOperationException($"No configuration options or post configuration options was found to configure {typeof(TOptions)}");
            }
        }
    }
}