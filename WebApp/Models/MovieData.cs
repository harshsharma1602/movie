using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MovieData
    {
        public Guid MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int LanguageID { get; set; }

        public bool IsActive { get; set; }

        public virtual List<MovieGenreData> MovieGenres { get; set; }

        public virtual List<MovieContributorData> MovieContributors { get; set; }
        public virtual List<MovieContributorTypeData> MovieContributorTypes { get; set; } //10 feb

        public virtual List<ContributorTypeData> ContributorTypes { get; set; } //7 feb

        //public virtual List<ContributorManagerData> ContributorManagers { get; set; }
    }
}
