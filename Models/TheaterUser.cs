using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Cine.Models
{
    [Table("TheaterUser")]
    public class TheaterUser : IdentityUser
    {
        
        [Column("Card")]
        [MaxLength(100)]
        public string Card { get; set; }
        
        public virtual TheaterMember TheaterMember { get; set; }

        public virtual ICollection<Ticket> Ticekts { get; set; }

    }
}