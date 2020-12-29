using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticalCenter.Helpers
{
    /// <summary>
    /// Докладчик
    /// </summary>
    public class Speaker
    {

        static Speaker _speaker;

        private Speaker()
        {

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

                // событие "это может быть интересно"
        public EventHandler<MessageEventArg> CanBeInteresting;

        public void Dispose()
        {
            CanBeInteresting = null;
        }

        public void OnCanBeInteresting(object reciept, string msg)
        {
            CanBeInteresting?.Invoke(reciept, new MessageEventArg(msg));
        }
    }

    public class MessageEventArg : EventArgs
    {
        public MessageEventArg(string msg)
        {
            Message = msg;
        }
        public string Message { get; private set; }
    }
}
