using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtCharlist.Models
{
    public class Trait
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string TraitName { get; set; }

        [BsonElement("url")]
        [JsonPropertyName("url")]
        public string TraitUrl { get; set; }
    }
}
