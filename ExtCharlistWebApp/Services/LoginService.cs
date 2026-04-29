using ExtCharlistLibrary.DTO;
using ExtCharlistLibrary.Models;
using Microsoft.Extensions.Options;

namespace ExtCharistWebApp.Services
{
    public class LoginService:ILoginService
    {
        private APISettings _settings;
        public LoginService(IOptions<APISettings> options)
        {
            _settings = options.Value;
        }
        public async Task<bool> OnLogin(UserDTO userDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_settings.HostAddress);
            var responseMessage = await client.GetAsync($"/api/Users/VerifyUser?email={userDTO.Email}&password={userDTO.Password}");
            return responseMessage.StatusCode!=System.Net.HttpStatusCode.NotFound ? true : false;
        }
    }
}
