using System.ComponentModel.DataAnnotations;
using VTaxi.Shared.Enums;

namespace VTaxi.DAL.Models
{
    /// <summary>
    /// Class User contain info about driver
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SuccessfulTrips { get; set; }

        public UserType Type { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}