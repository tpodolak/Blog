namespace UsingStronglyTypedEntityIDsWithMongoDb
{
    public class FlightId : TypedIdValueBase
    {
        public FlightId(string value) : base(value)
        {
        }
    }
}