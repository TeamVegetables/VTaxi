using System;
using System.Linq;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Interfaces;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;

namespace VTaxi.BLL.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        public static UserDto CurrentUser { get; set; }

        private IUnitOfWork DataBase { get; }

        public AuthenticationService(IUnitOfWork db)
        {
            DataBase = db;
        }

        public UserDto LogIn(UserDto userDto)
        {
            var user = DataBase.Users.Find(i => i.Email == userDto.Email && i.Password == userDto.Password).FirstOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException("Bad credentials!");
            }

            CurrentUser = new UserDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Password = user.Password,
                Type = user.Type,
                SuccessfulTrips = user.SuccessfulTrips
            };

            return CurrentUser;
        }

        public UserDto Register(UserDto userDto)
        {
            var user = DataBase.Users.Find(i => i.Email == userDto.Email).FirstOrDefault();
            if (user != null)
            {
                throw new InvalidOperationException("User with this E-Mail already exists!");
            }

            CurrentUser = new UserDto
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password
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
