using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class MovieIndexViewModel
    {
        public MovieSearch Filter { get; set; }
        public MovieListData Data { get; set; }
        public MovieIndexViewModel()
        {
            this.Filter = new MovieSearch();
            this.Data = new MovieListData();

        }
    }

    public class MovieSearch
    {
        public List<SelectListItem> LanguageList { get; set; }
        public int LanguageID { get; set; }
    }
    public class MovieListData
    {
        public List<WebApp.Models.MovieData> movies { get; set; }
    }
}
