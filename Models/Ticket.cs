using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Required]
        [Column("IdE")]
        [Key]
        public int IdE { get; set; }
        
        [Required]
        [Column("Price")]
        public decimal Price { get; set; }
    }
}