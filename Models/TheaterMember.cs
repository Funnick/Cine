using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("TheaterMember")]
    public class TheaterMember
    {
        [Required]
        [Column("Code")]
        [MaxLength(100)]
        public string Code { get; set; }
        
        [Required]
        [Column("Points")]
        public int Points { get; set; }
        
        [Key]
        [ForeignKey("TheaterUser")]
        [Required]
        public int TheaterUserId { get; set; }
        
        [Required]
        public virtual TheaterUser TheaterUser { get; set; }
    }
}