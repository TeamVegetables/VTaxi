﻿namespace VTaxi.Models
{
    /// <summary>
    ///     View of Register Model
    /// </summary>
    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}