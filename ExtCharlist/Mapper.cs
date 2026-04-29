using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;

namespace ExtCharlistAPI
{
    public class Mapper
    {
        public async Task<CharacterDTO> CharacterToCharacterDTO(Character character)
        {
            CharacterClassDTO characterClass = new CharacterClassDTO() {
            
            };
            CharacterDTO characterDTO = new CharacterDTO()
            {
                Id = character.Id,
                UserID = character.UserId,
                CharacterName = character.CharacterName,
                CharacterRace = await RaceToRaceDTO(character.CharacterRace),
                CharacterClass = await ClassToClassDTO(character.CharacterClass),
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
                CharacterRace = await RaceDTOToRace(characterDTO.CharacterRace),
                CharacterClass = await ClassDTOToClass(characterDTO.CharacterClass),
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
                userEmail = userDTO.Email,
                userRole = userDTO.UserRole,
                password = userDTO.Password
            };
            return user;
        }
        public async Task<UserDTO> UserToUserDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                UserName = user.userName,
                Email = user.userEmail,
                UserRole = user.userRole
            };
            return userDTO;
        }
        public async Task<CharacterRace> RaceDTOToRace(CharacterRaceDTO race)
        {
            CharacterRace characterRace = new CharacterRace()
            {
                Id = race.Id,
                RaceName = race.RaceName,
                RaceLanguages = race.RaceLanguages,
                RaceSpeed = race.RaceSpeed
            };
            return characterRace;
        }
        public async Task<CharacterRaceDTO> RaceToRaceDTO(CharacterRace race)
        {
            CharacterRaceDTO characterRace = new CharacterRaceDTO() {
                Id = race.Id,
                RaceName = race.RaceName,
                RaceLanguages = race.RaceLanguages,
                RaceSpeed = race.RaceSpeed
            };
            return characterRace;
        }
        public async Task<CharacterClass> ClassDTOToClass(CharacterClassDTO characterClassDTO)
        {
            CharacterClass characterClass = new CharacterClass()
            {
                Id = characterClassDTO.Id,
                ClassName = characterClassDTO.ClassName,
                ClassHitDice = characterClassDTO.ClassHitDice
            };
            return characterClass;
        }
        public async Task<CharacterClassDTO> ClassToClassDTO(CharacterClass characterClass)
        {
            CharacterClassDTO characterClassDTO = new CharacterClassDTO()
            {
                Id = characterClass.Id,
                ClassName = characterClass.ClassName,
                ClassHitDice = characterClass.ClassHitDice
            };
            return characterClassDTO;
        }
    }
}
