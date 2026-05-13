using ExtCharistWebApp;
using ExtCharistWebApp.Services;
using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Net;

namespace ExtCharlistWebApp.Services
{
    public class CharacterService : ICharacterService
    {
        private ConnectionSettings _settings;
        private HttpClient _httpClient;
        private ICookieService _cookieService;
        private IEnumerable<CharacterDTO> charactersCached { get; set; }
        public CharacterService(IOptions<ConnectionSettings> options, ICookieService cookieService)
        {
            _settings = options.Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_settings.APIHostAddress);
            _cookieService = cookieService;
        }
        public async Task<IEnumerable<CharacterDTO>> GetCharactersAsync(string userId)
        {

                var responseMessage = await _httpClient.GetAsync("/api/character/GetByUser/" + userId);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Characters request error:{responseMessage.StatusCode}");
                return null;    
            }
                else
                {
                    var characters = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<CharacterDTO>>();
                    charactersCached = characters;
                    return characters;
                }
            
        }

        public async Task<CharacterDTO> GetCharacterById(string id)
        {

            if (charactersCached is null)
            {
                var responseMessage = await _httpClient.GetAsync("/api/Character/Get/" + id);

                var character = await responseMessage.Content.ReadFromJsonAsync<CharacterDTO>();
                return character;

            }
            else
            {
                foreach (var character in charactersCached)
                {
                    if (character.Id == id)
                    {
                        return character;
                    }
                }

                return null;
            }
        }
        
        public async Task<bool> UpdateCharacterAsync(CharacterDTO character )
        {

            var response = await _httpClient.PutAsJsonAsync($"/api/Character/Update/UpdateCharacter", character);

            return response.IsSuccessStatusCode;
        }
        public async Task<CharacterDTO> CreateCharacterAsync() {
            UserDTO user = await _cookieService.GetSignedInUserAsync();
            var response = await _httpClient.PostAsync($"/api/Character/CreateNew/{user.Id}", null);
            CharacterDTO character = new();
            character.Id = await response.Content.ReadAsStringAsync();
             return character;
        }
        public async Task<bool> DeleteCharacterAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Character/Delete/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<List<CharacterRaceDTO>> GetRacesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CharacterRaceDTO>>($"/api/characterrace/GetAllRaces");
            return response;
            }
        public async Task<List<CharacterClassDTO>> GetClassesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CharacterClassDTO>>($"/api/characterclass/GetAllClasses");
            return response;

        }
    }


}