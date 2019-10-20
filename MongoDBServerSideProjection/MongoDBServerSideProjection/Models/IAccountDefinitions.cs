using MongoDB.Bson;

namespace MongoDBServerSideProjection.Models
{
    public interface IAccountDefinitions
    {
        ObjectId Id { get; set; }
        
        string Name { get; set; }
    }
}