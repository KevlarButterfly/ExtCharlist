using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtCharlistLibrary.Models
{
    public class CharacterClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? ClassName { get; set; }

        [BsonElement("hit_die")]
        [JsonPropertyName("hit_die")]
        public int ClassHitDice;

        [BsonElement("proficiency_choises")]
        [JsonPropertyName("proficiency_choises")]
        public List<ProficiencyChoice>? ClassProficiencyChoices;
    }
}
