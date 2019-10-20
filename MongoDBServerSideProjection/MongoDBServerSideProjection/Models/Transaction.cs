using System;
using MongoDB.Bson;

namespace MongoDBServerSideProjection.Models
{
    public class Transaction
    {
        public ObjectId Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime ModifiedAt { get; set; }
    }
}