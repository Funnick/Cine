using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Member")]
    public class Member
    {
        [Required]
        [Column("Name")]
        [Key]
        [MaxLength(60)]
        public string Name { get; set; }
        
        [Required]
        [Column("Email")]
        [MaxLength(70)]
        public string Email { get; set; }
        
        [Required]
        [Column("Card")]
        [MaxLength(100)]
        public string Card { get; set; }
        
        [Required]
        [Column("Code")]
        [MaxLength(100)]
        public string Code { get; set; }
        
        [Required]
        [Column("Points")]
        public int Points { get; set; }
    }
}