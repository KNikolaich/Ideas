using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using Telegram.Bot;
using WcfBot.Properties;

namespace WcfBot.Model
{
    public class ProxyFinder
    {
        static List<string> _blackList = new List<string>(); // реализуем технологию черного списка прокси

        static List<String> _whiteList = new List<String>()
        {
            //"1.179.184.158:56633",
            @"http://101.51.106.70:45699/"
        }; // реализуем технологию белого списка прокси


        public static TelegramBotClient GetBot()
        {
            lock (Settings.Default)
            {
                try
                {
                    var bot = Bot.Get(AppSettings.Proxy);
                    return bot;
                }
                catch (Exception ex)
                {
                }
                foreach (var webProxy in _whiteList)
                {
                    WebProxy proxy = null;
                    try
                    {
                        proxy = new WebProxy(webProxy, false);
                        AppSettings.Proxy = proxy;
                        var bot = Bot.Get(AppSettings.Proxy);
                        //var aboutMe = bot.GetMeAsync().Result;
                        return bot;
                    }
                    catch (Exception ex)
                    {
                        _blackList.Add(proxy.Address.ToString());

                    }
                }
                foreach (var webProxy in GetProxyParserList())
                {
                    try
                    {
                        Debug.WriteLine(webProxy.Address);
                        if(_blackList.Contains(webProxy.Address.ToString()))
                            continue;
                        var bot = Bot.Get(webProxy);
                        //var bot = new TelegramBotClient(AppSettings.Key, webProxy) {Timeout = TimeSpan.FromSeconds(15)};
                        //var aboutMe = bot.GetMeAsync().Result;
                        AppSettings.Proxy = webProxy;
                        return bot;
                    }
                    catch (Exception ex)
                    {

                        _blackList.Add(webProxy.Address.ToString());
                        
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
                html = wc.DownloadString("https://www.socks-proxy.net/");//"https://www.us-proxy.org");
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