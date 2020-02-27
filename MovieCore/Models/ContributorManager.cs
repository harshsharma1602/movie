using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCore.Models
{
    public class ContributorManager
    {
        [Key]
        public Guid ID { get; set; }

        public Guid ContributorID { get; set; }

        public Guid ContributorTypeID { get; set; }

        public ContributorType ContributorTypes { get; set; }

        //public Contributor Contributors { get; set; }

    }
}
