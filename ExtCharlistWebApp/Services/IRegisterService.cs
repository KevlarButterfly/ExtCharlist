using ExtCharlistLibrary.DTO;

namespace ExtCharistWebApp.Services
{
    public interface IRegisterService
    {
        public Task<bool> OnRegisterAsync(UserDTO userDTO);
    }
}
