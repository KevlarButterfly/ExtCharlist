using ExtCharlistLibrary.Models;
using ExtCharlistAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtCharlistLibrary.DTO;
using ZstdSharp.Unsafe;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ExtCharlistAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharactersService _characterService;
        private readonly Mapper _mapper;

        public CharacterController(CharactersService charactersService, Mapper mapper) {
            _characterService = charactersService;
            _mapper = mapper;
                }

        [HttpGet]
        public async Task<List<CharacterDTO>> Get()
        {
            List<Character> characters = await _characterService.GetAsync();
            List<CharacterDTO> charactersDTO = new ();

            foreach(var character in characters)
            {
                charactersDTO.Add(await _mapper.CharacterToCharacterDTO(character));
            }
            return charactersDTO;
        }
        [Route("{userId}")]
        public async Task<List<CharacterDTO>> GetByUser([FromRoute] string userId)
        { 
            List<Character> characters = await _characterService.GetByUserIdAsync(userId);
            List<CharacterDTO> charactersDTO = new();

            foreach (var character in characters)
            {
                charactersDTO.Add(await _mapper.CharacterToCharacterDTO(character));
            }
            return charactersDTO;
        }


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<CharacterDTO>> Get(string id)
        {
            var book = await _characterService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return await _mapper.CharacterToCharacterDTO(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CharacterDTO newCharacterDTO)
        {
            Character newCharacter = await _mapper.CharacterDTOToCharacter(newCharacterDTO);
            await _characterService.CreateAsync(newCharacter);

            return CreatedAtAction(nameof(Get), new { id = newCharacter.Id }, newCharacter);
        }

        [HttpPost("{userId}")]
        public async Task<string> CreateNewAsync(string userId)
        {
            Character character = new Character();
            character.UserId = userId;
            _characterService.CreateAsync(character);
            return character.Id;
        }
        [HttpPut("UpdateCharacter")]
        public async Task<IActionResult> UpdateAsync([FromBody]CharacterDTO updatedCharacterDTO)
        {
            var character = await _characterService.GetAsync(updatedCharacterDTO.Id);

            if (character is null)
            {
                return NotFound();
            }

            updatedCharacterDTO.Id = character.Id;

            Character updatedCharacter = await _mapper.CharacterDTOToCharacter(updatedCharacterDTO);

            await _characterService.UpdateAsync(character.Id, updatedCharacter);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _characterService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _characterService.RemoveAsync(id);

            return NoContent();
        }





    }
}
