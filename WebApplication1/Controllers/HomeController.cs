using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TorontoWasteLookup.Models;
using TorontoWasteLookup.ViewModel;

namespace TorontoWasteLookup.Controllers
{
    public class HomeController : Controller
    {
        public static WasteInfoViewModel model = new WasteInfoViewModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchField)
        {
            var temp = getWasteInfoFromJSON();
            model.wasteInfoList = getWasteInfoFromJSON()
                .Where(x => typeof(WasteInfo).GetProperties().Any(prop => prop.GetValue(x,null).ToString().Contains(searchField))).ToList();
            ViewBag.enteredSearch = searchField;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToFav(string title, string search)
        {
            var selectedWasteInfo = model.wasteInfoList.Where(x => x.title == title).First();
            if (!model.favouriteList.Contains(selectedWasteInfo))
            {
                model.favouriteList.Add(selectedWasteInfo);
            }

            ViewBag.enteredSearch = search;
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult RemoveFromFav(string title, string search)
        {
            var selectedWasteInfo = model.favouriteList.Where(x => x.title == title).First();
            model.favouriteList.Remove(selectedWasteInfo);

            ViewBag.enteredSearch = search;
            return View("Index", model);
        }

        private List<WasteInfo> getWasteInfoFromJSON()
        {
            var jsonString = new WebClient().DownloadString("https://secure.toronto.ca/cc_sr_v1/data/swm_waste_wizard_APR?limit=1000");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<WasteInfo>>(jsonString);
        }
    }
}