using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Show")]
    public class Show
    {
        [Required]
        [Column("StartTime")]
        [Key]
        public DateTime StartTime { get; set; }
        
        [Required]
        [Column("EndTime")]
        public DateTime EndTime { get; set; }
        
        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}