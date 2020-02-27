using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MovieGenreData
    {
        public Guid ID { get; set; }

        public Guid MovieID { get; set; }

        public Guid GenreID { get; set; }

        public GenreData Genres { get; set; }

        //public Movie Movies { get; set; }


    }
}
