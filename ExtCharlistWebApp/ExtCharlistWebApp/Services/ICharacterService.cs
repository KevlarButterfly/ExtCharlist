using ExtCharlistLibrary.DTO;
using ExtCharlistWebApp.Client.Pages;

namespace ExtCharlistWebApp.Services
{
    public interface ICharacterService
    {
        public IEnumerable<CharacterDTO> GetCharacters(string id, string url);

    }
}
