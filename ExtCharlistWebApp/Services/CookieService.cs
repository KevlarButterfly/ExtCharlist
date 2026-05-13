using ExtCharlistLibrary.DTO;
using System.Net;

namespace ExtCharistWebApp.Services
{
    public class CookieService:ICookieService
    {
        private CookieContainer _cookieContainer;

        public CookieService(CookieContainer cookieContainer)
        {
            _cookieContainer = cookieContainer;
        }
        public async Task<UserDTO> GetSignedInUserAsync() { 
            UserDTO userDTO = new();
            var cookies = _cookieContainer.GetAllCookies();
            foreach (Cookie cookie in cookies) {
                if (cookie.Name == "id") userDTO.Id = cookie.Value;
                else if (cookie.Name == "role") userDTO.UserRole = new(cookie.Value);
                else if(cookie.Name == "name") userDTO.UserName = cookie.Value;

            }
            return userDTO;
        }


        public async Task SetSignedInUserAsync(UserDTO userDTO, string domain) { 
            Cookie name = new Cookie("name", userDTO.UserName); name.Domain = new(domain);name.Path = "/";
            Cookie role = new Cookie("role", userDTO.UserRole.Name); role.Domain = new(domain);role.Path = "/";
            Cookie id = new Cookie("id", userDTO.Id); id.Domain = new(domain);role.Path = "/";
            _cookieContainer.Add(name);
            _cookieContainer.Add(role);
            _cookieContainer.Add(id);
           
        }

        public async Task ClearUserCookiesAsync()
        {
            _cookieContainer = new CookieContainer();
        }
    }
}
