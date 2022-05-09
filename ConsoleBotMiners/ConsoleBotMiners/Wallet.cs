using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBotMiners
{
    public class Wallet
    {
        /// <summary>
        /// номер кошелька, его же идентификатор
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Предел добычи.
        /// </summary>
        public float Limit { get; set; }


        /// <summary>
        /// дата начала майнинга (в тиках)
        /// </summary>
        public long? MiningStartTicks { get; set; }

    }
}
