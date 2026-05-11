using ExtCharlistLibrary.DTO;
using System.Text;

namespace ExtCharistWebApp.Services
{
    public interface ILoginService
    {
        public Task<bool> OnLoginAsync(UserDTO userDTO);
        public Task<bool> OnRegisterAsync(UserDTO userDTO);
        public Task<UserDTO>? HasUserSignedIn();
        public Task OnLogoutAsync();
        public Task<String> GetLoggedIdAsync();
    }
}