using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.Models
{
    [Table("Producer")]
    public class Producer
    {
        [Key]
        [Required]
        [Column("Name")]
        [MaxLength(60)]
        public string Name { get; set; }
        
        [Required]
        [Column("Country")]
        [MaxLength(50)]
        public string Country { get; set; }
        
        [Required]
        [Column("Age")]
        public int Age { get; set; }
    }
}