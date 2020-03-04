using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Configuration;
using BotWebApp.Models.Commands;
using Telegram.Bot;

namespace BotWebApp.Models
{
    public class Bot
    {
        private static TelegramBotClient _botClient;
        private static List<Command> _commandsList;

        public static IReadOnlyList<Command> Commands => _commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _commandsList = new List<Command>();
            _commandsList.Add(new StartCommand());
            //TODO: Add more commands
            //AppSettings sett = AppSettings.Single;
            _botClient = new TelegramBotClient(AppSettings.Single.Key);
            /*if (makeHook)
            {
                string hook = $"https://{sett.Url}/{"api/message/update"}";
                await _botClient.SetWebhookAsync(hook);
            }*/
            return _botClient;
        }

        public static async Task<string> MakeHookAsync(string urlHook)
        {
            var resultMsg = "Not found bot";

            if (_botClient != null)
            {
                try
                {
                    string hook = $"https://{urlHook}/{"api/message/update"}";
                    await _botClient.SetWebhookAsync(hook);
                    resultMsg = "ok";
                }
                catch (Exception e)
                {
                    resultMsg = e.InnerException?.InnerException?.Message + Environment.NewLine +
                                e.InnerException?.Message + Environment.NewLine +
                                e.Message + Environment.NewLine;
                }
            }
            return resultMsg;
        }
    }
}
