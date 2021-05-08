using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cine.Models{
    public class Movie{
        public int MovieID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
    }
}