using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
namespace ExtCharlist.Models
{
    public class Ability
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? Name;

        [BsonElement("url")]
        [JsonPropertyName("url")]
        public string Url;
    }
}
