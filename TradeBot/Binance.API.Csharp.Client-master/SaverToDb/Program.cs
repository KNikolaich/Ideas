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
                long maxTimeClose = 0;
                DateTime from = /*Converters.GeDateTime(1634309999999);//*/new DateTime(2012, 1, 1);

                while (DateTime.Today - from > TimeSpan.FromDays(7)) // Если больше недели, берем новый цикл
                {
                    Console.WriteLine($"Берем интервалы с {from.ToString("F")}");


                    ApiClient apiClient = new ApiClient("g418u6xsd7KdXLYgWiVQfwQmiY1WH066iWvu2MEWiZSQA2YnXj0npkw3zsSfn1jX", 
                        "sV6i1af8ygigEh53gpf3zEKxHuwuZHe48TywePHwkodrHlQu0kzUssT8XUN1draI");
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

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
