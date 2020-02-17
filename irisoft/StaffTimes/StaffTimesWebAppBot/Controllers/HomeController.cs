using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaffTimesWebAppBot.Models;

namespace StaffTimesWebAppBot.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return  "It`s my telegram bot D:" + AppSettings.Proxy?.Credentials;
        }
        
    }
}