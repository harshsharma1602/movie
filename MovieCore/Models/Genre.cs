using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCore.Models
{
    public class Genre
    {
        [Key]
        public Guid GenreID { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int LanguageID { get; set; }

        public bool IsActive { get; set; }

    }
}
