using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using SaverToDb.Db;

namespace SaverToDb
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var modelBinance = new ModelBinance();
                // Этап 1 Заливка БД
                // FillDbFromBurse(modelBinance);


                // Этап 2 создание советов
                 CreateAdvices(modelBinance);

                // Этап 3 Test
                var closeTime = Converters.GeDateTime(new DateTime(2021, 12, 1));
                var sticks = modelBinance.Candlesticks.
                    //Where(s => s.CloseTime > closeTime).
                    OrderBy(c => c.OpenTime);
                decimal moneyUsd = 100;// даем для теста столько баксов
                decimal moneyEth = 0;// даем для теста столько баксов
                var calcPlus = 0;
                var calcMinus = 0;
                var prevUsd = moneyUsd;
                foreach (var stick in sticks)
                {
                    if (stick.Advice/100 == (int) AdviceEnum.Buy && moneyUsd > 0)
                    {
                        moneyEth = moneyUsd / stick.Close;
                        // Console.WriteLine("Eth: " + moneyEth.ToString());
                    }
                    if (stick.Advice/100 == (int)AdviceEnum.Sell && moneyEth > 0)
                    {
                        moneyUsd = moneyEth * stick.Close;
                        // Console.WriteLine("Usd: " + moneyUsd.ToString());
                        if(prevUsd < moneyUsd)
                        {
                            calcPlus++;
                        }
                        else
                        {
                            calcMinus++;
                        }

                        prevUsd = moneyUsd;
                    }
                }
                Console.WriteLine("Положительных операций." + calcPlus);
                Console.WriteLine("Отрицательных операций." + calcMinus);
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                Console.ReadLine();
            }
        }

        private static void CreateAdvices(ModelBinance modelBinance)
        {
            Candlestick previewCandle = null;
            // Queue<Candlestick> queue = new Queue<Candlestick>();
            // AdviceEnum explorAdviceEnum = AdviceEnum.Buy;
            var sticks = modelBinance.Candlesticks /*.Where(c => c.OpenTime > 1638305999999)*/.OrderBy(c => c.OpenTime);
            foreach (var candlestick in sticks) //GetAllSticks(modelBinance, new DateTime(2021, 12, 1)))
            {
                if (previewCandle != null)
                    candlestick.SetPrevCandle(previewCandle);

                var findExtremumCandle = candlestick.FindExtremumCandle();
                findExtremumCandle?.Item1.MarkCandlesBeforeExtremum(findExtremumCandle.Item2);
                /*queue.Enqueue(candlestick);
                    if (queue.Count >= 16 && FindAdviceForQueue(queue, explorAdviceEnum))
                    {
                        explorAdviceEnum = (AdviceEnum) ((int) explorAdviceEnum * -1);
                    }
                    */

                previewCandle = candlestick;
            }

            modelBinance.SaveChanges();
        }

        private static void FillDbFromBurse(ModelBinance modelBinance)
        {
            /*
                /*
                 * Метода выкачиваем все данные по паре symbol из сети binance
                 * для интервала времени TimeInterval.Hours_1
                 * начиная с даты from 
                 *
                #1#
                */
            var symbol = "ETHUSDT";
            modelBinance.Database.CreateIfNotExists();
            long maxTimeClose = 0;
            DateTime from = new DateTime(2017, 10, 1);

            while (DateTime.Today - @from > TimeSpan.FromDays(7)) // Если больше недели, берем новый цикл
            {
                Console.WriteLine($"Берем интервалы с {@from.ToString("F")}");


                ApiClient apiClient = new ApiClient("apiKey", "apiValue");
                BinanceClient bc = new BinanceClient(apiClient);
                var candleSticks = bc.GetCandleSticks(symbol, TimeInterval.Hours_1, @from).Result;

                foreach (var stick in candleSticks)
                {
                    modelBinance.Candlesticks.Add(Candlestick.CreateFromStick(stick, symbol, TimeInterval.Hours_1));
                    if (maxTimeClose < stick.CloseTime)
                        maxTimeClose = stick.CloseTime;
                }

                @from = Converters.GeDateTime(maxTimeClose);
            }

            modelBinance.SaveChanges();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        private static bool FindAdviceForQueue(Queue<Candlestick> queue, AdviceEnum explorAdviceEnum)
        {
            int i = 0;
            var extremum = queue.First().Close;
            bool find = false;
            foreach (var candlestick in queue)
            {
                i++;

                if (explorAdviceEnum == AdviceEnum.Buy && candlestick.Close < extremum
                    || explorAdviceEnum == AdviceEnum.Sell && candlestick.Close > extremum)
                {
                    if (i > (queue.Count / 2)) // перевалили через середину очереди
                    {
                        find = false; // нас интересуют экстремумы в первой половине списка
                    }
                    else
                    {
                        find = true;
                    }
                    extremum = candlestick.Close;

                }

            }

            if (find) // нашли 
            {
                var candlestick = queue.Last(c => c.Close == extremum);
                candlestick.Advice = (int)explorAdviceEnum;
                var sAction = explorAdviceEnum == AdviceEnum.Buy ? "покупку" : "продажу";
                Console.WriteLine($"Сингал на {sAction} по цене {candlestick.Close}");
                for (int j = 0; j < queue.Count; j++)
                {
                    var candle = queue.Dequeue();
                    if (candle == candlestick)
                        return find;
                }
            }

            queue.Dequeue(); // если не нашли экстремума в первой половине ,  - выгоняем из очереди одну свечу
            return find;
        }

        private static IEnumerable<Candlestick> GetAllSticks(ModelBinance modelBinance, DateTime fromTime)
        {
            var itemCount = 0;
            var itemTake = 16;
            var candlesticks = modelBinance.Candlesticks.Where(c => c.OpenTime > 1638305999999).OrderBy(c => c.OpenTime);
            while (true)
            {
                var take = candlesticks.Skip(itemCount).Take(itemTake);
                if (!take.Any())
                    break;
                foreach (var candlestick in take)
                {
                    yield return candlestick;
                }
                modelBinance.Candlesticks.AddOrUpdate(take.ToArray());
                modelBinance.SaveChanges();
                Console.WriteLine(itemCount);
                itemCount += itemTake;
            }
        }
    }
}
