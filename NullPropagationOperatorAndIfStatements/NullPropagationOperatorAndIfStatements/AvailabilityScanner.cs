using System.Linq;

namespace NullPropagationOperatorAndIfStatements
{
    public class AvailabilityScanner
    {
        public Flight GetFirstPossibleFlight(Availability availability)
        {
            if (availability.Flights?.Any() == false)
            {
                return null;
            }
            
            // more magic in here
            return availability.Flights.First();
        }

        public Flight GetFirstPossibleFlightCorrect(Availability availability)
        {
            if ((availability.Flights?.Any() ?? false) == false)
            {
                return null;
            }
            
            // more magic in here
            return availability.Flights.First();
        }
    }
}