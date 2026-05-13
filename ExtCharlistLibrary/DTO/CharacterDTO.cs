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
        
        public int? level { get; set; }
        public CharacterClassDTO? CharacterClass { get; set; }

        public CharacterRaceDTO? CharacterRace { get; set; }


        public CharacterBackground? CharacterBackground { get; set; }

        public List<Trait>? CharacterTraits { get; set; }

        public int? CharacterSpeed { get; set; }

        public string? CharacterAlignment { get; set; }
        public int? CharacterAge { get; set; }


        public int? Strength { get; set; } = 10;
        public int? Dexterity { get; set; } = 10;
        public int? Constitution{get;set;} = 10;
        public int? Wisdom{get;set;} = 10;
        public int? Intelligence{get;set;} = 10;
        public int? Charisma{get;set;} = 10;

    }
}
