using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

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
                        if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                        {
                            try
                            {
                                ReWorkMessage(update.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
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

        /// <summary>
        /// обработка сообщений
        /// </summary>
        /// <param name="message"></param>
        private void ReWorkMessage(Telegram.Bot.Types.Message message)
        {
            switch (message.Text)
            {
                case "/start":
                    if(SetChatLevel(message.Chat.Id, SubscribeLevelEnum.Warning))

                        _bot.SendTextMessageAsync(message.Chat.Id, $"Приветствую тебя, {message.From.FirstName}!");
                    break;

                case "/stop":
                    if(SetChatLevel(message.Chat.Id, SubscribeLevelEnum.None))
                        _bot.SendTextMessageAsync(message.Chat.Id, $"Пока, дружище, {message.From.FirstName}!");
                    
                    break;
                default:

                    if (message.Text.Contains("/level"))
                    {
                        if(SetChatLevel(message.Chat.Id, SubscribeLevelEnum.Debug))
                            _bot.SendTextMessageAsync(message.Chat.Id, $"Левел, {message.From.FirstName}!");
                        
                    }
                    break;
            }
            Console.WriteLine($"From {message.From.Username} in chatId({message.Chat.Id}): {message.Text}");

        }

        private bool SetChatLevel(long idChat, SubscribeLevelEnum level)
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
                if(_bot == null)
                    _bot = new TelegramBotClient(_token); // инициализируем API
                return _bot;
            }
        }
    }
}
