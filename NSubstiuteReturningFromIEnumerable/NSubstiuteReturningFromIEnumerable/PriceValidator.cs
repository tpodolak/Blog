using System.Collections.Generic;
using System.Linq;

namespace NSubstiuteReturningFromIEnumerable
{
    public class PriceValidator : IValidator<Price>
    {
        private readonly IEnumerable<IValidator<Price>> _innerValidators;

        public PriceValidator(IEnumerable<IValidator<Price>> innerValidators)
        {
            _innerValidators = innerValidators;
        }

        public bool IsValid(Price input)
        {
            return _innerValidators.Any() && _innerValidators.All(validator => validator.IsValid(input));
        }
    }
    
    public interface IValidator<T>
    {
        bool IsValid(T input);
    }

    public class Price
    {
    }
}