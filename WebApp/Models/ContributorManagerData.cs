using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ContributorManagerData
    {
        public Guid ID { get; set; }

        public Guid ContributorID { get; set; }

        public Guid ContributorTypeID { get; set; }

        public ContributorTypeData ContributorTypes { get; set; }

        //public Contributor Contributors { get; set; }

    }
}
