using VTaxi.BLL.DTO;
using VTaxi.Models;

namespace VTaxi.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        UserDto CurrentUser { get; set; }

        UserDto LogIn(LoginViewModel loginViewModel);

        UserDto Register(RegisterViewModel registerViewModel);

        void Dispose();
    }
}
