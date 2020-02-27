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
    public class ContributorController : Controller
    {
        MovieAPI _api = new MovieAPI();

        #region View
        public async Task<IActionResult> Index(ContributorIndexViewModel model)
        {
            ViewBag.Languages = Common.GetLanguages();
            if (model.Filter.LanguageID == 0)
                model.Filter.LanguageID = 1; //set default language english

            List<ContributorData> contributors = new List<ContributorData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/contributor");
            HttpResponseMessage res = await client.GetAsync($"api/contributor/getall/{model.Filter.LanguageID}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                contributors = JsonConvert.DeserializeObject<List<ContributorData>>(results);
            }
            model.Data.contributors = contributors;
            return View(model);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Details(Guid id)
        {
            var contributor = new ContributorData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contributor/getdetail/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                contributor = JsonConvert.DeserializeObject<ContributorData>(results);
            }
            return View(contributor);
        }
        #endregion

        #region Add

        [HttpGet]
        public async Task<IActionResult> create()
        {
            ViewBag.Languages = Common.GetLanguages();

            ContributorViewModel model = new ContributorViewModel();

            #region Bind For Contributor Type
            List<ContributorTypeData> objData = new List<ContributorTypeData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/contributortype");
            HttpResponseMessage res = await client.GetAsync($"api/contributortype/getall/{1}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                objData = JsonConvert.DeserializeObject<List<ContributorTypeData>>(results);

                var selectList = new List<SelectListItem>();
                objData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorTypeID.ToString())));
                model.types = selectList;
                return View(model);
            }
            #endregion

            return View(model);
        }

        [HttpPost]
        public IActionResult create(ContributorViewModel model)
        {
            model.ContributorID = Guid.NewGuid();

            ContributorData data = new ContributorData();
            data.ContributorID = model.ContributorID;
            data.Title = model.Title.Trim();
            data.Name = model.Name.Trim();
            data.Description = model.Description;
            data.LanguageID = model.LanguageID;
            data.IsActive = true;

            List<ContributorManagerData> contributortypeList = new List<ContributorManagerData>();
            model.selectedtypes.ToList().ForEach(a =>
            {
                ContributorManagerData info = new ContributorManagerData();
                info.ID = Guid.NewGuid();
                info.ContributorID = data.ContributorID;
                info.ContributorTypeID = Guid.Parse(a);
                contributortypeList.Add(info);
            });

            data.ContributorManagers = contributortypeList;

            HttpClient client = _api.Initial();
            //Http Post
            var postTask = client.PostAsJsonAsync<ContributorData>("api/contributor/post", data);
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

            HttpClient client = _api.Initial();
            ContributorViewModel model = new ContributorViewModel();
            var result = new ContributorData();
            var res1 = await client.GetAsync($"api/contributor/getdetail/{id}");
            if (res1.IsSuccessStatusCode)
            {
                var results = res1.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ContributorData>(results);
            }

            #region Bind For Contributor Type
            List<ContributorTypeData> objData = new List<ContributorTypeData>();
            //HttpResponseMessage res = await client.GetAsync("api/contributortype");
            HttpResponseMessage res = await client.GetAsync($"api/contributortype/getall/{result.LanguageID}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                objData = JsonConvert.DeserializeObject<List<ContributorTypeData>>(results);

                var selectList = new List<SelectListItem>();
                objData.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.ContributorTypeID.ToString())));
                model.types = selectList;
            }
            #endregion


            model.ContributorID = result.ContributorID;
            model.Title = result.Title;
            model.Name = result.Name;
            model.Description = result.Description;
            model.LanguageID = result.LanguageID;
            //model.types = AreaDB.GetAllAreas(string.Empty, "1").Count() > 0 ? AreaDB.GetAllAreas(string.Empty, "1").Select(T => new SelectListItem() { Value = T.AreaID.ToString(), Text = T.Title }).ToList() : null;
            model.selectedtypes = result.ContributorManagers.Count() > 0 ? result.ContributorManagers.Select(T => T.ContributorTypeID.ToString()).ToList() : null;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, ContributorViewModel model)
        {
            HttpClient client = _api.Initial();

           

            ContributorData data = new ContributorData();
            data.ContributorID = model.ContributorID;
            data.Title = model.Title.Trim();
            data.Name = model.Name.Trim();
            data.Description = model.Description;
            data.LanguageID = model.LanguageID;
            data.IsActive = true;

            #region Delete and save new multiple areas
            //listContributorManagers.ToAsyncEnumerable().ForEach(a => 
            //{
            //    Guid Id = a.ID;
            //    var res = client.DeleteAsync($"api/deletecontributormanager/{Id}");
            //});
            List<ContributorManagerData> contributortypeList = new List<ContributorManagerData>();
            model.selectedtypes.ToList().ForEach(a =>
            {
                ContributorManagerData info = new ContributorManagerData();
                info.ID = Guid.NewGuid();
                info.ContributorID = data.ContributorID;
                info.ContributorTypeID = Guid.Parse(a);
                contributortypeList.Add(info);
            });
            #endregion


            data.ContributorManagers = contributortypeList;


            //Http Put
            var putTask = client.PutAsJsonAsync($"api/contributor/put/{id}", data);
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
            HttpResponseMessage res = await client.DeleteAsync($"api/contributor/delete/{Id}");
            return RedirectToAction("Index");

        }
        #endregion

        #region Ajax Call
        [HttpPost]
        public async Task<JsonResult> getContributorTypesByLanguageID(int lang_id)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
