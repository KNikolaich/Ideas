using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebAppBot.Commands
{
    public class HelloCommand: Command
    {
        public override string Name => "Hello";
        public override async void Execute(Message messagee, TelegramBotClient client)
        {
            var chatId = messagee.Chat.Id;
            var messageId = messagee.MessageId;

            // TODO тут полезный код 

            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
}