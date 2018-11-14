using VTaxi.BLL.DTO;

namespace VTaxi.BLL.Interfaces
{/// <summary>
/// AuthentificationService interface
/// </summary>
    public interface IAuthenticationService
    {
        UserDto LogIn(UserDto userDto);

        UserDto Register(UserDto userDto);

        void Dispose();
    }
}
