using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using WebAppBot.Commands;

namespace WebAppBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> _commandList;

        public static IReadOnlyList<Command> Commands
        {
            get => _commandList.AsReadOnly();
        }


        public static TelegramBotClient Get(WebProxy webProxy)
        {
            //if (client == null)
            {
                _commandList = new List<Command>();
                _commandList.Add(new HelloCommand());
                // TOdo add new commands

                client = new TelegramBotClient(AppSettings.Key, AppSettings.Proxy);
                var me = client.GetMeAsync().Result;
                AppSettings.Description = me.ToString();
                client.OnMessage += Bot_OnMessage;
                client.StartReceiving();
                //var hook = string.Format(AppSettings.Url, "api/message/update");
                //await client.SetWebhookAsync(hook);
            } 
            return client;
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var messageChat = e.Message.Chat;
            string msg = $"{DateTime.Now}: {messageChat.FirstName} {messageChat.Id} {e.Message.Text}";
            //File.AppendAllText("data.log", $"{msg}\n");
            Debug.WriteLine(msg);
            //var user = new TeleUser(messageChat.FirstName, messageChat.Id);

            await client.SendTextMessageAsync(messageChat.Id, $": You said: {msg}").ConfigureAwait(false);

        }
    }
}