using System;
using System.ComponentModel.DataAnnotations;

namespace Cine.ViewModels{
    public class RegisterViewModel{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Card { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}