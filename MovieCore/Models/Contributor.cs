using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCore.Models
{
    public class Contributor
    {
        [Key]
        public Guid ContributorID { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int LanguageID { get; set; }

        public bool IsActive { get; set; }

        public virtual List<ContributorManager> ContributorManagers { get; set; }
        //public virtual List<MovieContributor> MovieContributors { get; set; }

    }
}
