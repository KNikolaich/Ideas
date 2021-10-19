using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCore
{
    public static class Command
    {

        private static string _prefixLevel = "level_";
        //private static string _prefixInterval = "interval_";


        public static EventHandler<CommandArg> CommandEventHandler;

        internal static async Task GetRequest(Message message)
        {


            TelegramBotClient botClient = Sender.GetInstance();
            switch (message.Text)
            {
                case "/start":
                    if (SetChatLevel(message.Chat.Id, SubscribeLevelEnum.Warning))

                        await botClient.SendTextMessageAsync(message.Chat.Id, $"Приветствую тебя, {message.From.FirstName}!");
                    break;

                case "/stop":
                    if (SetChatLevel(message.Chat.Id, SubscribeLevelEnum.None))
                        await botClient.SendTextMessageAsync(message.Chat.Id, $"Пока, дружище, {message.From.FirstName}!");

                    break;
                case "/info":
                    var config = Config.Load().Subscribers.Where(ss => ss.ChatId == message.Chat.Id).FirstOrDefault();
                    if (config == null)
                        await botClient.SendTextMessageAsync(message.Chat.Id, $"Начните со [/start]!");
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, $"{config} для {message.From.FirstName}!");
                        OnCollectInfo(botClient, CommandsEnum.Info);
                    }
                    break;

                case "/level":
                    var keyboard = KeyboardOnLevel(typeof(SubscribeLevelEnum), _prefixLevel);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери требуемый уровень", replyMarkup: keyboard);

                    break;

                default:

                    if (!string.IsNullOrEmpty(message.Text) && message.Text.Contains("/level"))
                    {
                        if (SetChatLevel(message.Chat.Id, SubscribeLevelEnum.Debug))
                            await botClient.SendTextMessageAsync(message.Chat.Id, $"Левел, {message.From.FirstName}!");
                    }

                    break;
            }
        }

        private static void OnCollectInfo(TelegramBotClient bot, CommandsEnum command)
        {
            CommandEventHandler?.Invoke(bot, new CommandArg(command));
        }


        private static InlineKeyboardMarkup KeyboardOnLevel( Type enumType, string prefix)
        {
            var ikm = new List<InlineKeyboardButton[]>();
            var line = new InlineKeyboardButton[3];
            short iLine = 0;
            var values = Enum.GetValues(enumType);
            foreach (Enum levelEnum in values)
            {
                if (iLine > 2)
                {
                    ikm.Add(line);
                    line = new InlineKeyboardButton[3];
                    iLine = 0;
                }
                line[iLine] = InlineKeyboardButton.WithCallbackData(levelEnum.ToString(), prefix + levelEnum.ToString());
                iLine++;
            }
            ikm.Add(line);

            return new InlineKeyboardMarkup(ikm);

        }

        internal static async Task ReworkCallbackQuery(CallbackQuery callbackQuery)
        {
            TelegramBotClient botClient = Sender.GetInstance();
            var data = callbackQuery.Data;
            var message = callbackQuery.Message;
            if (data.Contains(_prefixLevel))
            {
                var levelStr = data.Replace(_prefixLevel, "");

                if (Enum.TryParse<SubscribeLevelEnum>(levelStr, out var level))
                {
                    if (SetChatLevel(message.Chat.Id, level))
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, $"Левел изменен на {level}!");
                    }
                }
            }
            //else if (data.Contains(_prefixInterval))
            //{
            //    var levelStr = data.Replace(_prefixInterval, "");

            //    if (Enum.TryParse<TimeInterval>(levelStr, out var interval))
            //    {
            //        if (Config.Load().SetInterval(message.Chat.Id, interval))
            //        {
            //            await botClient.SendTextMessageAsync(message.Chat.Id, $"Интервал изменен на {interval}!");
            //        }
            //    }
            //}
        }

        private static bool SetChatLevel(long idChat, SubscribeLevelEnum level)
        {
            //return true;
            var config = Config.Load();
            if (level == SubscribeLevelEnum.None)
            {
                return config.Remove(idChat);
            }
            // добавляем или правми строку
            return config.SetOrCreate(idChat, level);
        }
    }
}
