using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Trader.Ancillary;
using Trader.Model;
using Trader.Model.Visitors;
using Trader.ORMDataModelCode;
using Trader.Visitor;

namespace Trader
{
    /// <summary> свечи </summary>

    [DefaultClassOptions, ImageName("Action_Chart_ShowDesigner")]
    [NavigationItem("Bro bot"), XafDisplayName("Свечи")]
    public partial class Candle : IPersistentObject, IAccepter<Candle>
    {
        private CandleDispatcher _dispatcher;

        private StyleCandleEnum _styleColor;
        private KindCandleEnum _kind;
        
        // словарь простых скользящих средних (глубина - значение)
        Dictionary<short, SMAStruct> _dictSMAdepth = new Dictionary<short, SMAStruct>();

#pragma warning disable CS0169 // The field 'Candle._macDStruct' is never used
        private MacDStruct _macDStruct;
#pragma warning restore CS0169 // The field 'Candle._macDStruct' is never used

        /// <summary>
        /// Предельная глубина MA, после которой она считается трендовой
        /// </summary>
        private const int LongDepth = 50;

        public Candle(Session session) : base(session)
        {
        }

        public Candle()
        {
        }



        public override string ToString()
        {
            return $"Свеча {StyleColor} From {OpenPrice} to {ClosePrice}. на {StartDate} ";
        }

        public bool Saving()
        {
            return IsSaving;
        }


        public void Init(decimal openPrice, decimal closePrice, decimal minPrice, decimal maxPrice, DateTime startDate,
            DateTime endDate, Candle previousCandle, Nsi_PairCurrency currency)
        {

            OpenPrice = openPrice;
            ClosePrice = closePrice;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            StartDate = startDate;
            EndDate = endDate;
            PreviousCandle = previousCandle;
            Currency = currency;
            _kind = KindCandleEnum.Undefine;
        }


        public static Candle CreateFake(Swap swap)
        {
            var result = new Candle(XpoDefault.Session);
            result.Init(swap.price, swap.price, swap.price, swap.price, swap.CalcTime, swap.CalcTime, null,
                Nsi_PairCurrency.FindCurrencyOrCreate("btcusdt"));
            return result;
        }

        public static Candle CreateFake(decimal price, string pair)
        {
            DateTime date = DateTime.Now;
            var result = new Candle(XpoDefault.Session);
            result.Init(price, price, price, price, date, date.AddHours(1), null, Nsi_PairCurrency.FindCurrencyOrCreate(pair));
            return result;
        }

        /// <summary> берем диспетчер для визитеров (это же посещаемый класс!) </summary>
        /// <remarks>делать его статическим нельзя, для каждого объекта свой набор визитеров и соответсвенно свой диспетчер</remarks>
        IDispatcher<Candle> IAccepter<Candle>.GetDispatcher()
        {
            return _dispatcher ?? (_dispatcher = new CandleDispatcher());
        }

        /// <summary> разрушение свечи </summary>
        public void Destroy()
        {
            if (_dispatcher != null)
            {
                _dispatcher.Destroy();
            }
            _dispatcher = null;
            //PreviousCandle = null;
            Currency = null;
            //Session = null;
            //Predictions = null;
        }
        //#endregion

        #region Служебные | вычисляемые свойства
            
        [NonPersistent]
        public decimal AvgPrice
        {
            get
            {
                var body = ClosePrice - OpenPrice;

                if (body > 0)
                {
                    return OpenPrice + body / 2;
                }
                if (body <= 0)
                {
                    return ClosePrice - body / 2; // тут ClosePrice < OpenPrice
                }
                //if (body == 0)
                return OpenPrice; // а сюда мы вообще никогда не дйдем )
            }
        }

        /// <summary>
        /// Стиль свечи медвежья или бычья
        /// </summary>
        /// <value></value>
        [NonPersistent]
        public StyleCandleEnum StyleColor
        {
            get
            {
                if (_styleColor == StyleCandleEnum.Dogi)
                {
                    if (OpenPrice < ClosePrice)
                    {
                        _styleColor = StyleCandleEnum.Bovine;
                    }
                    else
                    {
                        _styleColor = OpenPrice > ClosePrice
                            ? StyleCandleEnum.Bear
                            : StyleCandleEnum.Dogi;
                    }
                }
                return _styleColor;
            }
        }

