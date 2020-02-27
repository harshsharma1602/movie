using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCore.Models
{
    public class MovieContributor
    {
        [Key]
        public Guid ID { get; set; }

        public Guid MovieID { get; set; }

        public Guid ContributorID { get; set; }

        public Contributor Contributors { get; set; }

        

        //public Movie Movies { get; set; }
    }
}
