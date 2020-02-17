using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace StaffTimesWebAppBot.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "http://telegrambotapp.azurewebsites.net:433/{0}";

        public static string Name { get; set; } = "irisoft_staff_bot";

        public static string Key { get; set; } = "939009222:AAFj7GRQ7YfinCk6gOtL4mgXQFj5ox8k84Y";

        public static WebProxy Proxy { get; set; }


    }
}