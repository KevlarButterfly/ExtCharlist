using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
namespace ExtCharlist.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("UserEmail")]
        [JsonPropertyName("UserEmail")]
        public string? userEmail { get; set; }

        [BsonElement("UserName")]
        [JsonPropertyName("UserName")]
        public string? username { get; set; }

        [BsonElement("UserPassword")]
        [JsonPropertyName("UserPassword")]
        public string? password { get; set; }

        [BsonElement("UserRole")]
        [JsonPropertyName("UserRole")]
        public string? userRole { get; set; }
    }
}
