using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class ContributorIndexViewModel
    {
        public ContributorSearch Filter { get; set; }
        public ContributorListData Data { get; set; }
        public ContributorIndexViewModel()
        {
            this.Filter = new ContributorSearch();
            this.Data = new ContributorListData();

        }
    }

    public class ContributorSearch
    {
        public List<SelectListItem> LanguageList { get; set; }
        public int LanguageID { get; set; }
    }
    public class ContributorListData
    {
        public List<WebApp.Models.ContributorData> contributors { get; set; }
    }
}
