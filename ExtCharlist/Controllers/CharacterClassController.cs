using ExtCharlistAPI.Services;
using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExtCharlistAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterClassController : ControllerBase
    {
        private readonly CharacterClassService _characterClassService;
        private readonly Mapper _mapper;

        public CharacterClassController(CharacterClassService characterClassService, Mapper mapper)
        {
            _characterClassService = characterClassService;
            _mapper = mapper;
        }
        // GET: CharacterRaceController
        [HttpGet("GetAllClasses")]
        public async Task<List<CharacterClassDTO>> Get()
        {
            var res = await _characterClassService.GetAsync();
            List<CharacterClassDTO> classes = new List<CharacterClassDTO>();
            for (int i = 0; i < res.Count; i++)
            {
                classes.Add(await _mapper.ClassToClassDTO(res[i]));
            }
            return classes;
        }


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<CharacterClass>> Get(string id)
        {
            var book = await _characterClassService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CharacterClass newCharacterClass)
        {
            await _characterClassService.CreateAsync(newCharacterClass);

            return CreatedAtAction(nameof(Get), new { id = newCharacterClass.Id }, newCharacterClass);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, CharacterClass updatedCharacterClass)
        {
            var characterClass = await _characterClassService.GetAsync(id);

            if (characterClass is null)
            {
                return NotFound();
            }

            updatedCharacterClass.Id = characterClass.Id;

            await _characterClassService.UpdateAsync(id, updatedCharacterClass);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _characterClassService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _characterClassService.RemoveAsync(id);

            return NoContent();
        }
    }
}
