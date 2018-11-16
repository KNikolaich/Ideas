using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorDashBoardDExtreme.Models;

namespace DoctorDashBoardDExtreme.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {

            return View(SampleData.GetAllInfo());
        }

        //[HttpGet]
        //public ActionResult GetResults(DataSourceLoadOptions loadOptions)
        //{
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(MockData.Dapartments, loadOptions)), "application/json");
        //}

        //public ActionResult KassaGraph()
        //{
        //    return View();
        //}
    }
}