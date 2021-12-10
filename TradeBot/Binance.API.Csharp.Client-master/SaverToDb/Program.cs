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
                Candlestick previewCandle = null;
                Queue<Candlestick> queue = new Queue<Candlestick>();
                AdviceEnum explorAdviceEnum = AdviceEnum.Buy;
                foreach (var candlestick in GetAllSticks(modelBinance))
                {

                    if(previewCandle != null)
                        candlestick.SetPrevCandle(previewCandle);
                    queue.Enqueue(candlestick);
                    if (queue.Count >= 16 && FindAdviceForQueue(queue, explorAdviceEnum))
                    {
                        explorAdviceEnum = (AdviceEnum) ((int) explorAdviceEnum * -1);
                    }

                    previewCandle = candlestick;
                }

                modelBinance.SaveChanges();
                Console.ReadLine();
                //modelBinance.Candlesticks.AddOrUpdate();

                /*
                /*
                 * Метода выкачиваем все данные по паре symbol из сети binance
                 * для интервала времени TimeInterval.Hours_1
                 * начиная с даты from 
                 *
                #1#
                var symbol = "ETHUSDT";
                modelBinance.Database.CreateIfNotExists();
                long maxTimeClose = 0;
                DateTime from = /*Converters.GeDateTime(1634309999999);//#1#new DateTime(2012, 1, 1);

                while (DateTime.Today - from > TimeSpan.FromDays(7)) // Если больше недели, берем новый цикл
                {
                    Console.WriteLine($"Берем интервалы с {from.ToString("F")}");


                    ApiClient apiClient = new ApiClient("apiKey", "apiValue");
                    BinanceClient bc = new BinanceClient(apiClient);
                    var candleSticks = bc.GetCandleSticks(symbol, TimeInterval.Hours_1, from).Result;

                    foreach (var stick in candleSticks)
                    {
                        modelBinance.Candlesticks.Add(Candlestick.CreateFromStick(stick, symbol, TimeInterval.Hours_1));
                        if (maxTimeClose < stick.CloseTime)
                            maxTimeClose = stick.CloseTime;
                    }
                    from = Converters.GeDateTime(maxTimeClose);
                }

                Console.WriteLine($"Сохраняем в БД {modelBinance.Candlesticks.Count()} записей");
                modelBinance.SaveChanges();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                */

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                Console.ReadLine();
            }
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

        private static IEnumerable<Candlestick> GetAllSticks(ModelBinance modelBinance)
        {
            var itemCount = 0;
            var itemTake = 16;
            var candlesticks = modelBinance.Candlesticks.OrderBy(c => c.OpenTime);
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
