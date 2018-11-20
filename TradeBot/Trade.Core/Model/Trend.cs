using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.LiveCoin;

namespace Trader.Model
{
    /// <summary>
    /// Тренд (может быть восходящим, нисходящим, ровным.)
    /// </summary>
    /// <remarks>выражается углом наклона (крутизной) и продолжительностью (глубиной)
    /// крутизна в градусах. от +90 до -90. 
    /// продолжительность в единицах. 5, 10, 15, 20, 50 свечей
    /// </remarks>
    public class Trend
    {
        private double DeltaGradus = 15; // Это то изменение градуса кривой, при котором считаем тренд измененным
        private TrendTimeEnum _tte;
        private double _angle;

        public Trend(Candle candleStart)
        {
            InitTrand(candleStart);
        }

        /// <summary> угол </summary>
        public double Angle
        {
            get { return _angle; }
        }



        private void InitTrand(Candle candleStart)
        {
            TrendTimeEnum tempTrend = TrendTimeEnum.Undefine;
            _angle = 0;
            do
            {
                _tte = tempTrend;

                tempTrend++;
                
                var tempAngleTrend = CalcAngleTrend(candleStart, tempTrend);
                if (_angle == 0)
                {
                    _angle = tempAngleTrend;
                }
                else if(ChangeTrandBiggistDelta(_angle, tempAngleTrend))
                {

                }

            } while (tempTrend != _tte);
        }

        /// <summary>
        /// Тренд сменился больше чем на дельту
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="tempAngleTrend"></param>
        /// <returns></returns>
        private bool ChangeTrandBiggistDelta(double angle, double tempAngleTrend)
        {
            return Math.Abs(angle - tempAngleTrend) > DeltaGradus;
        }

        /// <summary>
        /// Вычисляем угол тренда для заданных точек свечей
        /// </summary>
        /// <param name="candleLast"></param>
        /// <param name="tempTrend"></param>
        /// <returns>угол наклона</returns>
        private double CalcAngleTrend(Candle candleLast, TrendTimeEnum tempTrend)
        {
            // перем две свечи из коллекции, первую и последнюю, - вычисляем наклон с их координат
            var tTrand = (int) tempTrend;
            var primaryCandle = candleLast;
            int iterator = 0;
            while (primaryCandle.PreviousCandle != null && iterator <= tTrand)
            {
                iterator++;
                primaryCandle = primaryCandle.PreviousCandle;
            }
            if (iterator == 0)
            {
                return -180; // ошибка, - единственная свеча, - тренд не вычислимый
            }
            return Math.Atan2(((double)primaryCandle.AvgPrice - (double)candleLast.AvgPrice), iterator) * (180 / Math.PI);
        }
    }

    public enum TrendTimeEnum
    {
        Undefine = 0,
        VeryFast = 5,
        Fast = 10,
        Norm = 15,
        Long = 25,
        VeryLong = 50
    }
}
