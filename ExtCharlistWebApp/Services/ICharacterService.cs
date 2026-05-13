using ExtCharistWebApp;
using ExtCharlistLibrary.DTO;
using Microsoft.Extensions.Options;

namespace ExtCharlistWebApp.Services
{
    public interface ICharacterService
    {
        public Task<IEnumerable<CharacterDTO>> GetCharactersAsync(string id);
        public Task<CharacterDTO> GetCharacterById(string id);
        public Task<CharacterDTO> CreateCharacterAsync();
        public Task<bool> UpdateCharacterAsync(CharacterDTO characterDTO);
        public Task<bool> DeleteCharacterAsync(string id);
        public Task<List<CharacterRaceDTO>> GetRacesAsync();
        public Task<List<CharacterClassDTO>> GetClassesAsync();
    }
}
