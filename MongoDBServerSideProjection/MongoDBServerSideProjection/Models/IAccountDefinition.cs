using MongoDB.Bson;

namespace MongoDBServerSideProjection.Models
{
    public interface IAccountDefinition
    {
        ObjectId Id { get; set; }
        
        string Name { get; set; }
    }
}