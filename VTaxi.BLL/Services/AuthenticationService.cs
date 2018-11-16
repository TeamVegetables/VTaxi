using System;
using System.Linq;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Interfaces;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;

namespace VTaxi.BLL.Services
{
    /// <summary>
    ///     Class Authentification service serves to recognize users
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        ///     Construcror with parameters that connects the database
        /// </summary>
        /// <param name="db">database</param>
        public AuthenticationService(IUnitOfWork db)
        {
            DataBase = db;
        }

        public static UserDto CurrentUser { get; set; }

        private IUnitOfWork DataBase { get; }

        /// <summary>
        ///     Login method
        /// </summary>
        /// <param name="userDto">new or existing user</param>
        /// <returns>new or existing user</returns>
        public UserDto LogIn(UserDto userDto)
        {
            var user = DataBase.Users.Find(i => i.Email == userDto.Email && i.Password == userDto.Password)
                .FirstOrDefault();
            if (user == null)
                throw new InvalidOperationException("Bad credentials!");

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

        /// <summary>
        ///     Register new User
        /// </summary>
        /// <param name="userDto">user data tr</param>
        /// <returns>new UserDTO</returns>
        public UserDto Register(UserDto userDto)
        {
            var user = DataBase.Users.Find(i => i.Email == userDto.Email).FirstOrDefault();
            if (user != null)
                throw new InvalidOperationException("User with this E-Mail already exists!");

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

        /// <summary>
        ///     Dispose database
        /// </summary>
        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}