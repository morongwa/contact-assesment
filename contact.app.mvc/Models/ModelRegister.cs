using System;
using System.ComponentModel.DataAnnotations;

namespace contact.app.mvc.Models
{
    public class ModelRegister
    {
        public ModelRegister()
        {
        }

        [Required(ErrorMessage="Username is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 4)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}

