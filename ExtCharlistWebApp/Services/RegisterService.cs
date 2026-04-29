using ExtCharlistLibrary.DTO;
using Microsoft.Extensions.Options;

namespace ExtCharistWebApp.Services
{
    public class RegisterService : IRegisterService
    {
        private APISettings _settings;
        public RegisterService(IOptions<APISettings> options)
        {
            _settings = options.Value;
        }

        public async Task<bool> OnRegisterAsync(UserDTO userDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_settings.HostAddress);
            var response = await client.PostAsJsonAsync("/api/Users/VerifyRegister", userDTO);
            return response.IsSuccessStatusCode;
        }
    }
}
