using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Promotion")]
    public class Promotion
    {
        [Required]
        [Column("IdD")]
        [Key]
        public int IdD { get; set; }
        
        [Required]
        [Column("Discount")]
        public decimal Discount { get; set; }
        
        [Required]
        [Column("Description")]
        [MaxLength(300)]
        public string Description { get; set; }
    }
}