using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;

namespace ExtCharlistAPI
{
    public class Mapper
    {
        public async Task<CharacterDTO> CharacterToCharacterDTO(Character character)
        {
            CharacterDTO characterDTO = new CharacterDTO()
            {
                Id = character.Id,
                UserID = character.UserId,
                CharacterName = character.CharacterName,
                CharacterRace = character.CharacterRace,
                CharacterClass = character.CharacterClass,
                CharacterAge = character.CharacterAge,
                CharacterAlignment = character.CharacterAlignment,
                CharacterBackground = character.CharacterBackground,
                CharacterSpeed = character.CharacterSpeed,
                CharacterTraits = character.CharacterTraits
            };
            return characterDTO;
        }
        public async Task<Character> CharacterDTOToCharacter(CharacterDTO characterDTO)
        {
            Character character = new Character()
            {
                UserId=characterDTO.UserID,
                CharacterName = characterDTO.CharacterName,
                CharacterRace = characterDTO.CharacterRace,
                CharacterClass = characterDTO.CharacterClass,
                CharacterAge = characterDTO.CharacterAge,
                CharacterAlignment = characterDTO.CharacterAlignment,
                CharacterBackground = characterDTO.CharacterBackground,
                CharacterSpeed = characterDTO.CharacterSpeed,
                CharacterTraits = characterDTO.CharacterTraits
            };
            return character;
        }
        public async Task<User> UserDTOToUser(UserDTO userDTO)
        {
            User user = new User()
            {
                Id = userDTO.Id,
                userName = userDTO.UserName,
                userEmail = userDTO.UserEmail,
                userRole = "baseUser",
                password = userDTO.UserPassword
            };
            return user;
        }

    }
}
