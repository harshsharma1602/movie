using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ContributorTypeData
    {
        public Guid ContributorTypeID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Select Language")]
        public int LanguageID { get; set; }

        public bool IsActive { get; set; }

        public int? lan { get; set; }

        // public List<ContributorManagerData> ContributorManager { get; set; }

    }
}
