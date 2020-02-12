using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Model;
using DXWebApplication.Models;

namespace DXWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            
            return View(WebContext.GetTasks(-1));
        }
        
        public ActionResult GridViewPartialView() 
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", WebContext.GetTasks(-1));
        }
    
    }
}

public enum HeaderViewRenderMode { Full, Title }