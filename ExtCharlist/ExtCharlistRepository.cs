

using System.Text.Json;
using System.Text.Json.Nodes;
using ExtCharlist.Controllers;
using ExtCharlist.Models;
using ExtCharlist.Services;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace ExtCharlist
{
    public class ExtCharlistRepository
    {

        List<string>? classes = ["barbarian", "bard", "cleric", "druid", "fighter", "monk", "paladin", "ranger", "rogue", "sorcerer", "warlock", "wizard"];
        List<string>? races = ["dragonborn", "dwarf", "elf", "gnome", "half-elf", "half-orc", "halfling", "human", "tiefling"];
        public ExtCharlistDatabaseSettigs? _settigs = new ExtCharlistDatabaseSettigs();
        public CharactersService? charService;
        public CharacterController? charController;
        private IOptions<ExtCharlistDatabaseSettigs>? _settings;
        public CharacterRaceService? charRaceService;
        public CharacterRaceController? charRaceController;

        public ExtCharlistRepository( CharacterRaceService? charRaceService, CharactersService? charactersService)
        {
            this.charRaceService = charRaceService;
            charService = charactersService;
        }




        public async void WriteAsync()
        {

            //charService =  new CharactersService(_settings)

            List<string> races_json = await GetDataAsync();
            foreach (string race in races_json) {
                CharacterRace? characterRace = JsonSerializer.Deserialize<CharacterRace>(race);
                if (characterRace != null) { 
                    await charRaceService.CreateAsync(characterRace);
                }
            }
        }
        



        
        public async Task<List<string>> GetDataAsync()
        {
            List<string> racesJson = new List<string>();
            for (int i = 0; i < races.Count; i++)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://www.dnd5eapi.co/api/2014/races/" + races[i]);
                request.Headers.Add("Accept", "application/json");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responce_str = await response.Content.ReadAsStringAsync();
                racesJson.Add(responce_str);

                JsonNode jsonNode = JsonNode.Parse(responce_str);
                Console.WriteLine(jsonNode.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
            }
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, "https://www.dnd5eapi.co/api/2014/traits/brave");
            //request.Headers.Add("Accept", "application/json");
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            return racesJson;
        }




    }
}
