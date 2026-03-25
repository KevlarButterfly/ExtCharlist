using System;
using System.Collections.Generic;
using System.Text;

namespace ExtCharlistLibrary.DTO
{
    public class CharacterRaceDTO
    {
        public string Id { get; set; }
        public string? RaceName { get; set; }
        public int RaceSpeed { get; set; }
        public string? AgeDescription { get; set; }
        public string? Size { get; set; }
        public string? SizeDescription { get; set; }
        public List<string>? RaceLanguages { get; set; }
        public string? LanguagesDescription { get; set; }
        public List<TraitDTO>? Traits { get; set; }
            }
}
