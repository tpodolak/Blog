using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NSubstituteAutoMocker;
using Xunit;

namespace NSubstiuteReturningFromIEnumerable
{
    public class PriceValidatorTests
    {
        [Fact(Skip = "Wrong way of returning enumerator")]
        public void IsValid_ReturnsTrue_WhenAllInnerValidatorsAreValid()
        {
            var automock = new NSubstituteAutoMocker<PriceValidator>();
            var innerValidators = new List<IValidator<Price>>
            {
                Substitute.For<IValidator<Price>>(),
            };
            innerValidators.ForEach(validator => validator.IsValid(Arg.Any<Price>()).Returns(true));
            
            automock.Get<IEnumerable<IValidator<Price>>>().GetEnumerator().Returns(innerValidators.GetEnumerator());
            
            var result = automock.ClassUnderTest.IsValid(new Price());

            innerValidators.ForEach(validator => validator.Received(1).IsValid(Arg.Any<Price>()));
            result.Should().BeTrue();
        }
        
        [Fact]
        public void IsValid_ReturnsTrue_WhenAllInnerValidatorsAreValid_WorkingTest()
        {
            var automock = new NSubstituteAutoMocker<PriceValidator>();
            var innerValidators = new List<IValidator<Price>>
            {
                Substitute.For<IValidator<Price>>(),
            };
            innerValidators.ForEach(validator => validator.IsValid(Arg.Any<Price>()).Returns(true));
            
            automock.Get<IEnumerable<IValidator<Price>>>().GetEnumerator().Returns(callInfo => innerValidators.GetEnumerator());
            
            var result = automock.ClassUnderTest.IsValid(new Price());

            innerValidators.ForEach(validator => validator.Received(1).IsValid(Arg.Any<Price>()));
            result.Should().BeTrue();
        }
    }
}