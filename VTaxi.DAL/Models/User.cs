﻿using VTaxi.Shared.Enums;

namespace VTaxi.DAL.Models
{
    public class User
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