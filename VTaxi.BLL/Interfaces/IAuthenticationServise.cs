using VTaxi.BLL.DTO;

namespace VTaxi.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        UserDto CurrentUser { get; set; }

        UserDto LogIn(UserDto loginViewModel);

        UserDto Register(UserDto registerViewModel);

        void Dispose();
    }
}
