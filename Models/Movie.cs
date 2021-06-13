using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;


namespace Cine.Models{
    [Table("Movie")]
    public class Movie{
        [Key]
        [Required]
        [Column("MovieId")]
        public int MovieId { get; set; }

        [Required]
        [Column("Title")]
        [MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        [Column("Genre")]
        [MaxLength(100)]
        public string Genre { get; set; }
        
        [Required]
        [Column("Duration")]
        public int Duration { get; set; }
        
        [Required]
        [Column("Country")]
        [MaxLength(50)]
        public string Country { get; set; }
        
        [Required]
        [Column("Category")]
        [MaxLength(50)]
        public string Category { get; set; }
        
        [Required]
        [Column("Year")]
        public int Year { get; set; }
        
        [Required]
        [Column("Synopsis")]
        [MaxLength(300)]
        public string Synopsis { get; set; }
        
        public string Photo { get; set; }
        
        public virtual ICollection<Director> Directors { get; set; }
        
        public virtual ICollection<Actor> Actors { get; set; }
    }
}