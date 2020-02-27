using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class ContributorViewModel
    {
        public Guid ContributorID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int LanguageID { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Please select atleast one type")]


        //public string[] selectedtypes { get; set; }
        //public IEnumerable<SelectListItem> types { get; set; }

        public IEnumerable<string> selectedtypes { get; set; }

        [Display(Name ="Select Contributor Type")]
        public List<SelectListItem> types { get; set; }
    }
}
