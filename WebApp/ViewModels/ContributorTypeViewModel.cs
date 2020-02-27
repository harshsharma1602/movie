using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class ContributorTypeViewModel
    {
        public Search Filter { get; set; }
        public Data Data { get; set; }
        public ContributorTypeViewModel()
        {
            this.Filter = new Search();
            this.Data = new Data();

        }
    }

    public class Search
    {
        public List<SelectListItem> LanguageList { get; set; }
        public int LanguageID { get; set; }
    }
    public class Data
    {
        public List<WebApp.Models.ContributorTypeData> ContributorTypes { get; set; }
    }
}
