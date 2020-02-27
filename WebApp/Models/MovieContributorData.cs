using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MovieContributorData
    {
        public Guid ID { get; set; }

        public Guid MovieID { get; set; }

        public Guid ContributorID { get; set; }

        public ContributorData Contributors { get; set; }
        public ContributorTypeData ContributorTypes { get; set; }

        //public Movie Movies { get; set; }


    }
}
