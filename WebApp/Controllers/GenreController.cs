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
    public class GenreController : Controller
    {
        MovieAPI _api = new MovieAPI();

        #region View
        public async Task<IActionResult> Index(GenreViewModel model)
        {
            ViewBag.Languages = Common.GetLanguages();
            if (model.Filter.LanguageID == 0)
                model.Filter.LanguageID = 1; //set default langage english

            List<GenreData> genres = new List<GenreData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/genre");
            HttpResponseMessage res = await client.GetAsync($"api/genre/getall/{model.Filter.LanguageID}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                genres = JsonConvert.DeserializeObject<List<GenreData>>(results);
            }
            model.Data.genres = genres;
            return View(model);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Details(Guid id)
        {
            var genre = new GenreData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/genre/getdetail/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                genre = JsonConvert.DeserializeObject<GenreData>(results);
            }
            return View(genre);
        }
        #endregion

        #region Add

        public ActionResult create()
        {
            ViewBag.Languages = Common.GetLanguages();
            return View();
        }

        [HttpPost]
        public IActionResult create(GenreData model)
        {
            model.GenreID = Guid.NewGuid();
            HttpClient client = _api.Initial();
            //Http Post
            var postTask = client.PostAsJsonAsync<GenreData>("api/genre/post", model);
            postTask.Wait();

            var result = postTask.Result;
            if(result.IsSuccessStatusCode)
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
            var genre = new GenreData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/genre/getdetail/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                genre = JsonConvert.DeserializeObject<GenreData>(results);
            }
            return View(genre);
        }

        [HttpPost]
        public IActionResult Edit(Guid id,GenreData model)
        {
            HttpClient client = _api.Initial();
            //Http Put
            var putTask = client.PutAsJsonAsync($"api/genre/put/{id}", model);
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

            var model = new GenreData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/genre/delete/{Id}");
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
