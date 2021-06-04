using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cine.Models{
    [Table("Movie")]
    public class Movie{
        [Required]
        [Column("MovieId")]
        [Key]
        public int MovieId { get; set; }

        [Required]
        [Column("Title")]
        [MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        [Column("Gender")]
        [MaxLength(100)]
        public string Gender { get; set; }
        
        [Required]
        [Column("Duration")]
        public DateTime Duration { get; set; }
        
        [Required]
        [Column("Country")]
        [MaxLength(50)]
        public string Country { get; set; }
        
        [Required]
        [Column("Category")]
        [MaxLength(50)]
        public string Category { get; set; }
        
        [Required]
        [Column("Age")]
        public int Age { get; set; }
        
        [Required]
        [Column("Synopsis")]
        [MaxLength(300)]
        public string Synopsis { get; set; }
    }
}