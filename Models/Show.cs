using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Show")]
    public class Show
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        [Column("StartTime")]
        public DateTime StartTime { get; set; }
        
        [Required]
        [Column("EndTime")]
        public DateTime EndTime { get; set; }
        
        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }

        [Required]
        public int Price { get; set; }

        public int PointsPrice { get; set; }
        

        [Required] 
        public int MovieId { get; set; }
        

        [Required]
        public int CinemaId { get; set; }

        public int? DiscountId { get; set; } 

        [Required]
        public virtual Movie Movie { get; set; }
        
        [Required]
        public virtual Cinema Cinema { get; set; }

        public virtual ICollection<Ticket> Ticekts { get; set; }
        
        public virtual Discount Discount { get; set; }
    }
}