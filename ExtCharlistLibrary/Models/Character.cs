using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtCharlistLibrary.Models
{
    
    public class Character
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserId")]
        [JsonPropertyName("UserId")]
        public string? UserId { get; set; }
        [BsonElement("name")]
        [JsonPropertyName("CharacterName")]
        public string? CharacterName { get; set; }

        [BsonElement("level")]
        [JsonPropertyName("level")]
        public int? level { get; set; }

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
        public List<Trait>? CharacterTraits {  get; set; }

        [BsonElement("speed")]
        [JsonPropertyName("CharacterSpeed")]
        public int? CharacterSpeed { get; set; }

        [BsonElement("alignment")]
        [JsonPropertyName("CharacterAlignment")]
        public string CharacterAlignment { get; set; }
        [BsonElement("age")]
        [JsonPropertyName("CharacterAge")]
        public int? CharacterAge { get; set; }
        [BsonElement("str")]
        [JsonPropertyName("str")]
        public int? Strength { get; set; } = 10;
        [BsonElement("dext")]
        [JsonPropertyName("dext")]
        public int? Dexterity{get;set;} = 10;
        [BsonElement("const")]
        [JsonPropertyName("const")]
        public int? Constitution{get;set;} = 10;
        [BsonElement("wis")]
        [JsonPropertyName("wis")]
        public int? Wisdom{get;set;} = 10;
        [BsonElement("int")]
        [JsonPropertyName("int")]
        public int? Intelligence{get;set;} = 10;
        [BsonElement("cha")]
        [JsonPropertyName("cha")]
        public int? Charisma{get;set;} = 10;

        //[BsonElement("Character")]
        //[JsonPropertyName("CharacterBackground")]

    }
}
