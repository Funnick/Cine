using System;
using System.ComponentModel.DataAnnotations;

namespace Cine.ViewModels
{
    public class ProducerViewModel
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        
        [Required]
        public int Age { get; set; }
        public string Role { get; set; }
    }
}