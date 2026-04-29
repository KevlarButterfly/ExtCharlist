using ExtCharlistLibrary.DTO;
using System.Text;

namespace ExtCharistWebApp.Services
{
    public interface ILoginService
    {
        public Task<bool> OnLogin(UserDTO userDTO);
    }
}
