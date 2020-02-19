using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ConsoleBotAutoSenderToLoesk.Model
{
    public class Telega
    {
        public static string token = "939009222:AAFj7GRQ7YfinCk6gOtL4mgXQFj5ox8k84Y";

        string id = "420515519";
        private static TelegramBotClient _bot;

        public Telega()
        {
            //GetProxyParserList();
        }

        private IWebProxy wp;
        private List<IWebProxy> proxiList = new List<IWebProxy>();

        public Task SendMessage(string msg)
        {
            return Task.Factory.StartNew(() =>
            {
                bool proxyOk = false;
                if (_bot != null)
                {
                    _bot.OnMessage -= Bot_OnMessage;
                }

                _bot = new TelegramBotClient(token/*, GetNewProxy()*/) {Timeout = TimeSpan.FromSeconds(10)};
                        
                while (!proxyOk)
                {

                    try
                    {
                        var me = _bot.GetMeAsync().Result;
                        Console.WriteLine("GetMe " + me.FirstName + " " + me.Id);
                        proxyOk = true;

                        Console.WriteLine("proxyOk " + wp.Credentials);
                    }
                    catch (Exception ex)
                    {
                        proxiList.Remove(wp);
                        //wp = proxiList.FirstOrDefault()
                        //SendMessage(chatId, msg);
                        Debug.WriteLine(ex.Message + ex.InnerException?.Message + ex.InnerException?.InnerException?.Message);
                    }
                }
                _bot.OnMessage += Bot_OnMessage;
                _bot.StartReceiving();
            });
        }

        private IWebProxy GetNewProxy()
        {
            if (wp == null)
            {
                if (proxiList.Count == 0)
                {
                    GetProxyParserList();
                }

                wp = proxiList.First();
            }
            return wp;
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var messageChat = e.Message.Chat;
            string msg = $"{DateTime.Now}: {messageChat.FirstName} {messageChat.Id} {e.Message.Text}";
            File.AppendAllText("data.log", $"{msg}\n");
            Debug.WriteLine(msg);
            //var user = new TeleUser(messageChat.FirstName, messageChat.Id);

            await _bot.SendTextMessageAsync(messageChat.Id, $": You said: {msg}").ConfigureAwait(false);
        }

        private IEnumerable<WebProxy> GetProxyParserList()
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
                    var strings = match.Value.Split(new string[]{ "</td><td>" }, StringSplitOptions.None);
                    yield return new WebProxy($"{strings[0]}", int.Parse(strings[1]));
                }
            }
            
        }
    }
}