        /// <summary>
        /// Разновидность свечи (её род/сорт...). Если подходит под какой либо сорт сигнала
        /// </summary>
        /// <value></value>
        [NonPersistent]
        public KindCandleEnum Kind
        {
            get
            {
                if (_kind == KindCandleEnum.Undefine)
                {
                    if (HasSymptomHammer())
                        _kind = KindCandleEnum.Hammer;

                    if (HasSymptomHanged())
                        _kind = KindCandleEnum.Hanged;

                    _kind = KindCandleEnum.Undefine;
                }
                return _kind;
            }
        }

        /// <summary>
        /// Калькулируемое свойство для хранения индикатора MacD
        /// </summary>
        [NonPersistent]
        public MacDStruct MacD { get; set; }


        /// <summary>
        /// Калькулируемое свойство для хранения индикатора Rsi
        /// </summary>
        [NonPersistent]
        public short RsiValue { get; set; }

        /// <summary>
        /// свойство для хранения стохастика
        /// </summary>
        [NonPersistent]
        public StochAssistant Stoch { get; set; }

        #endregion

        #region Методы вычисления

        /// <summary>
        /// симптомы "повешенный"
        /// </summary>
        /// <returns>тело свечи все вверху и минимум в 2 раза меньше тени внизу. цвет не важен. сам повешенный вверху графа</returns>
        private bool HasSymptomHanged()
        {
            var isBovine = StyleColor == StyleCandleEnum.Bovine;
            if (HangedOrHatchet(isBovine))
            {
                // тут как то надо определенить что было до этого, восхождение или нисхождение
                if (PreviousCandle.AvgPrice < AvgPrice)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// симптомы топора
        /// </summary>
        /// <returns>тело свечи все вверху и минимум в 2 раза меньше тени внизу. цвет не важен. сам топор внизу графа</returns>
        private bool HasSymptomHammer()
        {

            var isBovine = StyleColor == StyleCandleEnum.Bovine;
            if (HangedOrHatchet(isBovine))
            {
                // тут как то надо определенить что было до этого, восхождение или нисхождение

                if (PreviousCandle.AvgPrice > AvgPrice)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HangedOrHatchet(bool isBovine)
        {

            var delta = MaxPrice - MinPrice;
            var shadowTop = MaxPrice - (isBovine ? ClosePrice : OpenPrice);
            if (delta == 0) // дожи
            {
                return false;
            }
            var percentShadowTop = shadowTop * 100 / delta; // процент тени вверху 

            if (percentShadowTop > 3) //прикидываем, если верхняя тень больше 3% от всей свечи, - это не наш случай
            {
                return false;
            }

            var body = isBovine ? ClosePrice - OpenPrice : OpenPrice - ClosePrice;

            var shadowButtom = isBovine ? OpenPrice - MinPrice : ClosePrice - MinPrice;

            return shadowButtom != 0 && body / shadowButtom >= 2;
        }

        /// <summary>
        /// берем значение Ema
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public decimal Ema(short period)
        {
            decimal summ = 0;
            decimal alfa = 2m / (period + 1m);
            decimal prevEma;
            if (PreviousCandle != null && PreviousCandle.MacD.Ema.ContainsKey(period))
            {
                prevEma = PreviousCandle.MacD.Ema[period];
            }
            else
            {
                var currCundle = this;
                for (int i = 0; i < period; i++)
                {
                    summ += currCundle.ClosePrice;
                    currCundle = currCundle.PreviousCandle;
                    if (currCundle == null)
                    {
                        //AddMessage($"для расчета SMO({movingAverage.Depth}) недостаточно свечей!");
                        break;
                    }
                }
                prevEma = summ / period;
            }
            decimal emaPeriod = alfa * ClosePrice + (1m - alfa) * prevEma;
            return emaPeriod;
        }

        #endregion



        /// <summary>
        /// Собираем сообщения для SMA
        /// </summary>
        /// <param name="createPredicts">Создавать предсказания</param>
        /// <returns></returns>
        public string GetMessageBySMA(bool createPredicts)
        {
            // рассматриваем отношения скользящих
            string message = null;

            if (PreviousCandle == null || PreviousCandle._dictSMAdepth.Keys.Count(vk => vk < LongDepth) != 2)
            {
                //AddMessage($"Последняя свеча в цепи или для какой то из средних предыдещей свечи невозможно расчитать значение!");
            }
            else
            {
                //DictSMAdepth.Keys.Count(vk => vk < 50) < 2
                if (_dictSMAdepth.Keys.Count(vk => vk < LongDepth) == 2)
                {
                    var delta = GetDeltaMa();
                    var prevDelta = PreviousCandle.GetDeltaMa();

                    if (delta > 0 && prevDelta < 0)
                    {
                        CreatePrediction("покупай", _dictSMAdepth[_dictSMAdepth.Keys.Min()].Volume, "Пересечение MA нуля");
                        message = "buy";
                    }
                    else if (delta < 0 && prevDelta > 0)
                    {
                        CreatePrediction("продавай", _dictSMAdepth[_dictSMAdepth.Keys.Min()].Volume, "Пересечение MA нуля");
                        message = "sell";
                    }
                    else
                    {
                        var dAbs = Math.Abs(delta);
                        var pdAbs = Math.Abs(prevDelta);
                        if (delta > 0)
                        {
                            message = "Тренд восходящий. ";
                        }
                        else
                        {
                            message = "Тренд нисходящий. ";
                        }

                        if (dAbs > pdAbs)
                        {
                            message += $"Кривые разошлись на {(100 - pdAbs * 100 / dAbs).ToString("N2")}%";
                        }
                        else if (dAbs < pdAbs)
                        {
                            message += ($"Кривые сошлись на {(100 - dAbs * 100 / pdAbs).ToString("N2")}%");
                        }
                    }
                }
                else
                {
                    message = $"расчет средних провален!";
                }
            }
            return message;
        }


        public decimal Sma(short depth)
        {
            decimal[] values = new decimal[depth];

            var currCundle = this;
            for (int i = 0; i < depth; i++)
            {
                values[i] = currCundle.ClosePrice;
                currCundle = currCundle.PreviousCandle;
                if (currCundle == null)
                {
                    //AddMessage($"для расчета SMO({movingAverage.Depth}) недостаточно свечей!");
                    return 0;
                }
            }
            SMAStruct smaStruct = SMAStruct.Calc(values);
            AddMaInDict(smaStruct);
            return smaStruct.Volume;
        }

        private decimal GetDeltaMa()
        {
            decimal smallMa = _dictSMAdepth[_dictSMAdepth.Keys.Min()].Volume;
            decimal largeMa = _dictSMAdepth[_dictSMAdepth.Keys.Max()].Volume;
            var delta = smallMa - largeMa;
            return delta;
        }


        /// <summary> Создаем предсказание </summary>
        /// <param name="conclusion"></param>
        /// <param name="volume"></param>
        /// <param name="interpretation"></param>
        /// <returns></returns>
        public void CreatePrediction(string conclusion, decimal volume, string interpretation)
        {
            var prediction = new Prediction(Session)
            {

                Volume = volume,
                AvgProbability = 50,
                Candle = this,
                
                Interpretation = interpretation,
                Conclusion = conclusion
            };
            Predictions.Add(prediction);
        }

        public void AddMaInDict(SMAStruct smaStruct)
        {
            if (_dictSMAdepth.ContainsKey(smaStruct.Depth))
            {
                var formattableString = $"В БД содержится более одной записи SMO({smaStruct.Depth})!";
                //AddMessage(formattableString);
            }
            else
            {
                _dictSMAdepth.Add(smaStruct.Depth, smaStruct);
            }
        }

        /// <summary>
        /// Возможно углубиться 
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public bool CanBeDeeper(short depth)
        {
            var currCandle = this;
            for (short i = 0; i < depth; i++)
            {
                currCandle = currCandle.PreviousCandle;
                if (currCandle == null)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// просто берем sma если оно есть
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public decimal? GetSma(short depth)
        {
            if (_dictSMAdepth.ContainsKey(depth))
            {
                return _dictSMAdepth[depth].Volume;
            }
            return null;
        }
        
    }
}
