using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTaxi.BLL.DTO;
using VTaxi.Models;

namespace VTaxi.BLL.Interfaces
{
    public interface IAuthenticationServise
    {
        UserDTO CurrentUser { get; set; }

        UserDTO LogIn(LoginViewModel LoginViewModel);

        UserDTO Register(RegisterViewModel registerViewModel);

        void Dispose();
    }
}
