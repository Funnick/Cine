using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("User")]
    public class User
    {
        [Required]
        [Column("Name")]
        [Key]
        [MaxLength(60)]
        public string Name { get; set; }
        
        [Required]
        [Column("Email")]
        [MaxLength(70)]
        public string Country { get; set; }
        
        [Required]
        [Column("Card")]
        [MaxLength(100)]
        public string Card { get; set; }
    }
}