using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace ExtCharistWebApp.Services
{
    public class LoginService:PageModel, ILoginService
    {
        private ConnectionSettings _settings;
        private AuthenticationStateProvider _stateProvider;
        private ICookieService _cookieService;
        public LoginService(IOptions<ConnectionSettings> options, AuthenticationStateProvider stateProvider, ICookieService cookieService)
        {
            _settings = options.Value;
            _stateProvider = stateProvider;
            _cookieService = cookieService;
        }
        public async Task<bool> OnLoginAsync(UserDTO userDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_settings.APIHostAddress);
            var response = await client.GetAsync($"/api/Users/VerifyUser/VerifyUser?email={userDTO.Email}&password={userDTO.Password}");
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}: {errorBody}");
                return false;
            }
            var content = await response.Content.ReadAsStringAsync();
            UserDTO returned = JsonSerializer.Deserialize<UserDTO>(content);

            await _cookieService.SetSignedInUserAsync(returned, _settings.BlazorDomain);

            //Cookie name = new Cookie("name", returned.UserName);
            //Cookie email = new Cookie("email", returned.Email);
            //Cookie id = new Cookie("id", returned.Id);
            //Cookie role = new Cookie("role", returned.UserRole.Name);

            //_cookies.Add(name);
            //_cookies.Add(email);
            //_cookies.Add(id);
            //_cookies.Add(role);

            return true;
        }
        public async Task<bool> OnRegisterAsync(UserDTO userDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_settings.APIHostAddress);
            var response = await client.PostAsJsonAsync($"/api/Users/VerifyRegister/VerifyRegister", userDTO);
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error {response.StatusCode}: {errorBody}");
            }
            //await _cookieService.SetSignedInUserAsync();
            return response.IsSuccessStatusCode;
        }
       
        public async Task OnLogoutAsync()
        {
             await  _cookieService.ClearUserCookiesAsync();
        }


        public async Task<String> GetLoggedIdAsync()
        {
            //
            UserDTO userDTO = await _cookieService.GetSignedInUserAsync();
            return userDTO.Id;
        }

        public async Task<UserDTO>? GetSignedInUserAsync()
        {
            return await _cookieService.GetSignedInUserAsync();
        }
    }
}
