using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        [Required]
        [Column("DiscountId")]
        public int DiscountId { get; set; }
        
        [Required]
        [Column("Percent")]
        public decimal Percent { get; set; }
        
        [Required]
        [Column("Description")]
        [MaxLength(300)]
        public string Description { get; set; }
        
        public virtual ICollection<Show> Shows { get; set; }
        
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}