﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCore
{
    /// <summary>
    /// Основа бота
    /// </summary>
    public class Sender
    {
        static string _token = "882717145:"; // smartTrade_kf
        private bool _iAmBusy;
        static TelegramBotClient _bot;
        static object o = new object();

        Queue<KeyValuePair<long, string>> _messageCach = new Queue<KeyValuePair<long, string>>();

        public Sender()
        {
            var arrFromToken = _token.Split(':');
            Console.WriteLine("токен:" + arrFromToken[0]);
            if (string.IsNullOrEmpty(arrFromToken[1]))
                Console.WriteLine("Спроси токен у фазера");
            Task.Factory.StartNew(() => ReadChatsAsync());
        }

        public void SendMessage(string message, SubscribeLevelEnum level = SubscribeLevelEnum.Info)
        {
            foreach (var subscriber in Config.Load().Subscribers)
            {
                if (subscriber.Level >= level)
                {
                    _messageCach.Enqueue(new KeyValuePair<long, string>(subscriber.ChatId, message));
                    if(DateTime.Now.TimeOfDay < new TimeSpan(23, 0, 0) && DateTime.Now.TimeOfDay >= new TimeSpan(8, 0, 0))
                    {
                        while(_messageCach.Count > 0)
                        {
                            var kvp = _messageCach.Dequeue();
                            _bot.SendTextMessageAsync(kvp.Key, kvp.Value);
                        }
                    }
                }
            }
        }

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
                            offset = update.Id + 1;                        
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

        private async Task ReworkCallbackQuery(CallbackQuery callbackQuery)
        {
            await Command.ReworkCallbackQuery(callbackQuery);
            Console.WriteLine($"{DateTime.Now.ToString("G")}:\t From {callbackQuery.Message.From.Username} in chatId({callbackQuery.Message.Chat.Id}): {callbackQuery.Message.Text}");
            
        }

        /// <summary>
        /// обработка сообщений
        /// </summary>
        /// <param name="message"></param>
        private async Task ReWorkMessage(Telegram.Bot.Types.Message message)
        {
            await Command.GetRequest(message);
            Console.WriteLine($"{DateTime.Now.ToString("G")}:\t From {message.From.Username} in chatId({message.Chat.Id}): {message.Text}");
        }


        public static TelegramBotClient GetInstance()
        {
            lock (o)
            {
                if (_bot == null)
                    _bot = new TelegramBotClient(_token); // инициализируем API
                return _bot;
            }
        }

    }
}
