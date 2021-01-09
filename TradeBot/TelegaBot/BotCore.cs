using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Binance.API.Csharp.Client.Utils;
using Binance.API.Csharp.Client.Models.Enums;

namespace TelegaBot
{
    /// <summary>
    /// Основа бота
    /// </summary>
    public class BotCore
    {
        static string _token = "882717145:AAENoKNk3xjOgfS3Sm0sutUIcDu117JR3n8"; // smartTrade_kf
        private bool _iAmBusy;
        static TelegramBotClient _bot;
        static object o = new object();
        private static string _prefixLevel = "level_";
        private static string _prefixInterval = "interval_";

        public EventHandler<CommandArg> CommandEventHandler;

        public async Task ReadChatsAsync()
        {
            if (_iAmBusy)
                return;
            _iAmBusy = true;
            try
            {
                GetInstance();

                await _bot.SetWebhookAsync("");
                //Bot.SetWebhook(""); // Обязательно! убираем старую привязку к вебхуку для бота
                int offset = 0; // отступ по сообщениям
                while (true)
                {
                    Thread.Sleep(100);
                    var updates = await _bot.GetUpdatesAsync(offset); // получаем массив обновлений

                    foreach (var update in updates) // Перебираем все обновления
                    {
                        try
                        {
                            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                            {
                                await ReWorkMessage(update.Message);
                            }
                            else if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
                            {
                                await ReworkCallbackQuery(update.CallbackQuery);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            offset = update.Id + 1;
                        }
                    }

                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
            }
            finally
            {
                _iAmBusy = false;
            }
        }

        private async Task ReworkCallbackQuery(Telegram.Bot.Types.CallbackQuery callbackQuery)
        {
            var data = callbackQuery.Data;
            var message = callbackQuery.Message;
            if (data.Contains(_prefixLevel))
            {
                var levelStr = data.Replace(_prefixLevel, "");

                if (Enum.TryParse<SubscribeLevelEnum>(levelStr, out var level))
                {
                    if (SetChatLevel(message.Chat.Id, level))
                    {
                        await _bot.SendTextMessageAsync(message.Chat.Id, $"Левел изменен на {level}!");
                    }
                }
            }
            else if (data.Contains(_prefixInterval))
            {
                var levelStr = data.Replace(_prefixInterval, "");

                if (Enum.TryParse<TimeInterval>(levelStr, out var interval))
                {
                    if (Config.Load().SetInterval(message.Chat.Id, interval))
                    {
                        await _bot.SendTextMessageAsync(message.Chat.Id, $"Интервал изменен на {interval}!");
                    }
                }
            }
        }

        public void SendMsg(SubscribeLevelEnum level, string message)
        {
            var config = Config.Load();
            foreach(var subscriber in config.Subscribers)
            {
                if(subscriber.Level >= level)
                {
                    _bot.SendTextMessageAsync(subscriber.ChatId, message);
                }
            }
        }

        /// <summary>
        /// обработка сообщений
        /// </summary>
        /// <param name="message"></param>
        private async Task ReWorkMessage(Telegram.Bot.Types.Message message)
        {
            switch (message.Text)
            {
                case "/start":

                    CommandEventHandler?.Invoke(this, new CommandArg(CommandsEnum.Start, Config.Load().GetSubscribes(message.Chat.Id)));
                    await _bot.SendTextMessageAsync(message.Chat.Id, $"Запуск стратегии!");
                    
                    break;

                case "/stop":

                    CommandEventHandler?.Invoke(this, new CommandArg(CommandsEnum.Stop));
                    await _bot.SendTextMessageAsync(message.Chat.Id, $"Остановка стратегии!");
                    
                    break;
                case "/info":
                    var config = Config.Load().Subscribers.Where(ss=>ss.ChatId == message.Chat.Id).FirstOrDefault();
                    if (config == null)
                        await _bot.SendTextMessageAsync(message.Chat.Id, $"Установок пока нет для {message.From.FirstName}!");
                    else
                    {
                        await _bot.SendTextMessageAsync(message.Chat.Id, $"{config} для {message.From.FirstName}!");
                    }
                    break;

                case "/level":
                    await KeyboardOnLevel(message.Chat.Id, typeof(SubscribeLevelEnum), "Выбери требуемый уровень", _prefixLevel);
                    break;

                case "/interval":
                    await KeyboardOnLevel(message.Chat.Id, typeof(TimeInterval), "Выбери требуемый интервал", _prefixInterval);
                    break;

                default:

                    if (message.Text.Contains("/pair"))
                    {
                        var pairValue = message.Text.Replace("/pair", "").Trim();
                        if (Config.Load().SetPair(message.Chat.Id, pairValue))
                        {
                            if(string.IsNullOrEmpty(pairValue))
                                await _bot.SendTextMessageAsync(message.Chat.Id, $"Для установки пары наберите /pair value");
                            else
                                await _bot.SendTextMessageAsync(message.Chat.Id, $"Пара - {pairValue}!");
                        }
                        
                    }
                    break;
            }
            Console.WriteLine($"From {message.From.Username} in chatId({message.Chat.Id}): {message.Text}");

        }

        private async Task KeyboardOnLevel(long chatId, Type enumType, string text, string prefix)
        {
            var ikm = new List<InlineKeyboardButton[]>();
            var line = new InlineKeyboardButton[3];
            short iLine = 0;
            var values = Enum.GetValues(enumType);
            foreach (Enum levelEnum in values)
            {
                if(iLine > 2)
                {
                    ikm.Add(line);
                    line = new InlineKeyboardButton[3];
                    iLine = 0;
                }
                line[iLine] = InlineKeyboardButton.WithCallbackData(levelEnum.GetDescription(), prefix + levelEnum.ToString());
                iLine++;
            }
            ikm.Add(line);
            await _bot.SendTextMessageAsync(chatId, text, replyMarkup: new InlineKeyboardMarkup(ikm));
        
        }

        private static bool SetChatLevel(long idChat, SubscribeLevelEnum level)
        {
            var config = Config.Load();
            //if(level == SubscribeLevelEnum.None)
            //{
            //    return config.Remove(idChat);
            //}
            // добавляем или правми строку
            return config.SetOrCreate(idChat, level);
        }

        public static TelegramBotClient GetInstance()
        {
            lock (o)
            {
                if (_bot == null)
                {
                    _bot = new TelegramBotClient(_token); // инициализируем API
                    /* _bot.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
                     {
                         var message = ev.CallbackQuery.Message;
                         var data = ev.CallbackQuery.Data;

                         if (data.Contains(_prefixLevel))
                         {
                             var levelStr = data.Replace(_prefixLevel, "");

                             if (Enum.TryParse<SubscribeLevelEnum>(levelStr, out var level))
                             {
                                 if (SetChatLevel(message.Chat.Id, level))
                                 {
                                     await ((TelegramBotClient)sc).SendTextMessageAsync(message.Chat.Id, $"Левел изменен на {level}!");
                                 }
                             }
                         }
                     };*/
                }
            }
            return _bot;

        }
    }
}
