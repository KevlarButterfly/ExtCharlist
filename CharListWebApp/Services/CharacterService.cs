using ExtCharistWebApp;
using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace ExtCharlistWebApp.Services
{
    public class CharacterService : ICharacterService
    {
        private APISettings _settings;
        private IEnumerable<CharacterDTO> charactersCached { get; set; }
        public CharacterService(IOptions<APISettings> options)
        {
            _settings = options.Value;
        }
        public async Task<IEnumerable<CharacterDTO>> GetCharactersAsync(string userId)
        {
            if (charactersCached is null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_settings.HostAddress);
                var responseMessage = await client.GetAsync("/api/character/GetByUser/" + userId);

                var characters = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<CharacterDTO>>();
                charactersCached = characters;
                return characters;
            }
            return charactersCached;
        }

        public async Task<CharacterDTO> GetCharacterById(string id)
        {

            if (charactersCached is null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_settings.HostAddress);
                var responseMessage = await client.GetAsync("/api/Character/Get/" + id);

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
    }
}