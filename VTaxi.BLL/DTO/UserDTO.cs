using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTaxi.DAL.Enums;



namespace VTaxi.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SuccessfulTrips { get; set; }

        public UserType Type { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
