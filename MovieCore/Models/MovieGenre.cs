using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCore.Models
{
    public class MovieGenre
    {
        [Key]
        public Guid ID { get; set; }

        public Guid MovieID { get; set; }

        public Guid GenreID { get; set; }

        public Genre Genres { get; set; }

        //public Movie Movies { get; set; }


    }
}
