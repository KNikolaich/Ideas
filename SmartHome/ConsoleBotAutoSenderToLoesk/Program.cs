using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using Telegram.Bot;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleBotAutoSenderToLoesk.Model;
using MihaZupan;

namespace ConsoleBotAutoSenderToLoesk
{
    public class Program
    {
        private static ObservableCollection<TeleUser> _users;
        private static TelegramBotClient bot;

        static void Main(string[] args)
        {
            Model.Telegram t = new Model.Telegram();
            while (true)
            {
                
                Console.WriteLine(DateTime.Now.ToLocalTime());
                t.SendMessage("", Console.ReadLine());

                //Task.Run(RunBot);
                //RunBot();
                
                //Thread.Sleep(500);
            }

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        public static void RunBot()
        {
            _users = new ObservableCollection<TeleUser>();
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("token " + Model.Telegram.token);
            //var proxy = new HttpToSocks5Proxy("95.217.23.149", 46211);
            //var proxy = new WebProxy();
            bot = new TelegramBotClient(Model.Telegram.token) {Timeout = TimeSpan.FromSeconds(10)};
            
            var me = bot.GetMeAsync().Result;
            Console.WriteLine("GetMe " + me.FirstName + " " + me.Id);
            bot.OnMessage += Bot_OnMessage;
            bot.StartReceiving();

        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var messageChat = e.Message.Chat;
            string msg = $"{DateTime.Now}: {messageChat.FirstName} {messageChat.Id} {e.Message.Text}";
            File.AppendAllText("data.log", $"{msg}\n");
            Debug.WriteLine(msg);
            var user = new TeleUser(messageChat.FirstName, messageChat.Id);
            if (!_users.Contains(user))
            {
                _users.Add(user);
            }
            Console.WriteLine("Message " + msg);
            await bot.SendTextMessageAsync(user.Id, $": You said: {msg}").ConfigureAwait(false);
        }
    }
}
