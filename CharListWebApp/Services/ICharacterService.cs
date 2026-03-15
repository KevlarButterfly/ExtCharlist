using ExtCharistWebApp;
using ExtCharlistLibrary.DTO;
using Microsoft.Extensions.Options;

namespace ExtCharlistWebApp.Services
{
    public interface ICharacterService
    {
        public Task<IEnumerable<CharacterDTO>> GetCharactersAsync(string id);

    }
}
