using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApp.Helper;
using WebApp.LIBS;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ContributorTypeController : Controller
    {
        MovieAPI _api = new MovieAPI();

        #region View
        public async Task<IActionResult> Index(ContributorTypeViewModel model)
        {
            ViewBag.Languages = Common.GetLanguages();
            if (model.Filter.LanguageID==0)
                model.Filter.LanguageID = 1; //set default language english
            List<ContributorTypeData> types = new List<ContributorTypeData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/contributortype");
            HttpResponseMessage res = await client.GetAsync($"api/contributortype/getall/{model.Filter.LanguageID}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                types = JsonConvert.DeserializeObject<List<ContributorTypeData>>(results);
            }
            
            model.Data.ContributorTypes = types;
            return View(model);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Details(Guid id)
        {
            var contributortype = new ContributorTypeData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contributortype/getdetail/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                contributortype = JsonConvert.DeserializeObject<ContributorTypeData>(results);
            }
            return View(contributortype);
        }
        #endregion

        #region Add

        public ActionResult create()
        {
            ViewBag.Languages = Common.GetLanguages();
            return View();
        }

        [HttpPost]
        public IActionResult create(ContributorTypeData model)
        {
            model.ContributorTypeID = Guid.NewGuid();
            HttpClient client = _api.Initial();
            //Http Post
            var postTask = client.PostAsJsonAsync<ContributorTypeData>("api/contributortype/post/", model);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Languages = Common.GetLanguages();
            var contributortype = new ContributorTypeData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contributortype/getdetail/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                contributortype = JsonConvert.DeserializeObject<ContributorTypeData>(results);
            }
            return View(contributortype);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, ContributorTypeData model)
        {
            HttpClient client = _api.Initial();
            //Http Put
            var putTask = client.PutAsJsonAsync($"api/contributortype/put/{id}", model);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Delete
        public async Task<IActionResult> Delete(Guid Id)
        {

            var model = new ContributorTypeData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/contributortype/delete/{Id}");
            return RedirectToAction("Index");

        }
        #endregion



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
