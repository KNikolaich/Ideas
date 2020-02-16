using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Telegram.Bot;

namespace WebAppBot.Models
{
    public class ProxyFinder
    {
        static List<WebProxy> _blackList = new List<WebProxy>(); // реализуем технологию черного списка прокси

        static List<String> _whiteList = new List<String>()
        {
            //"1.179.184.158:56633",
            @"http://101.51.106.70:45699/"
        }; // реализуем технологию белого списка прокси


        public static TelegramBotClient LookUpWebProxy()
        {
            lock (AppSettings.Key)
            {
                foreach (var webProxy in _whiteList)
                {
                    WebProxy proxy = null;
                    try
                    {
                        proxy = new WebProxy(webProxy, false);
                        var bot = Bot.Get(proxy);
                        //var aboutMe = bot.GetMeAsync().Result;
                        AppSettings.Proxy = proxy;
                        return bot;
                    }
                    catch (Exception ex)
                    {
                        _blackList.Add(proxy);

                    }
                }
                foreach (var webProxy in GetProxyParserList())
                {
                    try
                    {
                        var bot = Bot.Get(webProxy);
                        //var bot = new TelegramBotClient(AppSettings.Key, webProxy) {Timeout = TimeSpan.FromSeconds(15)};
                        //var aboutMe = bot.GetMeAsync().Result;
                        AppSettings.Proxy = webProxy;
                        return bot;
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
                html = wc.DownloadString("https://www.us-proxy.org");
            }

            Regex regex = new Regex(@"\d+(.)\d+(.)\d+(.)\d+(</td><td>)\d+");
            MatchCollection mc = regex.Matches(html);


            if (mc.Count > 0)
            {
                foreach (Match match in mc)
                {
                    var strings = match.Value.Split(new string[] { "</td><td>" }, StringSplitOptions.None);
                    System.Diagnostics.Debug.WriteLine($"{strings[0]}:{int.Parse(strings[1])}");
                    yield return new WebProxy($"{strings[0]}", int.Parse(strings[1]));
                }
            }

        }
    }
}