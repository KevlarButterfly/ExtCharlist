using ExtCharlistLibrary.Models;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ExtCharlistLibrary.DTO
{
    public class CharacterDTO
    {
        public string? Id { get; set; }
        public string UserID { get; set; }
        public string? CharacterName { get; set; }
        
        public CharacterClassDTO? CharacterClass { get; set; }

        public CharacterRaceDTO? CharacterRace { get; set; }


        public CharacterBackground? CharacterBackground { get; set; }

        public List<Trait>? CharacterTraits { get; set; }

        public int? CharacterSpeed { get; set; }

        public string? CharacterAlignment { get; set; }
        public int? CharacterAge { get; set; }
    }
}
