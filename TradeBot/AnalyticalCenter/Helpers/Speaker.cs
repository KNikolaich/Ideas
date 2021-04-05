using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegaBot;

namespace AnalyticalCenter.Helpers
{
    /// <summary>
    /// Докладчик
    /// </summary>
    public class Speaker
    {

        static Speaker _speaker;
        // событие "это может быть интересно"
        public EventHandler<MessageEventArg> CanBeInteresting;

        public event EventHandler<CommandArg> CommandEventHandler
        {
            add { _bot.CommandEventHandler += value; }
            remove { _bot.CommandEventHandler -= value; }
        }
        private BotCore _bot;
        
        private Speaker()
        {
            _bot = new BotCore();
            Task.Factory.StartNew(() => _bot.ReadChatsAsync());
        }

        /// <summary>
        /// Берем единственную сущность
        /// </summary>
        /// <returns></returns>
        public static Speaker Instance()
        {
            if(_speaker == null)
            {
                _speaker = new Speaker();
            }
            return _speaker;
        }


        public void Dispose()
        {
            CanBeInteresting = null;
        }

        public void OnCanBeInteresting(object reciept, MessageEventArg msg)
        {
            _bot.SendMsg(msg.Level, msg.Message);
            CanBeInteresting?.Invoke(reciept, msg);
        }
    }

    public class MessageEventArg : EventArgs
    {
        public MessageEventArg(string msg, TelegaBot.SubscribeLevelEnum level)
        {
            Level = level;
            Message = msg;
        }
        public string Message { get; private set; }
        public TelegaBot.SubscribeLevelEnum Level { get; private set; }
    }
}
