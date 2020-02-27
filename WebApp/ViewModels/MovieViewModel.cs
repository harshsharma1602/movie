using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class MovieViewModel
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

        [Required(ErrorMessage = "Please select atleast one contributor")]
        public IEnumerable<string> selectedcontributors { get; set; }

        [Display(Name ="Select Contributor")]
        public List<SelectListItem> contributors { get; set; }

        [Required(ErrorMessage = "Please select atleast one contributor type")]
        public IEnumerable<string> selectedtypes { get; set; }

        [Display(Name = "Select Contributor Types")]
        public List<SelectListItem> types { get; set; }

        [Required(ErrorMessage = "Please select atleast one contributor type")]

        public IEnumerable<string> selectedgenres { get; set; }
        [Display(Name = "Select Genre")]
        public List<SelectListItem> genres { get; set; }
    }
}
