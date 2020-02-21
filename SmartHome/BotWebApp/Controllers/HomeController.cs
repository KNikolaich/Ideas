using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotWebApp.Models;

namespace BotWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Hook(string hookUrl)
        {
            //string hookUrl = "d45d260b.ngrok.io";
            if (!string.IsNullOrEmpty(hookUrl))
            {
                ViewData["Message"] = Bot.MakeHookAsync(hookUrl).Result;
            }
            return View("Index");
        }
    }
}