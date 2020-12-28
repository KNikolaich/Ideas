using System;
using System.Collections.Generic;
using System.Linq;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using Binance.API.Csharp.Client.Models.Market;
using Trader.ORMDataModelCode;
using Trader.Visitor;

namespace Trader.Model
{
    /// <summary>
    /// цепь свечей
    /// </summary>
    public class CandleChain : Queue<Candle>
    {
        #region Fields

        /// <summary> размерность свечей во временном промеждутке. </summary>
        private readonly CandleChainKey _key;

        private Candle _lastCandle; // последняя свечка 

        /// <summary>
        /// Длина цепочки
        /// </summary>
        private readonly int _length = 25;
        private readonly List<Prediction> _predictions;
        List<string> _messagesList = new List<string>();

        #endregion
        
        #region Methods

        public CandleChain(CandleChainKey key)
        {
            _key = key;
            _predictions = new List<Prediction>();
            if (Properties.Settings.Default.DepthQueue > 0)
            {
                _length = Properties.Settings.Default.DepthQueue*2;
            }
        }

        public CandleChain(TimeInterval interval, Nsi_PairCurrency currencyPair) : this(new CandleChainKey(Converters.IntervalToTimespan(interval), currencyPair))
        {
        }

        /// <summary>
        /// Добавление с вымещением
        /// </summary>
        /// <param name="lastCandle"></param>
        private void Add(Candle lastCandle)
        {
            Enqueue(lastCandle);
            if (Count > _length)
            {
                var oldCandle = Dequeue(); // Выбрасываем старую
                foreach (var oldCandlePrediction in oldCandle.Predictions)
                {
                    if (_predictions.Contains(oldCandlePrediction))
                        _predictions.Remove(oldCandlePrediction);
                }
                oldCandle.Destroy();
            }
        }

        /// <summary>
        /// Добавление сразу последовательности, тут надо дебажить, варианты разные бывают
        /// </summary>
        /// <param name="candles"></param>
        public void AddRange(List<Candle> candles)
        {
            var skip = candles.Count > _length ? candles.Count - _length : 0;
            foreach (var candle in candles.Skip(skip))
            {
                Add(candle);
            }
        }

        /// <summary>
        /// собрать со свопов свечи
        /// </summary>
        /// <param name="swaps"></param>
        public void AddCandlesFromSwops(List<Swap> swaps)
        {
            IEnumerable<Swap> actualSwaps = _lastCandle != null 
                ? swaps.Where(swap => swap.CalcTime >= _lastCandle.EndDate) 
                : swaps;

            List<Swap> tempSwaps = new List<Swap>();
            foreach (var swap in actualSwaps.OrderBy(swap => swap.time))
            {
                if (_lastCandle == null)
                {
                    _lastCandle = Candle.CreateFake(swap);
                }
                if (swap.CalcTime < (_lastCandle.EndDate + _key.DeltaTime))
                {
                    tempSwaps.Add(swap);
                }
                else
                {
                    _lastCandle = CreateCandle(tempSwaps);
                    Add(_lastCandle);
                    tempSwaps = new List<Swap>
                    {
                        swap
                    };
                }
            }
        }



        private Candle CreateCandle(List<Swap> tempSwaps)
        {
            var openPrice = tempSwaps.First().price;
            var closePrice = tempSwaps.Last().price;

            decimal minPrice = -1;
            decimal maxPrice = -1;
            foreach (var tempSwap in tempSwaps)
            {
                if (tempSwap.price < minPrice || minPrice == -1)
                {
                    minPrice = tempSwap.price;
                }
                if (tempSwap.price > maxPrice || maxPrice == -1)
                {
                    maxPrice = tempSwap.price;
                }
            }
            var candle = new Candle(OrmDataHelper.GetNewUnitOfWork());
            candle.Init(openPrice, closePrice, minPrice, maxPrice, _lastCandle.EndDate.AddTicks(1), _lastCandle.EndDate.Add(_key.DeltaTime), _lastCandle, _key.PairCurrency);
            return candle;
        }

        /// <summary>
        /// Добавить свечи в цепь
        /// </summary>
        /// <param name="sticks"></param>
        public void AddCandlesFromSticks(List<Candlestick> sticks)
        {
            foreach (var stick in sticks.OrderBy(st=>st.CloseTime))
            {
                if (_lastCandle == null ||
                    _lastCandle.StartDate + _key.DeltaTime <= Converters.GeDateTime(stick.OpenTime))
                {
                    var candle = new Candle(OrmDataHelper.Session);
                    candle.Init(stick.Open, stick.Close, stick.Low, stick.High, Converters.GeDateTime(stick.OpenTime),
                        Converters.GeDateTime(stick.CloseTime), _lastCandle, _key.PairCurrency);
                    _lastCandle = candle;
                    Add(candle);
                }
                else
                {
                    
                }
            }
        }

        /// <summary>
        /// Послать с визитом всех визитеров
        /// </summary>
        internal void Visited()
        {
            foreach (var candle in this.OrderBy(item => item.EndDate))
            {
                var dispatcher = ((IAccepter<Candle>) candle).GetDispatcher();
                candle.Predictions.Load();

                dispatcher.Accept(candle);

                
                // были получены предсказания по 
                if (candle.Predictions.Count() > 0)
                {
                    _predictions.AddRange(candle.Predictions);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Предсказание 
        /// </summary>
        /// <returns></returns>
        internal List<Prediction> Predictions => _predictions;

        /// <summary>
        /// Предсказание 
        /// </summary>
        /// <returns></returns>
        internal List<string> MessagesList
        {
            get
            {
                return _messagesList;
            }
        }

        #endregion
    }

    /// <summary>
    /// Ключ цепи составной, и представляет из себя дельту времени и пару валют
    /// </summary>
    public struct CandleChainKey
    {
        private TimeSpan _deltaTime;
        private readonly Nsi_PairCurrency _pair;

        public CandleChainKey(TimeSpan deltaTime, Nsi_PairCurrency pair)
        {
            _deltaTime = deltaTime;
            _pair = pair;
        }
        /// <summary>
        /// торговая пара
        /// </summary>
        public Nsi_PairCurrency PairCurrency => _pair;

        /// <summary>
        /// дельта времени цепи свечей
        /// </summary>
        public TimeSpan DeltaTime => _deltaTime;

        public override string ToString()
        {
            return $"{_pair} на дельту {_deltaTime.ToString("g")}";
        }
    }
}
