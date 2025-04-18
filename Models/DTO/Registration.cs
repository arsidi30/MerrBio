﻿using System.ComponentModel.DataAnnotations;

namespace FarmIt.Models.DTO
{
    public class Registration
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
        public string Password { get; set; }
        [Required]
        [Compare ("Password")]
        public string PasswordConfirmation { get; set; }
        public string Role { get; set; }
    }
}
