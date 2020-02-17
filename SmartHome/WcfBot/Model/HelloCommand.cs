using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WcfBot.Model
{
    public class HelloCommand : Command
    {
        public override string Name => "Hello";
        public override async void Execute(Message messagee, TelegramBotClient client)
        {
            var chatId = messagee.chat.id;
            var messageId = messagee.message_id;

            // TODO тут полезный код 

            await client.SendTextMessageAsync(chatId, "Hello!");
        }
    }
}