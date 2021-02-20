using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BotCore;

namespace ConsoleBotMiners
{
    /// <summary>
    /// Монитор майнеров
    /// </summary>
    class MinersMonitor
    {
        private Sender _senderBot;

        public MinersMonitor()
        {
            _senderBot = new Sender();
            // инициализируем пулридер
        }

        /// <summary> Проверка пулов </summary>
        public void VelidatePools()
        {
            //throw new NotImplementedException();
        }
    }
}
