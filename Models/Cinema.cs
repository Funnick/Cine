using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Cinema")]
    public class Cinema
    {
        [Required]
        [Column("IdC")]
        [Key]
        public int IdC { get; set; }
        
        [Required]
        [Column("NumberOfSeats")]
        public int NumberOfSeats { get; set; }
    }
}