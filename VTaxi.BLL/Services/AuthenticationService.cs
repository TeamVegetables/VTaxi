using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using VTaxi;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Interfaces;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;
using VTaxi.DAL.Repositories;
using VTaxi.Models;

namespace VTaxi.BLL.Services
{
    public class AuthenticationService: IAuthenticationServise
    {
        public UserDTO CurrentUser { get; set; }

        private IUnitOfWork dataBase { get; set; }

        public AuthenticationService(IUnitOfWork db)
        {
            dataBase = db;
        }

        public UserDTO LogIn(LoginViewModel lwModel)
        {
            var User = dataBase.Users.Find(i => i.Email == lwModel.Login && i.Password == lwModel.Password).FirstOrDefault();
            if (User!=null)
            {
                CurrentUser= new UserDTO{Email = User.Email,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Id = User.Id,
                    Password = User.Password,
                    Type = User.Type,
                    SuccessfulTrips = User.SuccessfulTrips
                };
            }


            return CurrentUser;
        }

        public UserDTO Register(RegisterViewModel registerViewModel)
        {
            var User = dataBase.Users.Find(i => i.Email == registerViewModel.Email && i.Password == registerViewModel.Password).FirstOrDefault();
            if (User == null)
            {
                CurrentUser = new UserDTO
                {
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Password = registerViewModel.Password
                };
                dataBase.Users.Create(new User
                {
                    Email = CurrentUser.Email,
                    FirstName = CurrentUser.FirstName,
                    LastName = CurrentUser.LastName,
                    Password = CurrentUser.Password
                });
                dataBase.Save();
            }

            return CurrentUser;
        }

        public void Dispose()
        {
            dataBase.Dispose();
        }
    }
}
