using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Telegram.Bot;
using WebAppBot.Models;
using static WebAppBot.Models.ProxyFinder;

namespace WebAppBot
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private TelegramBotClient _bot;

        protected void Application_Start()
        {
            while (AppSettings.Proxy == null)
            {
                _bot = ProxyFinder.LookUpWebProxy();

               
            }

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
