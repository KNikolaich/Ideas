using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DwnldRlss.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Version = System.Reflection.Assembly.GetAssembly(typeof(AboutController)).GetName().Version.ToString();
            return View();
        }
    }
}