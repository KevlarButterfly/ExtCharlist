

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
        List<string> classes = ["barbarian", "bard", "cleric", "druid", "fighter", "monk", "paladin", "ranger", "rogue", "sorcerer", "warlock", "wizard"];
        List<string> races = ["dragonborn", "dwarf", "elf", "gnome", "half-elf", "half-orc", "halfling", "human", "tiefling"];
        public ExtCharlistDatabaseSettigs _settigs = new ExtCharlistDatabaseSettigs();
        public CharactersService service;
        public CharacterController controller;
        private IOptions<ExtCharlistDatabaseSettigs> _settings;

        public async void WriteAsync()
        {
            service =  new CharactersService(_settings);
            
            List<string> classes_json = await GetDataAsync();
            foreach (string cls in classes_json) {
                
            }
        }
        



        
        public async Task<List<string>> GetDataAsync()
        {
            List<string> classesJson = new List<string>();
            //for (int i = 0; i < races.Count; i++) {
            //    var client = new HttpClient();
            //    var request = new HttpRequestMessage(HttpMethod.Get, "https://www.dnd5eapi.co/api/2014/races/" + races[i]);
            //    request.Headers.Add("Accept", "application/json");
            //    var response = await client.SendAsync(request);
            //    response.EnsureSuccessStatusCode();
            //    string responce_str = await response.Content.ReadAsStringAsync();
            //    classesJson.Add(responce_str);
                
            //    JsonNode jsonNode = JsonNode.Parse(responce_str);
            //    Console.WriteLine(jsonNode.ToJsonString(new System.Text.Json.JsonSerializerOptions{ WriteIndented=true}));
            //}
            var n_client = new HttpClient();
            var n_request = new HttpRequestMessage(HttpMethod.Get, "https://www.dnd5eapi.co/api/2014/traits/:index");
            n_request.Headers.Add("Accept", "application/json");
            var n_response = await n_client.SendAsync(n_request);
            n_response.EnsureSuccessStatusCode();
            string n_responce_str = await n_response.Content.ReadAsStringAsync();
            JsonNode n_jsonNode = JsonNode.Parse(n_responce_str);
            Console.WriteLine(n_jsonNode.ToJsonString(new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
            return classesJson;
        }



    }
}
