using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleBotAutoSenderToLoesk.Model
{
    public class Telegram
    {
        public static string token = "939009222:AAFj7GRQ7YfinCk6gOtL4mgXQFj5ox8k84Y";

        string id = "420515519";

        public Telegram()
        {
            //GetProxyParserList();
        }
        private IWebProxy wp;
        private List<IWebProxy> proxiList = new List<IWebProxy>();

        public Task SendMessage(string chatId, string msg)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        if (wp == null)
                        {
                            if (proxiList.Count == 0)
                            {
                                GetProxyParserList();
                            }
                            wp = proxiList.First();
                        }
                        else
                            wc.Proxy = wp;

                        string response =
                            wc.DownloadString(
                                $"https://api.telegram.org/bot{token}/sendmessage?chat_id={id}&text={msg}");
                        Console.WriteLine(response);
                    }
                }
                catch (Exception ex)
                {
                    proxiList.Remove(wp);
                    wp = proxiList.FirstOrDefault();
                    SendMessage(chatId, msg);
                }
            });
        }

        private void GetProxyParserList()
        {
            using (WebClient wc = new WebClient())
            {
                string html = wc.DownloadString("https://www.sslproxies.org/");
                Regex regex = new Regex(@"\d+(.)\d+(.)\d+(.)\d+(</td><td>)\d+");
                MatchCollection mc = regex.Matches(html);
                if (mc.Count > 0)
                {
                    foreach (Match match in mc)
                    {
                        var strings = match.Value.Split(new string[]{ "</td><td>" }, StringSplitOptions.None);
                        var webProxy = new WebProxy($"{strings[0]}", int.Parse(strings[1]));
                        proxiList.Add(webProxy);
                        Console.WriteLine(strings[0] + ":" + strings[1]);
                    }
                }
            }
        }
    }
}
