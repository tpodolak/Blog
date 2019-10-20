using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDBServerSideProjection.Models
{
    public class Account : IAccountDefinitions
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}