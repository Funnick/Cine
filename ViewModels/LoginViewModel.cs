using System;
using System.ComponentModel.DataAnnotations;

namespace Cine.ViewModels{
    public class LoginViewModel{
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}