using ExtCharlist.Models;
using ExtCharlist.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtCharlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterRaceController : ControllerBase
    {
        private readonly CharacterRaceService _characterRaceService;

        public CharacterRaceController(CharacterRaceService characterRaceService)=>_characterRaceService = characterRaceService;
        // GET: CharacterRaceController
        [HttpGet]
        public async Task<List<CharacterRace>> Get() =>
            await _characterRaceService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<CharacterRace>> Get(string id)
        {
            var book = await _characterRaceService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CharacterRace newCharacterRace)
        {
            await _characterRaceService.CreateAsync(newCharacterRace);

            return CreatedAtAction(nameof(Get), new { id = newCharacterRace.Id }, newCharacterRace);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, CharacterRace updatedCharacterRace)
        {
            var characterRace = await _characterRaceService.GetAsync(id);

            if (characterRace is null)
            {
                return NotFound();
            }

            updatedCharacterRace.Id = characterRace.Id;

            await _characterRaceService.UpdateAsync(id, updatedCharacterRace);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _characterRaceService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _characterRaceService.RemoveAsync(id);

            return NoContent();
        }
    }
}
