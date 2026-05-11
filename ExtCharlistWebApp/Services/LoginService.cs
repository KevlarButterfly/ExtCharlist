using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ExtCharistWebApp.Services
{
    public class LoginService:PageModel, ILoginService
    {
        private APISettings _settings;
        private AuthenticationStateProvider _stateProvider;
        public LoginService(IOptions<APISettings> options, AuthenticationStateProvider stateProvider)
        {
            _settings = options.Value;
            _stateProvider = stateProvider;
        }
        public async Task<bool> OnLoginAsync(UserDTO userDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_settings.HostAddress);
            var response = await client.GetAsync($"/api/Users/VerifyUser/VerifyUser?email={userDTO.Email}&password={userDTO.Password}");
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}: {errorBody}");
            }
            return response.StatusCode!=System.Net.HttpStatusCode.NotFound && response.StatusCode!=System.Net.HttpStatusCode.NoContent ? true : false;
        }
        public async Task<bool> OnRegisterAsync(UserDTO userDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_settings.HostAddress);
            var response = await client.PostAsJsonAsync($"/api/Users/VerifyRegister/VerifyRegister", userDTO);
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}: {errorBody}");
            }
            return response.IsSuccessStatusCode;
        }
        
        public async Task<UserDTO>? HasUserSignedIn()
        {
            //var principal = await _stateProvider.GetAuthenticationStateAsync();
            //var claims = principal.User.Claims;
            UserDTO userDTO = new UserDTO();
            try
            {
                var nameClaim = HttpContext.User;
                var name = nameClaim.Claims.First(c => c.Type == ClaimTypes.Name).Value;
                userDTO.UserName = name;
                var authState = await _stateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                var IdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
                var id = IdClaim.Value;
                userDTO.Id = id;
                var roleClaim = User.FindFirst(c => c.Type == ClaimTypes.Role);
                var role = roleClaim.Value;
                userDTO.UserRole = new(role);
                Console.WriteLine(name);
                return userDTO;

            }
            catch(System.NullReferenceException e)
            {
                return null;
            }
            
        }
        public async Task OnLogoutAsync()
        {
            var authState = await _stateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_settings.HostAddress);
                
                await HttpContext.SignOutAsync("Cookies");
            }
        }


        public async Task<String> GetLoggedIdAsync()
        {
            var authState = await _stateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
