using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WcfBot.Model
{
    public static class AppSettings
    {
        //public static string Url { get; set; } = "http://telegrambotapp.azurewebsites.net:433/{0}";

        public static string Name { get; set; } = "irisoft_staff_bot";

        public static WebProxy Proxy { get; set; }

        public static string Description { get; set; }
    }
}