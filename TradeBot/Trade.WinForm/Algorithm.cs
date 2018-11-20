using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using WindowsFormApp.Properties;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using Trader;
using Trader.Ancillary;
using Trader.LiveCoin;
using Trader.Model;
using Timer = System.Timers.Timer;

namespace WindowsFormApp
{
    public class Algorithm
    {
        private static bool _stopAll;
        int _totalTail = 1000;
        readonly Timer _timer = new Timer();
        readonly Timer _fastTimer = new Timer();
        private DateTime _stopDate;
        private readonly Market _market;
        private bool _busyTimer;
        private DateTime _startDateStep;
        private int _fastCounter;


        public Algorithm(Market market)
        {
            short delayTime = 2; // в секундах задержка

            _timer.Interval = delayTime * 1000;
            _market = market;
            _timer.Elapsed += _timer_Elapsed;

            _fastTimer.Interval = 1000;
            _fastTimer.Elapsed += _fastTimer_Elapsed;
        }

        private void _fastTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LogHolder.ProgressInfo(null, _fastCounter++, "приступим...", _totalTail);
        }


        /// <summary> Самый простой алгорим. две SMA пересекаются, в точке их пересечения производится купля/продажа </summary>
        public void AlgorithmNumberOne(bool bExitAfterNow)
        {
            _stopAll = false;
            // делим прогреccбар на 1000 кусочков
            LogHolder.ProgressInfo(null, 0, "приступим...", _totalTail);
            _stopDate = UpdataStopDate(Settings.Default);
            
            _startDateStep = Settings.Default.StartDate;
            
            _timer.Start();
        }
        
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_stopAll)
            {
                _timer.Stop();
            }
            else if (!_busyTimer)
            {
                Tick(_market, _totalTail).Wait();
            }
        }


        private async Task Tick(Market market, int totalTail)
        {
            _busyTimer = true;
            
            var sttng = Settings.Default;

            var pairCurr = sttng.PairCurrency;
            
            var timeInterval = sttng.TimeInterval;
            var limit = sttng.DepthQueue - 2;


            var intervalBeforeNow = IntervalBeforeNow(timeInterval, limit);
            
            _stopDate = UpdataStopDate(sttng);

            var delaySpan = Converters.IntervalToTimespan(timeInterval);

            if (_startDateStep + intervalBeforeNow < _stopDate)
            {
                _startDateStep += intervalBeforeNow; // движемся к цели скачками, а не по кадрам
            }
            else if (_startDateStep +delaySpan < DateTime.Now)
            {
                // при покадрогом движении, пересчитываем стоп дату, потому что значит мы приближаемся нам нужна актуальная дата окончания
                _startDateStep = _startDateStep + delaySpan; // прибавляем 5 минут к старому запросу (не универсально, но подходит для вариантов с timeInterval > 5 минут)

            }

            // число прошедших секунд в относительной величине, относительно нашего прогрессбара
            var totalSecondCurr = (int)((_startDateStep - Settings.Default.StartDate).TotalSeconds * totalTail /
                                            (_stopDate - Settings.Default.StartDate - delaySpan).TotalSeconds);

            var currDate = $"{_startDateStep.ToString("MMMM dd (HH:mm)")}";
            LogHolder.TraceLogInfo(currDate);
            LogHolder.ProgressInfo(null, totalSecondCurr, currDate, totalTail);


            // если перешагнули за предел начальной даты, - пропускаем итерацию, ждем ещё
            if (_startDateStep < _stopDate.AddSeconds(-_stopDate.Second))
            {
                var candleChain = await Foreman.GetCandleChain(pairCurr, timeInterval, false, _startDateStep, limit);

                foreach (Candle candleActual in GetCandles(candleChain))
                {
                    var now = DateTime.Now;
                    var tradeLife = !sttng.StopAfterNow && candleActual.EndDate + delaySpan >= now;
                    //LogHolder.DebugLogInfo($"candle.StartDat = {candleActual.StartDate} delaySpan = {delaySpan} now = {now}");
                    foreach (Prediction prediction in candleActual.Predictions)
                    {
                        if (!prediction.Overworking)
                        {
                            if (prediction.Conclusion.Contains("покупай"))
                            {
                                //Burge. тут берем цену , за которую готовы продавать нынче

                                market.Order(prediction, tradeLife, StyleTickedEnum.BUY);
                            }
                            else if (prediction.Conclusion.Contains("продавай"))
                            {
                                //Burge.тут берем цену , за которую готовы покупать нынче

                                market.Order(prediction, tradeLife, StyleTickedEnum.SELL);
                            }
                            else
                            {
                                LogHolder.MainLogInfo(
                                    prediction.Candle.EndDate.ToString("g") + ": " + prediction.Conclusion);
                            }

                            prediction.Overworking = true;
                        }
                    }
                }



                CandleChain cc = Foreman.GetCandleChane(pairCurr, timeInterval);
                var last = cc?.LastOrDefault();
                if (last != null && last.EndDate.Add(delaySpan) > _stopDate - delaySpan)
                {
                    if (sttng.StopAfterNow) // на этом всё пожалуй
                    {
                        Stop();
                        return;
                    }

                    // добавляем к последней свече 5 секунд, и вычисляем время следующего тика таймера
                    TimeSpan span;
                    if (last.EndDate > DateTime.Now)
                        span = last.EndDate.AddSeconds(5) - DateTime.Now;
                    else
                        span = last.EndDate.AddSeconds(5) + delaySpan - DateTime.Now;
                    _timer.Interval = span.TotalMilliseconds; // milliseconds
                    _totalTail = (int) (_timer.Interval / 1000);
                    _fastCounter = 0;
                    _fastTimer.Start(); 
                }

                
                //for (int i = 0; i < delayTime; i++)
                //{
                if (_stopAll)
                {
                    return;
                }
                _busyTimer = false;
            }
        }

        /// <summary>
        /// если стопДата в конфиге не фейковая, - берем её, иначе - Now
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        private static DateTime UpdataStopDate(Settings settings)
        {
            return settings.StopDate.Date + TimeSpan.FromDays(365) > DateTime.Now ? settings.StopDate : DateTime.Now + Converters.IntervalToTimespan(settings.TimeInterval);
        }
        

        /// <summary>
        /// отбираем свечи, перед которыми были актуальные советы (т.е. советы лежат свечах в предыдущих от этих свечей )
        /// </summary>
        /// <param name="candleChain"></param>
        /// <returns></returns>
        private static IEnumerable<Candle> GetCandles(CandleChain candleChain)
        {
            foreach (var candle in GetCandlesWhitActualPrediction(candleChain))
            {
                yield return candle;
            }
        }

        /// <summary>
        /// Берем свечу с актуальным предсказанием в предыдущей свече
        /// </summary>
        /// <remarks>предсказание в предыдущей свече не должно быть обработано</remarks>
        /// <param name="candleChain"></param>
        /// <returns></returns>
        private static IEnumerable<Candle> GetCandlesWhitActualPrediction(CandleChain candleChain)
        {
            return candleChain.OrderBy(can => can.EndDate).Where(can => can.Predictions.Any(pred => !pred.Overworking));
        }

        /// <summary>
        /// берем интервал до нынешнего времени, позднее которого поднимать StartDate в запросе не имеет смысла (все будет взято)
        /// </summary>
        /// <param name="timeInterval">шаг загрузки</param>
        /// <param name="limit">предельное количество свечей</param>
        /// <returns></returns>
        private static TimeSpan IntervalBeforeNow(TimeInterval timeInterval, int limit)
        {
            var intervalToTimespan = Converters.IntervalToTimespan(timeInterval);
            var intervalBeforeNow = new TimeSpan();
            for (var l = 0; l < limit; l++)
            {
                intervalBeforeNow += intervalToTimespan;
            }
            return intervalBeforeNow;
        }

        public void Stop()
        {

            _timer.Stop();
            _fastTimer.Stop();
            _busyTimer = false;
            Foreman.CalcProfit();
            _timer.Interval = 2000;  // 2 секундЫ задержка
            _stopAll = true;
            LogHolder.TraceLogInfo("Операция Остановлена");
        }

        //public static async Task<Market> GetMarket()
        //{
        //    var ai = await Burse.GetAccountInfo();
        //    var strBalance = "";
        //    var balancePair = new BalancePair("USDT", 0m, "BTC", 0m, BalanceTailEnum.Rsi);
        //    foreach (var balance in ai.Balances)
        //    {
        //        if (balance.Free != 0m || balance.Locked != 0m)
        //        {
        //            strBalance += $"{balance}; ";
        //        }
        //        if (balance.Free != 0m)
        //        {
        //            if (balance.Asset == balancePair.Prima.CurrName)
        //            {
        //                balancePair.Prima.Volume = balance.Free;
        //            }
        //            else if (balance.Asset == balancePair.Second.CurrName)
        //            {
        //                balancePair.Second.Volume = balance.Free;
        //            }
        //        }
        //    }

        //    var market = new Market(balancePair); // начальные параметры фейкового баланса
        //    return market;
        //}
    }
}
