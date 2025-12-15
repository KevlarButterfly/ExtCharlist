using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtCharlist.Models
{
    public class CharacterClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string? ClassName { get; set; }

        [BsonElement("hit-die")]
        [JsonPropertyName("hit-die")]
        public int ClassHitDice;

        [BsonElement("proficiency_choises")]
        [JsonPropertyName("proficiency_choises")]
        public List<ProficiencyChoice>? ClassProficiencyChoices;
    }
}
