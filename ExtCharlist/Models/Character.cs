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

        [BsonElement("UserId")]
        [JsonPropertyName("UserId")]
        public string? UserId { get; set; }
        [BsonElement("CharacterName")]
        [JsonPropertyName("CharacterName")]
        public string? CharacterName { get; set; }

        [BsonElement("CharacterClass")]
        [JsonPropertyName("CharacterClass")]
        public CharacterClass? CharacterClass {  get; set; }

        [BsonElement("CharacterRace")]
        [JsonPropertyName("CharacterRace")]
        public CharacterRace? CharacterRace {  get; set; }

        [BsonElement("CharacterBackground")]
        [JsonPropertyName("CharacterBackground")]

        public CharacterBackground? CharacterBackground { get; set; }

        [BsonElement("CharacterTraits")]
        [JsonPropertyName("CharacterTraits")]
        public List<Trait> CharacterTraits {  get; set; }

        //[BsonElement("Character")]
        //[JsonPropertyName("CharacterBackground")]

    }
}
