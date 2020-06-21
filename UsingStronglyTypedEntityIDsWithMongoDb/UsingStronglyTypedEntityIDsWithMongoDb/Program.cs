using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace UsingStronglyTypedEntityIDsWithMongoDb
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TempDatabase");
            var collection = database.GetCollection<Flight>("Availability");

            var firstFlightRawId = ObjectId.GenerateNewId().ToString();
            var secondFlightRawId = ObjectId.GenerateNewId().ToString();
        }
    }
}