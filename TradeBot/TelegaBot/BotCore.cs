using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

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
                        if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                        {
                            try
                            {
                                await ReWorkMessage(update.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            offset = update.Id + 1;

                        }
                        else if(update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
                        {
                            var data = update.CallbackQuery.Data;
                            var message = update.CallbackQuery.Message;
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
                    if(SetChatLevel(message.Chat.Id, SubscribeLevelEnum.Warning))

                        await _bot.SendTextMessageAsync(message.Chat.Id, $"Приветствую тебя, {message.From.FirstName}!");
                    break;

                case "/stop":
                    if(SetChatLevel(message.Chat.Id, SubscribeLevelEnum.None))
                        await _bot.SendTextMessageAsync(message.Chat.Id, $"Пока, дружище, {message.From.FirstName}!");
                    
                    break;

                case "/level":
                    await KeyboardOnLevel(message.Chat.Id);
                    break;
                default:

                    if (message.Text.Contains("/level_"))
                    {
                        if(SetChatLevel(message.Chat.Id, SubscribeLevelEnum.Debug))
                            await _bot.SendTextMessageAsync(message.Chat.Id, $"Левел, {message.From.FirstName}!");
                        
                    }
                    break;
            }
            Console.WriteLine($"From {message.From.Username} in chatId({message.Chat.Id}): {message.Text}");

        }

        private async Task KeyboardOnLevel(long chatId)
        {
            var text = "Выбери требуемый уровень";
            var ikm = new List<InlineKeyboardButton>();
            foreach (SubscribeLevelEnum levelEnum in Enum.GetValues(typeof(SubscribeLevelEnum)))
            {
                ikm.Add(InlineKeyboardButton.WithCallbackData(levelEnum.ToString(), _prefixLevel + levelEnum.ToString()));
            }

            await _bot.SendTextMessageAsync(chatId, text, replyMarkup: new InlineKeyboardMarkup(ikm));
        
        }

        private static bool SetChatLevel(long idChat, SubscribeLevelEnum level)
        {
            var config = Config.Load();
            if(level == SubscribeLevelEnum.None)
            {
                return config.Remove(idChat);
            }
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
