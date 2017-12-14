using FluentAssertions;
using Xunit;

namespace NullPropagationOperatorAndIfStatements
{
    public class AvailabilityScannerTests
    {
        // this test will fail due to wrong usage of null propagation operator
        [Fact]
        public void GetFirstPossibleFlight_ReturnsNull_WhenFlightsCollectionIsEmpty()
        {
            var availability = new Availability
            {
                Flights = null
            };
            
            var subject = new AvailabilityScanner();

            var result = subject.GetFirstPossibleFlight(availability);

            result.Should().BeNull();
        }
        
        [Fact]
        public void GetFirstPossibleFlightCorrect_ReturnsNull_WhenFlightsCollectionIsEmpty()
        {
            var availability = new Availability
            {
                Flights = null
            };
            
            var subject = new AvailabilityScanner();

            var result = subject.GetFirstPossibleFlightCorrect(availability);

            result.Should().BeNull();
        }
    }
}