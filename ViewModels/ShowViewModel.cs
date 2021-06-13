using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine.ViewModels
{
    public class ShowViewModel
    {
        [Required]
        public DateTime StartTime { get; set; }
        
        [Required]
        public DateTime EndTime { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required] 
        public int MovieId { get; set; }
        
        [Required]
        public int CinemaId { get; set; }
        
    }
}