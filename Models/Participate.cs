using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    public class Participate
    {
        [Key]
        [Required]
        [Column("ParticipateId")]
        public int ParticipateId { get; set; }
        
        [Required]
        [Column("MovieId")]
        public int MovieId { get; set; }
        
        [Required]
        [Column("ProducerId")]
        public int ProducerId { get; set; }
    }
}