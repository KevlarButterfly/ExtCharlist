using ExtCharlistLibrary.DTO;

namespace ExtCharlistWebApp.Services
{
    public class CharacterService : ICharacterService
    {
        public IEnumerable<CharacterDTO> GetCharacters(string id, string url)
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = 
            

            return new List<CharacterDTO> { };
        }
    }
}
