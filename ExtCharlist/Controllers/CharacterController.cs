using ExtCharlist.Models;
using ExtCharlist.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtCharlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharactersService _characterService;

        public CharacterController(CharactersService charactersService) =>
            _characterService = charactersService;

        [HttpGet]
        public async Task<List<Character>> Get() =>
            await _characterService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Character>> Get(string id)
        {
            var book = await _characterService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Character newCharacter)
        {
            await _characterService.CreateAsync(newCharacter);

            return CreatedAtAction(nameof(Get), new { id = newCharacter.Id }, newCharacter);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Character updatedCharacter)
        {
            var character = await _characterService.GetAsync(id);

            if (character is null)
            {
                return NotFound();
            }

            updatedCharacter.Id = character.Id;

            await _characterService.UpdateAsync(id, updatedCharacter);

            return NoContent();
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
