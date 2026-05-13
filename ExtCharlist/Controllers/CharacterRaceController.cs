using ExtCharlistLibrary.Models;
using ExtCharlistAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtCharlistAPI;
using ExtCharlistLibrary.DTO;

namespace ExtCharlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterRaceController : ControllerBase
    {
        private readonly CharacterRaceService _characterRaceService;
        private readonly Mapper _mapper;

        public CharacterRaceController(CharacterRaceService characterRaceService, Mapper mapper) { 
            _characterRaceService = characterRaceService;
            _mapper = mapper;
        }
        // GET: CharacterRaceController
        [HttpGet("GetAllRaces")]
        public async Task<List<CharacterRaceDTO>> Get()
        {
            var res = await _characterRaceService.GetAsync();
            List<CharacterRaceDTO> races = new List<CharacterRaceDTO>();
            for(int i = 0; i < res.Count; i++){
                races.Add(await _mapper.RaceToRaceDTO(res[i]));
            }
            return races;
        }
            

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
