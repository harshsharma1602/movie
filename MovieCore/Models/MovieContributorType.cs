using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCore.Models
{
    public class MovieContributorType
    {
        [Key]
        public Guid ID { get; set; }

        public Guid MovieID { get; set; }

        //public Movie Movies { get; set; }

        public Guid ContributorTypeID { get; set; }

        public ContributorType ContributorTypes { get; set; }

        

        //public Movie Movies { get; set; }


    }
}
