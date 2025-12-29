using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtCharlist.Models
{
    public class CharacterRace
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? RaceName { get; set; }
        [BsonElement("speed")]
        [JsonPropertyName("speed")]
        public int RaceSpeed { get; set; }

        [BsonElement("ability_bonuses")]
        [JsonPropertyName("ability_bonuses")]
        public List<Dictionary<string, Dictionary<string, Object>>>? AbilityBonuses { get; set; }

        [BsonElement("alignment")]
        [JsonPropertyName("alignment")]
        public string? Alignment { get; set; }

        [BsonElement("age")]
        [JsonPropertyName("age")]
        public string? AgeDescription { get; set; }

        [BsonElement("size")]
        [JsonPropertyName("size")]
        public string? Size { get; set; }

        [BsonElement("size_description")]
        [JsonPropertyName("size_description")]
        public string? SizeDescription { get; set; }

        [BsonElement("languages")]
        [JsonPropertyName("languages")]
        public List<Language> RaceLanguages { get; set; }

        [BsonElement("language_desc")]
        [JsonPropertyName("language_desc")]
        public string? LanguagesDescription { get; set; }

        [BsonElement("traits")]
        [JsonPropertyName("traits")]
        public List<Trait>? RaceTraits { get; set; }
    }
}
