using ExtCharlistLibrary.DTO;

namespace ExtCharistWebApp.Services
{
    public interface ICookieService
    {
        public Task<UserDTO> GetSignedInUserAsync();
        public Task SetSignedInUserAsync(UserDTO userDTO, string domain);
        public Task ClearUserCookiesAsync();
    }
}
