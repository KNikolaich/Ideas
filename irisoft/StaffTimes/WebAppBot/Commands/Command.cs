using Telegram.Bot;
using Telegram.Bot.Types;
using WebAppBot.Models;

namespace WebAppBot.Commands
{
    public abstract class Command
    {

        public abstract string Name { get; }

        public abstract void Execute(Message messagee, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);
        }
    }
}