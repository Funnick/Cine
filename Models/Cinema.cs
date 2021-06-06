using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Cinema")]
    public class Cinema
    {
        [Key]
        [Required]
        [Column("CinemaId")]
        public int CinemaId { get; set; }
        
        [Required]
        [Column("NumberOfSeats")]
        public int NumberOfSeats { get; set; }
        
        public virtual ICollection<Show> Shows { get; set; }
    }
}