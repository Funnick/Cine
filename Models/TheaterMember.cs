using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("TheaterMember")]
    public class TheaterMember
    {
        [Key]
        [Required]
        [Column("Code")]
        [MaxLength(100)]
        public string Code { get; set; }
        
        [Required]
        [Column("Points")]
        public int Points { get; set; }
        
        [DataType("Text")]
        [ForeignKey("TheaterUser")]
        [Required]
        public string TheaterUserId { get; set; }
        
        
        [Required]
        public virtual TheaterUser TheaterUser { get; set; }
        
    }
}