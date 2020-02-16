using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using StaffTimesWebAppBot.Commands;
using Telegram.Bot;

namespace StaffTimesWebAppBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> _commandList;

        public static IReadOnlyList<Command> Commands
        {
            get => _commandList.AsReadOnly();
        }


        public async static Task<TelegramBotClient> Get()
        {
            if (client == null)
            {
                _commandList = new List<Command>();
                _commandList.Add(new HelloCommand());
                // TOdo add new commands

                client = new TelegramBotClient(AppSettings.Key);
                var hook = string.Format(AppSettings.Url, "api/message/update");
                await client.SetWebhookAsync(hook);
            } 
            return client;
        }
    }
}