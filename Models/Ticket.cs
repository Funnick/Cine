using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [Required]
        [Column("TicketId")]
        public int TicketId { get; set; }
        
        [Required]
        [Column("Price")]
        public decimal Price { get; set; }

        [Required] 
        public int SeatNumber { get; set; }
        
        [Required]
        public int TheaterUserId { get; set; }
        
        [Required]
        public int ShowId { get; set; }
        
        [Required] 
        public virtual TheaterUser TheaterUser { get; set; }
        
        [Required]
        public virtual Show Show { get; set; }
        
        public virtual ICollection<Discount> Discounts { get; set; }
    }
}