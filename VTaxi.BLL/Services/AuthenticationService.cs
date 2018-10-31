using System.Linq;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Interfaces;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;
using VTaxi.Models;

namespace VTaxi.BLL.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        public UserDto CurrentUser { get; set; }

        private IUnitOfWork DataBase { get; }

        public AuthenticationService(IUnitOfWork db)
        {
            DataBase = db;
        }

        public UserDto LogIn(LoginViewModel lwModel)
        {
            var user = DataBase.Users.Find(i => i.Email == lwModel.Login && i.Password == lwModel.Password).FirstOrDefault();
            if (user!=null)
            {
                CurrentUser= new UserDto{Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    Password = user.Password,
                    Type = user.Type,
                    SuccessfulTrips = user.SuccessfulTrips
                };
            }


            return CurrentUser;
        }

        public UserDto Register(RegisterViewModel registerViewModel)
        {
            var user = DataBase.Users.Find(i => i.Email == registerViewModel.Email && i.Password == registerViewModel.Password).FirstOrDefault();
            if (user != null) return CurrentUser;
            CurrentUser = new UserDto
            {
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Password = registerViewModel.Password
            };
            DataBase.Users.Create(new User
            {
                Email = CurrentUser.Email,
                FirstName = CurrentUser.FirstName,
                LastName = CurrentUser.LastName,
                Password = CurrentUser.Password
            });
            DataBase.Save();

            return CurrentUser;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
