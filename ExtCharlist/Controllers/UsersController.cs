using ExtCharlistAPI.Services;
using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace ExtCharlistAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly Mapper _mapper;
        public UsersController(UsersService usersService, Mapper mapper){
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet("/GetUsers")]
        public async Task<List<User>> GetAsync() => await _usersService.GetAsync();

        [Route("{userId}")]
        public async Task<User> GetAsync(string id) => await _usersService.GetAsync(id);

        [HttpPost("/CreateUser")]
        public async Task<IActionResult> PostAsync([FromBody]UserDTO newUserDTO)
        {
            User newUser = await _mapper.UserDTOToUser(newUserDTO);
            await _usersService.CreateAsync(newUser);

            return CreatedAtAction("Post", new { id = newUser.Id }, newUser);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var character = await _usersService.GetAsync(id);

            if (character is null)
            {
                return NotFound();
            }

            updatedUser.Id = character.Id;

            await _usersService.UpdateAsync(id, updatedUser);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _usersService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _usersService.RemoveAsync(id);

            return NoContent();
        }
    }
}
