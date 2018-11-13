using VTaxi.BLL.DTO;

namespace VTaxi.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        UserDto LogIn(UserDto userDto);

        UserDto Register(UserDto userDto);

        void Dispose();
    }
}
