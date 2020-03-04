using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telegram.Bot;
using WebCoreApp2.Models;
using WebCoreApp2.Models.Commands;

namespace WebCoreApp2.Models
{
    public class Bot
    {
        private static TelegramBotClient _botClient;
        private static List<Command> _commandsList;

        public static IReadOnlyList<Command> Commands => _commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync(AppSettings appSettings, bool makeHook = false)
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _commandsList = new List<Command>();
            _commandsList.Add(new StartCommand());
            //TODO: Add more commands

            _botClient = new TelegramBotClient(appSettings.Key);
            if (makeHook)
            {
                string hook = $"https://{appSettings.Url}/{"api/message/update"}";
                await _botClient.SetWebhookAsync(hook);
            }
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
