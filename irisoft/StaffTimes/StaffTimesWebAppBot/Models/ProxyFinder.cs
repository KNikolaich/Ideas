using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using Telegram.Bot;

namespace StaffTimesWebAppBot.Models
{
    public class ProxyFinder
    {
        static List<WebProxy> _blackList = new List<WebProxy>(); // реализуем технологию черного списка прокси


        public static WebProxy LookUpWebProxy()
        {
            lock (AppSettings.Key)
            {
                foreach (var webProxy in GetProxyParserList())
                {
                    try
                    {

                        var bot = new TelegramBotClient(AppSettings.Key, webProxy) {Timeout = TimeSpan.FromSeconds(10)};
                        var aboutMe = bot.GetMeAsync().Result;
                        AppSettings.Proxy = webProxy;
                        return webProxy;
                    }
                    catch (Exception ex)
                    {
                        _blackList.Add(webProxy);

                    }
                }
            }
            

            return null;
        }

        private static IEnumerable<WebProxy> GetProxyParserList()
        {
            string html;
            using (WebClient wc = new WebClient())
            {
                html = wc.DownloadString("https://www.sslproxies.org/");
            }

            Regex regex = new Regex(@"\d+(.)\d+(.)\d+(.)\d+(</td><td>)\d+");
            MatchCollection mc = regex.Matches(html);


            if (mc.Count > 0)
            {
                foreach (Match match in mc)
                {
                    var strings = match.Value.Split(new string[] { "</td><td>" }, StringSplitOptions.None);
                    yield return new WebProxy($"{strings[0]}", int.Parse(strings[1]));
                }
            }

        }
    }
}