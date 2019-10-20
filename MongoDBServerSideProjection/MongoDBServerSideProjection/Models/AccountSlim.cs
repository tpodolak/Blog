using MongoDB.Bson;

namespace MongoDBServerSideProjection.Models
{
    public class AccountSlim : IAccountDefinitions
    {
        public ObjectId Id { get; set; }
        
        public string Name { get; set; }
    }
}