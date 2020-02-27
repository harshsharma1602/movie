using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.LIBS
{
    public class Common
    {
        public static List<SelectListItem> GetLanguages()
        {
            IEnumerable<Languages> roles = System.Enum.GetValues(typeof(Languages)).Cast<Languages>();
            List<SelectListItem> itemroles = roles.Select(s => new SelectListItem
            {
                Text = s.ToString().Replace("_", " "),
                Value = ((int)s).ToString()
            }).ToList();

            return itemroles;
        }

        public enum Languages
        {
            English = 1,
            Arabic = 2,
            French=3
        }
    }
}
