using System;

namespace RequestNullValueHandling.Models
{
    public class CreatePassengerRequest
    {
        public int PassengerNumber { get; set; }
        
        public int PassengerType { get; set; }
    }
}