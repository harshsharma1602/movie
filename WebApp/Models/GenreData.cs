using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class GenreData
    {
        public Guid GenreID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int LanguageID { get; set; }

        public bool IsActive { get; set; }

        //public virtual List<MovieGenre> MovieGenres { get; set; }

    }
}
