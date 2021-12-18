using System;
using System.Collections.Generic;
using System.Linq;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using DbWorkerAndML.Model;

namespace DbWorkerAndML.Db
{
    public class Candlestick
    {
        private Candlestick _previewStick;

        public int Id { get; set; }
        public string Symbol { get; set; }
        public string TimeInterval { get; set; }
        public long OpenTime { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public long CloseTime { get; set; }

        public int? Advice { get; set; }
        public decimal? AngleSMAShort { get; set; }

        public decimal? AngleSMAAvg { get; set; }

        public decimal? AngleSMALong { get; set; }
        /// <summary>
        /// Экспоненциальные средние
        /// </summary>
        public decimal? SmaShort { get; set; }
        public decimal? SmaAvg { get; set; }
        public decimal? SmaLong { get; set; }
        /// <summary>
        /// Это макДи
        /// </summary>
        public decimal? RsiVolume { get; set; }

        public short? RsiAcrossZero { get; set; }

        public override string ToString()
        {
            return Converters.GeDateTime(CloseTime).ToString("g") + " по прайсу закрытия " + Close;
        }

        public static Candlestick CreateFromStick(Binance.API.Csharp.Client.Models.Market.Candlestick stick, string symbol, TimeInterval timeInterval)
        {
            return new Candlestick
            {
                Advice = 0,
                Symbol = symbol,
                TimeInterval = timeInterval.ToString(),
                Close = stick.Close,
                Open = stick.Open,
                CloseTime = stick.CloseTime,
                High = stick.High,
                Low = stick.Low,
                OpenTime = stick.OpenTime,
                Volume = stick.Volume
            };
        }

        public Binance.API.Csharp.Client.Models.Market.Candlestick MapToStick()
        {
            return new Binance.API.Csharp.Client.Models.Market.Candlestick
            {
                Close = Close,
                Open = Open,
                CloseTime = CloseTime,
                High = High,
                Low = Low,
                OpenTime = OpenTime,
                Volume = Volume,
                
            };
        }

        public void SetPrevCandle(Candlestick candlestick)
        {
            Advice = 0;
            _previewStick = candlestick;
            // Расчитываем быструю SMA на грубину 7
            SmaShort = GetSma(7);
            AngleSMAShort = SmaShort - _previewStick?.SmaShort;

            // Расчитываем среднюю SMA на грубину 25
            SmaAvg = GetSma(25);
            AngleSMAAvg = SmaAvg - _previewStick?.SmaAvg;

            // Расчитываем трендовую SMA на грубину 99
            SmaLong = GetSma( 99);
            AngleSMALong = SmaLong - _previewStick?.SmaLong;

            RsiVolume = SmaShort - SmaAvg;

            RsiAcrossZero = CalcAcross();
        }

        /// <summary>  если знак сменился с + на - записываем RSIAcrossZero  = AdviceEnum.sell если  с - на + = AdviceEnum.buy.
        /// иначе = 0  </summary>
        /// <returns></returns>
        private short? CalcAcross()
        {
            short? res = 0;
            if (RsiVolume <= 0 && _previewStick.RsiVolume >= 0) // переход от подъема к падению (продавайте)
                res = (short)AdviceEnum.Sell; 
            else if (RsiVolume >= 0 && _previewStick.RsiVolume <= 0) // переход от падения к подъему (покупайте)
                res = (short)AdviceEnum.Buy;
            return res;
        }

        private decimal GetEma(Candlestick candlestick, int valumeDeep, decimal? previewStickValue)
        {
            var p = (2m) / (valumeDeep + 1);
            return (candlestick.Close * p) + (previewStickValue != null ? (previewStickValue.Value * (1 - p)) : 0);
            //return Value;
        }

        private decimal GetSma(int valumeDeep)
        {
            int i = 1;
            var currentStick = this;
            decimal summer = currentStick.Close;
            for (; i < valumeDeep; i++)
            {
                if (currentStick?._previewStick == null)
                {
                    break;
                }

                summer += currentStick._previewStick.Close;
                currentStick = currentStick._previewStick;
            }

            var sma = summer / i;
            return sma;
        }

        public Tuple<Candlestick, int> FindExtremumCandle()
        {
            if (RsiAcrossZero.HasValue && RsiAcrossZero != 0)
            {
                var candle = _previewStick;
                var candles = new List<Candlestick>();
                do
                {
                    candles.Add(candle);
                    candle = candle._previewStick;
                } while (candle._previewStick != null && candle._previewStick.Advice == 0/* && candle._previewStick.RsiAcrossZero == 0*/);

                decimal findingPrice = 0;
                if (RsiAcrossZero == (short) AdviceEnum.Buy)
                    findingPrice = candles.Min(c => c.Close);

                if (RsiAcrossZero == (short)AdviceEnum.Sell)
                    findingPrice = candles.Max(c => c.Close);

                return new Tuple<Candlestick, int>(candles.First(c => c.Close == findingPrice), RsiAcrossZero.Value);
            }

            Advice = 0;
            return null;
        }

        public void MarkCandlesBeforeExtremum(int actossZero)
        {
            var currentCandle = this;
            var valueAdvice = 100;
            // currentCandle.Advice = actossZero * valueAdvice;
            do
            {
                currentCandle.Advice = actossZero * valueAdvice;
                currentCandle = currentCandle._previewStick;
                valueAdvice -= 20;
            } while (currentCandle != null && valueAdvice > 0 && currentCandle.Advice == 0);
        }
    }
}
