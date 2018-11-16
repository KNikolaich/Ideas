using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExtreme.AspNet.Data;
using DoctorDashboard.Models;
using Newtonsoft.Json;

namespace DoctorDashboard.Controllers {
    public class HomeController : Controller {
        public ActionResult ByDepartments() {
            return View();
        }

        public ActionResult Index()
        {
            return View(new AllInfo
            {
                Date = DateTime.Now.ToString("t"),
                Received = "2563",
                InReceptionCase = "2364",
                Death = "64",
                Include = "54",
                Transferred = "32",
                Discharged = "34",
                Free = "12",
                FreeBeds = "15",
                InDep = "1283",
                IsRegistred = "26",
                ScheduledVisits = "1283",
                IssuedCoupons = "685",
                ConfirmedPatientsCame = "863",
                OperatingIsBusy = "12",
                SurgeryConducted = "7",
                DmsInvoicedAmount = 2863623456,
                DmsAmountOfPaidInvoices = 2863466911,
                DmsAmountOfdeniedInvoices = 156545,

                OmsInvoicedAmount = 2863656,
                OmsAmountOfPaidInvoices = 2831522,
                OmsAmountOfdeniedInvoices = 32134,
            });
        }

        [HttpGet]
        public ActionResult GetResults(DataSourceLoadOptionsBase loadOptions)
        {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(MockData.Dapartments, loadOptions)), "application/json");
        }
        
        public ActionResult KassaGraph() {
            return View();
        }
    }
}