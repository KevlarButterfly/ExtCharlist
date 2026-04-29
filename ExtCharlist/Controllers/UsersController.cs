using ExtCharlistAPI.Services;
using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ExtCharlistAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly Mapper _mapper;
        private readonly PasswordHashService _passwordHashService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersController(UsersService usersService, Mapper mapper, PasswordHashService passwordHashService){
            _usersService = usersService;
            _mapper = mapper;
            _passwordHashService = passwordHashService;
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
        [HttpGet("VerifyUser")]
        public async Task<UserDTO?> VerifyUser(UserDTO user)
        {
            if(await _usersService.GetWithEmailAsync(user.Email) == null)
            {
                return null;
            }
            var userFromDb = await _usersService.GetWithEmailAsync(user.Email);
            var claims  = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userFromDb.userName),
                new Claim(ClaimTypes.NameIdentifier, userFromDb.Id),
                new Claim(ClaimTypes.Role, userFromDb.userRole.ToString())
            };
            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);
            await _httpContextAccessor.HttpContext.SignInAsync("Cookies", principal);
            return await _passwordHashService.VerifyPasswordAsync(user.Password, userFromDb.password, userFromDb.salt) ? await _mapper.UserToUserDTO(userFromDb) : null;
        }
        
        public async Task<UserDTO?> VerifyRegisterAsync(UserDTO userDTO)
        {
            if (await _usersService.GetWithEmailAsync(userDTO.Email) != null)
            {
                return null;
            }
            User user = await _mapper.UserDTOToUser(userDTO);
            _usersService.CreateAsync(user);
            return userDTO;
        }
    }
}
