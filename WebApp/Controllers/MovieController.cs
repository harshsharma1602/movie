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
    public class MovieController : Controller
    {
        MovieAPI _api = new MovieAPI();

        #region View
        public async Task<IActionResult> Index(MovieIndexViewModel model)
        {
            ViewBag.Languages = Common.GetLanguages();
            if (model.Filter.LanguageID == 0)
                model.Filter.LanguageID = 1;

            List<MovieData> movies = new List<MovieData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/movie");
            HttpResponseMessage res = await client.GetAsync($"api/movie/getall/{model.Filter.LanguageID}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                movies = JsonConvert.DeserializeObject<List<MovieData>>(results);
            }
            model.Data.movies = movies;
            return View(model);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = new MovieData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/movie/getdetail/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<MovieData>(results);
            }
            return View(movie);
        }
        #endregion

        #region Add

        [HttpGet]
        public async Task<IActionResult> create()
        {
            ViewBag.Languages = Common.GetLanguages();

            MovieViewModel model = new MovieViewModel();
            #region Bind For Contributors
            List<ContributorData> objContributorData = new List<ContributorData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/contributor");
            HttpResponseMessage res = await client.GetAsync($"api/contributor/getall/{1}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                objContributorData = JsonConvert.DeserializeObject<List<ContributorData>>(results);

                var selectList = new List<SelectListItem>();
                objContributorData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorID.ToString())));
                model.contributors = selectList;
            }
            #endregion

            #region Bind For Contributors Type
            List<ContributorTypeData> objTypeData = new List<ContributorTypeData>();
            HttpResponseMessage resT = await client.GetAsync($"api/contributortype/getall/{1}");
            if (resT.IsSuccessStatusCode)
            {
                var results = resT.Content.ReadAsStringAsync().Result;
                objTypeData = JsonConvert.DeserializeObject<List<ContributorTypeData>>(results);

                var selectList = new List<SelectListItem>();
                objTypeData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorTypeID.ToString())));
                model.types = new List<SelectListItem>();
            }
            #endregion

            #region Bind For Generes
            List<GenreData> objGenreData = new List<GenreData>();
            //HttpResponseMessage res1 = await client.GetAsync("api/genre");
            HttpResponseMessage res1 = await client.GetAsync($"api/genre/getall/{1}");
            if (res1.IsSuccessStatusCode)
            {
                var results1 = res1.Content.ReadAsStringAsync().Result;
                objGenreData = JsonConvert.DeserializeObject<List<GenreData>>(results1);

                var selectList = new List<SelectListItem>();
                objGenreData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.GenreID.ToString())));
                model.genres = selectList;
            }
            #endregion


            return View(model);
        }

        [HttpPost]
        public IActionResult create(MovieViewModel model)
        {
            model.MovieID = Guid.NewGuid();

            MovieData data = new MovieData();
            data.MovieID = model.MovieID;
            data.Title = model.Title.Trim();
            data.Name = model.Name.Trim();
            data.Description = model.Description;
            data.LanguageID = model.LanguageID;
            data.IsActive = true;

            #region Adding MovieContributor
            List<MovieContributorData> moviecontributorList = new List<MovieContributorData>();
            model.selectedcontributors.ToList().ForEach(a =>
            {
                MovieContributorData info = new MovieContributorData();
                info.ID = Guid.NewGuid();
                info.MovieID = data.MovieID;
                info.ContributorID = Guid.Parse(a);
                moviecontributorList.Add(info);
            });
            data.MovieContributors = moviecontributorList;
            #endregion

            #region Adding Movie Contributor Types
            List<MovieContributorTypeData> movietypeList = new List<MovieContributorTypeData>();
            model.selectedtypes.ToList().ForEach(a =>
            {
                MovieContributorTypeData info_type = new MovieContributorTypeData();
                info_type.ID = Guid.NewGuid();
                info_type.MovieID = data.MovieID;
                info_type.ContributorTypeID = Guid.Parse(a);
                movietypeList.Add(info_type);
            });
            data.MovieContributorTypes = movietypeList;
            #endregion

            #region Adding Movie Genres
            List<MovieGenreData> moviegenreList = new List<MovieGenreData>();
            model.selectedgenres.ToList().ForEach(a =>
            {
                MovieGenreData info = new MovieGenreData();
                info.ID = Guid.NewGuid();
                info.MovieID = data.MovieID;
                info.GenreID = Guid.Parse(a);
                moviegenreList.Add(info);
            });
            data.MovieGenres = moviegenreList;
            #endregion


            HttpClient client = _api.Initial();
            //Http Post
            //var postTask = client.PostAsJsonAsync<MovieData>("api/movie", data);
            var postTask = client.PostAsJsonAsync<MovieData>("api/movie/post", data);
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

            MovieViewModel model = new MovieViewModel();
            
            HttpClient client = _api.Initial();
            var result = new MovieData();
            var res2 = await client.GetAsync($"api/movie/getdetail/{id}");
            if (res2.IsSuccessStatusCode)
            {
                var results = res2.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<MovieData>(results);
            }

            #region Bind Contributors
            List<ContributorData> objData = new List<ContributorData>();
            HttpResponseMessage res = await client.GetAsync($"api/contributor/getall/{result.LanguageID}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                objData = JsonConvert.DeserializeObject<List<ContributorData>>(results);

                var selectList = new List<SelectListItem>();
                objData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorID.ToString())));
                model.contributors = selectList;
            }
            #endregion

            #region Bind Contributor Types
            List<ContributorTypeData> objTypeData = new List<ContributorTypeData>();
            HttpResponseMessage restypes = await client.GetAsync($"api/contributortype/getall/{result.LanguageID}");
            if (restypes.IsSuccessStatusCode)
            {
                var results = restypes.Content.ReadAsStringAsync().Result;
                objTypeData = JsonConvert.DeserializeObject<List<ContributorTypeData>>(results);

                var selectList = new List<SelectListItem>();
                objTypeData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorTypeID.ToString())));
                model.types = selectList;
            }
            #endregion

            #region Bind Genres
            List<GenreData> objGenreData = new List<GenreData>();
            /*HttpResponseMessage res1 = await client.GetAsync("api/genre");*/
            HttpResponseMessage res1 = await client.GetAsync($"api/genre/getall/{result.LanguageID}");
            if (res1.IsSuccessStatusCode)
            {
                var results = res1.Content.ReadAsStringAsync().Result;
                objGenreData = JsonConvert.DeserializeObject<List<GenreData>>(results);

                var selectList = new List<SelectListItem>();
                objGenreData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.GenreID.ToString())));
                model.genres = selectList;
            }
            #endregion

            model.MovieID = result.MovieID;
            model.Title = result.Title;
            model.Name = result.Name;
            model.Description = result.Description;
            model.LanguageID = result.LanguageID;
            //model.types = AreaDB.GetAllAreas(string.Empty, "1").Count() > 0 ? AreaDB.GetAllAreas(string.Empty, "1").Select(T => new SelectListItem() { Value = T.AreaID.ToString(), Text = T.Title }).ToList() : null;
            model.selectedcontributors = result.MovieContributors.Count() > 0 ? result.MovieContributors.Select(T => T.ContributorID.ToString()).ToList() : null;
            model.selectedtypes = result.MovieContributorTypes.Count() > 0 ? result.MovieContributorTypes.Select(T => T.ContributorTypeID.ToString()).ToList() : null;
            model.selectedgenres = result.MovieGenres.Count() > 0 ? result.MovieGenres.Select(T => T.GenreID.ToString()).ToList() : null;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, MovieViewModel model)
        {
            HttpClient client = _api.Initial();

            MovieData data = new MovieData();
            data.MovieID = model.MovieID;
            data.Title = model.Title.Trim();
            data.Name = model.Name.Trim();
            data.Description = model.Description;
            data.LanguageID = model.LanguageID;
            data.IsActive = true;

            #region save multiple contributors
            List<MovieContributorData> contributorList = new List<MovieContributorData>();
            model.selectedcontributors.ToList().ForEach(a =>
            {
                MovieContributorData info = new MovieContributorData();
                info.ID = Guid.NewGuid();
                info.MovieID = data.MovieID;
                info.ContributorID = Guid.Parse(a);
                contributorList.Add(info);
            });
            data.MovieContributors = contributorList;
            #endregion

            #region save multiple contributor types
            List<MovieContributorTypeData> contributortypeList = new List<MovieContributorTypeData>();
            model.selectedtypes.ToList().ForEach(a =>
            {
                MovieContributorTypeData info = new MovieContributorTypeData();
                info.ID = Guid.NewGuid();
                info.MovieID = data.MovieID;
                info.ContributorTypeID = Guid.Parse(a);
                contributortypeList.Add(info);
            });
            data.MovieContributorTypes = contributortypeList;
            #endregion

            #region save multiple genres
            List<MovieGenreData> genreList = new List<MovieGenreData>();
            model.selectedgenres.ToList().ForEach(a =>
            {
                MovieGenreData info = new MovieGenreData();
                info.ID = Guid.NewGuid();
                info.MovieID = data.MovieID;
                info.GenreID = Guid.Parse(a);
                genreList.Add(info);
            });
            data.MovieGenres = genreList;
            #endregion

            //Http Put
            var putTask = client.PutAsJsonAsync($"api/movie/put/{id}", data);
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

            var model = new MovieData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/movie/delete/{Id}");
            return RedirectToAction("Index");

        }
        #endregion

        #region Ajax Call For Contributors
        [HttpPost]
        public async Task<JsonResult> getContributorsByLanguageID(int lang_id)
        {
            List<ContributorData> types = new List<ContributorData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/contributortype");
            var res = await client.GetAsync($"api/contributor/getall/{lang_id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                types = JsonConvert.DeserializeObject<List<ContributorData>>(results);
            }
            var selectList = new List<SelectListItem>();
            types.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorID.ToString())));
            return Json(selectList);

        }
        #endregion

        #region Ajax Call For Contributor Type
        [HttpPost]
        public async Task<JsonResult> getContributorTypeByLanguageID(int lang_id)
        {
            List<ContributorTypeData> types = new List<ContributorTypeData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/contributortype");
            var res = await client.GetAsync($"api/contributortype/getall/{lang_id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                types = JsonConvert.DeserializeObject<List<ContributorTypeData>>(results);
            }
            var selectList = new List<SelectListItem>();
            types.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorTypeID.ToString())));
            return Json(selectList);

        }
        #endregion

        #region Ajax Call For Genres
        [HttpPost]
        public async Task<JsonResult> getGenresByLanguageID(int lang_id)
        {
            List<GenreData> genres = new List<GenreData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/contributortype");
            var res = await client.GetAsync($"api/genre/getall/{lang_id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                genres = JsonConvert.DeserializeObject<List<GenreData>>(results);
            }
            var selectList = new List<SelectListItem>();
            genres.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.GenreID.ToString())));
            return Json(selectList);

        }
        #endregion

        #region Ajax Call For Contributor Type
        [HttpPost]
        public  JsonResult getContributorTypesByContributorID(List<String> contributors)
        {
            List<ContributorTypeData> types = new List<ContributorTypeData>();
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<List<string>>("api/contributortype/GetContributorTypesByContributorId", contributors);
            postTask.Wait();

            var res = postTask.Result;
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                types = JsonConvert.DeserializeObject<List<ContributorTypeData>>(results);
            }
            var selectList = new List<SelectListItem>();
            types.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorTypeID.ToString())));
            return Json(selectList);

        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
