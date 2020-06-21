using System.Collections.Generic;

namespace UsingStronglyTypedEntityIDsWithMongoDb
{
    public class Flight
    {
        public FlightId Id { get; }

        public IReadOnlyList<FlightId> ConnectedFlights { get; }

        public Flight(FlightId id, IReadOnlyList<FlightId> connectedFlights)
        {
            Id = id;
            ConnectedFlights = connectedFlights;
        }
    }
}