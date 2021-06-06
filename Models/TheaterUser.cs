using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("TheaterUser")]
    public class TheaterUser
    {
        [Key]
        public int TheaterUserId { get; set; }
        
        [Required]
        [Column("Name")]
        [MaxLength(60)]
        public string Name { get; set; }
        
        [Required]
        [Column("Email")]
        [MaxLength(70)]
        public string Country { get; set; }
        
        [Column("Card")]
        [MaxLength(100)]
        public string Card { get; set; }
        
        public virtual TheaterMember TheaterMember { get; set; }
        
        public virtual ICollection<Ticket> Ticekts { get; set; }
    }
}