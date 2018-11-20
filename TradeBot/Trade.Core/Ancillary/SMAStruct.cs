using System.Linq;
using Binance.API.Csharp.Client.Models.WebSocket;

namespace Trader.Ancillary
{
    /// <summary>
    /// SMA
    /// </summary>
    public struct SMAStruct
    {
        private SMAStruct(short depth, decimal value)
        {
            Depth = depth;
            Volume = value;
        }

        /// <summary>
        /// Глубина
        /// </summary>
        public short Depth { get; set; }

        /// <summary>
        /// значение средней
        /// </summary>
        public decimal Volume { get; set; }

        public override string ToString()
        {
            return $"Значение SMA({Depth}): {Volume:G7}";
        }

        public static SMAStruct Calc(decimal[] values)
        {
            decimal summ = 0;
            for (int i = 0; i < values.Length; i++)
            {
                summ += values[i];
            }
            var average = summ / values.Length;
            return new SMAStruct((short)values.Length, average);
        }

        public static SMAStruct Calc(int[] ints)
        {
            var decimals = ints.Select(s=>(decimal)s).ToArray();
            return Calc(decimals);
        }
    }
}