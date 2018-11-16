using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorDashboard.Controllers
{
    public class PopupControlController : Controller
    {
        // GET: PopupControl
        //public override string Name { get { return "PopupControl"; } }

        //public ActionResult Index()
        //{
        //    return DataBinding();
        //}

        public ActionResult ModalMode()
        {
            return View("ModalMode");
        }
    }
}