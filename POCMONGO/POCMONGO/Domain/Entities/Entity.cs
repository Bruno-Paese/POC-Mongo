using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace POC_Mongo.Src.Domain.Entities
{
    public class Entity
    {
        protected static String DATABASE = "curso-node";

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
