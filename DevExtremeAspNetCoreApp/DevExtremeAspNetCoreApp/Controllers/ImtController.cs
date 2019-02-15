using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtremeAspNetCoreApp.Models;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreApp.Controllers
{
    public class ImtController : Controller
    {

        public IActionResult Edit()
        {
            var imt = new ImtCalc();
            return View(imt);
        }
    }
}
