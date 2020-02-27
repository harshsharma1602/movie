using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MovieContributorTypeData
    {
        public Guid ID { get; set; }

        public Guid MovieID { get; set; }

        public MovieData Movies { get; set; }

        public Guid ContributorTypeID { get; set; }

        public ContributorTypeData ContributorTypes { get; set; }


    }
}
