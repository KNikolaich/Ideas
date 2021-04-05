using AnalyticalCenter.Helpers;
using Binance.API.Csharp.Client.Models.Helpers;
using Binance.API.Csharp.Client.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelegaBot;

/*Для расчетна нам понадобится минимум 26 значений цен закрытия для периода
 * вычисляем ema медленную и быструю
 * находим дельту между ними 
 * Находим среднюю сглаженную от n таких сигналов macD (для этого необходимо собрать Sma всех предыдущих MacD)
 * 
 * (пересечение дельты линии нуля, является входа в рынок 
 * 
 * гистограмма пересекает зеро (сверху вниз -> продажа, снизу вверх -> покупка)
 * Вычисление скользящей средней дает нам предупреждение при пересечении с гистрограммой
 * Например, в случае, если линия MACD пересекает скользящую снизу вверх, находясь ниже нулевого значения, это можно считать предвестником её пересечения нулевой линии, то есть сигналом на покупку.
 * 
 * Самым сильным сигналом являются дивергенция (расхождение двух EMA) и Ковергенция (их сближение)
 * 
*/

namespace AnalyticalCenter.Indicators
{
    /// <summary>
    /// Индикатор MacD
    /// </summary>
    /// <remarks>Стандартными настройками, в случае ведения торговли на понижение, для MACD являются периоды 
    /// 26 для медленной, 12 для быстрой и 9 для сигнальной скользящей средней, 
    /// при этом ценой для расчета служит значение закрытия свечи.
    /// При ведении торговли на рост рынка параметры 26 и 12 заменяются на 17 и 8 соответственно.
    /// его стандартные значения 12, 26, 9 изначально разрабатывались именно под дневной таймфрейм.</remarks>
    public class MacD : IIndicator
    {
        
        internal MacD _previewMacD;

        internal MacD()
        {
        }

        public decimal CalcThis(decimal price, IIndicator preview)
        {
            _previewMacD = (MacD)preview;

            Delta = ema12.CalcThis(price, _previewMacD?.ema12) - Ema26.CalcThis(price, _previewMacD?.Ema26);

            Difference = Delta - sma9.CalcThis(0m, this);
            
            return Difference;
        }


        // быстрая скользящая средняя
        Ema ema12 = new Ema(12);

        // медленная скользящая средняя
        Ema ema26 = new Ema(26);

        // сигнальная скользящая 
        Sma sma9 = new Sma(9);

        /// <summary>
        /// разница между двумя скользящими
        /// </summary>
        public decimal Delta { get; private set; }
        public DateTime OpenDateTime { get; private set; }
        public decimal Difference { get; private set; }

        public decimal Value => Delta;

        public int Depth => 26; // максимальная глубина

        public IIndicator PreviewIndicator => _previewMacD;

        public Ema Ema26 => ema26;

        public override string ToString()
        {
            return $"delta:{Delta:n2} {sma9.Value:n2} {OpenDateTime.ToLongDateString()}";
        }

        internal static MacD Create(Candlestick stick, IIndicator prevMacD)
        {
            var macd = new MacD();

            try
            {
                macd.CalcThis(stick.Close, prevMacD);
                macd.OpenDateTime = Converters.GeDateTime(stick.OpenTime);
            }
            catch (Exception ex)
            {
                Speaker.Instance().CanBeInteresting(macd, new MessageEventArg(ex.Message, SubscribeLevelEnum.Error));
            }
            return macd;
        }

        public EnumOrderDirect Validate()
        {
            if (_previewMacD != null)
            {
                if (_previewMacD.Difference <= 0 && Difference > 0)
                {
                    //OnCanBeInteresting("Рекомендация: покупать.", newMacd);

                    return EnumOrderDirect.Buy; // покупай 1 валюту из пары 
                }
                if (_previewMacD.Difference >= 0 && Difference < 0)
                {
                    //OnCanBeInteresting("Рекомендация: продавать.", newMacd);
                    // при общем восходящем тренде - ходл (при этом надо стоп лосы уметь ставить)
                    return  EnumOrderDirect.Sale;  // продавай 1 валюту из пары 
                }
            }
            return EnumOrderDirect.Nothing;
        }
    }
}
