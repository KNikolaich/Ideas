using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;
using Telegram.Bot;
using WebCoreApp.Models.Commands;

namespace WebCoreApp.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync(AppSettings appSettings)
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(appSettings.Key);
            string hook = $"https://{appSettings.Url}/{"api/message/update"}";
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
