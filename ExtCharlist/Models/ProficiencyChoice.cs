using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtCharlist.Models
{
    public class ProficiencyChoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("desc")]
        [JsonPropertyName("desc")]
        public string? ChoiceDescriprion;

        [BsonElement("choose")]
        [JsonPropertyName("choose")]
        public int ChooseNum;

        //[BsonElement("")]
        //[JsonPropertyName("")]
    }
}
