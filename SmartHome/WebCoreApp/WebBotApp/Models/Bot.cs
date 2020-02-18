using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using WebBotApp.Models.Commands;

namespace WebBotApp.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient == null)
            {
                commandsList = new List<Command>
                {
                    new StartCommand()
                };
                //TODO: Add more commands

                botClient = new TelegramBotClient(AppSettings.Key);
                string hook = string.Format(AppSettings.Url, "api/message/update");
                await botClient.SetWebhookAsync(hook);
            }

            return botClient;
        }
    }
}
