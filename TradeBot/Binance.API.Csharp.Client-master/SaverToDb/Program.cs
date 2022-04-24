using System;
using System.Collections.Generic;
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
                /*
                 * Метода выкачиваем все данные по паре symbol из сети binance
                 * для интервала времени TimeInterval.Hours_1
                 * начиная с даты from 
                 *
                */
                var symbol = "ETHUSDT";
                var modelBinance = new ModelBinance();
                modelBinance.Database.CreateIfNotExists();

                    //CreateStiks(symbol, modelBinance);
                UpdateStiks(symbol, modelBinance);
                modelBinance.SaveChanges();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }

        /// <summary>
        /// Берем одного за другим строки свечей, собираем инфу об экстремумах, на десяток в обе стороны
        /// если находим такого, который максимален из тех, что в обще стороны на десяток, это экстремум.
        /// обозначаем экстремум
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="modelBinance"></param>
        private static void UpdateStiks(string symbol, ModelBinance modelBinance)
        {

            var sortedStiks = modelBinance.Candlesticks.OrderBy(cs => cs.OpenTime);
            foreach (Candlestick candlestick in sortedStiks)
            {
                
            }

        }

        private static void CreateStiks(string symbol, ModelBinance modelBinance)
        {
            long maxTimeClose = 0;
            DateTime from = Converters.GeDateTime(1634309999999); //new DateTime(2017, 1, 1);

            while (DateTime.Today - @from > TimeSpan.FromDays(7)) // Если больше недели, берем новый цикл
            {
                Console.WriteLine($"Берем интервалы с {@from.ToString("F")}");
                BinanceClient bc = new BinanceClient(ApiClient.CreateEntityForCandlestiks());
                var candleSticks = bc.GetCandleSticks(symbol, TimeInterval.Hours_1, @from).Result;

                foreach (var stick in candleSticks)
                {
                    modelBinance.Candlesticks.Add(Candlestick.CreateFromStick(stick, symbol, TimeInterval.Hours_1));
                    if (maxTimeClose < stick.CloseTime)
                        maxTimeClose = stick.CloseTime;
                }

                @from = Converters.GeDateTime(maxTimeClose);
            }

            Console.WriteLine($"Сохраняем в БД {modelBinance.Candlesticks.Count()} записей");
        }
    }
}
