using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class GenreViewModel
    {
        public GenreSearch Filter { get; set; }
        public GenreListData Data { get; set; }
        public GenreViewModel()
        {
            this.Filter = new GenreSearch();
            this.Data = new GenreListData();

        }
    }

    public class GenreSearch
    {
        public List<SelectListItem> LanguageList { get; set; }
        public int LanguageID { get; set; }
    }
    public class GenreListData
    {
        public List<WebApp.Models.GenreData> genres { get; set; }
    }
}
