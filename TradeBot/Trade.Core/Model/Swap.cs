using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Trader.LiveCoin;

namespace Trader.Model
{
    /// <summary>
    /// сделка
    /// </summary>
    [DataContract]
    public class Swap
    {
        private DateTime? _calcTime;

        [DataMember]
        public Double time { get; set; } // Unix Time. Время в нашем API представлено как количество миллисекунд(или секунд, умноженных на тысячу), прошедших с 00:00:00 UTC 1 января 1970 года.

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public decimal price { get; set; }

        [DataMember]
        public decimal quantity { get; set; }

        [DataMember]
        public StyleTickedEnum type { get; set; }

        /// <summary>
        /// Вычисленное из time время 
        /// </summary>
        public DateTime CalcTime {
            get
            {
                if (!_calcTime.HasValue)
                {
                    var dateTimeIntoUtc = new DateTime(1970, 01, 01).AddSeconds(time);
                    _calcTime = TimeZoneInfo.ConvertTimeFromUtc(dateTimeIntoUtc, TimeZoneInfo.Local);
                }
                return _calcTime.Value;
            } 
        }


        public override string ToString()
        {
            return $"{type} кол-во:{quantity} цена:{price} время:{time}";
        }

        //"time": 1409935047,
    //"id": 99451,
    //"price": 350,
    //"quantity": 2.85714285,
    //"type": "BUY"
    }
}
