using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtCharlist.Models
{
    
    public class Character
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("CharacterName")]
        [JsonPropertyName("CharacterName")]
        public string? CharacterName { get; set; }
        public CharacterClass? CharacterClass {  get; set; }
        public CharacterRace? CharacterRace {  get; set; }

    }
}
