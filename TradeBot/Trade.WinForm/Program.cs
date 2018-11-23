using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormApp.Properties;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Xpo;
using NLog;
using NLog.Targets.Wrappers;
using Trader;
using Trader.Ancillary;
using Trader.Model;
using Trader.ORMDataModelCode;

namespace WindowsFormApp
{
    static class Program
    {
/*
        private static readonly bool IsConsole = true;
*/

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string[] args = Environment.GetCommandLineArgs();
                if (args.Length > 1) // gets passed its path, by default
                {
                    Console.Clear();
                    Console.WriteLine("Выберите номер алгоритма:");
                    Console.WriteLine("1: пересечения SMA на 8 и 21.");
                    var key = Console.ReadKey();
                    if (key.KeyChar == '1')
                    {

                        LogHolder.MessageLogEventHandler += LogHolderOnMessageLogEventHandler;



                        var market = Market.GetDefault(BalanceTailEnum.MacD, Settings.Default.OnlyViewMode).Result;

                        var algorithm = new Algorithm(market);
                        algorithm.AlgorithmNumberOne(false);
                    }
                    return;
                }
                else
                {
                    var proc = Process.GetCurrentProcess();
                    var vss = Application.VisualStyleState;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    //Включить обработку исключений
                    ExceptionHandler exceptionHandler = new ExceptionHandler();
                    BonusSkins.Register();
                    SkinManager.EnableFormSkins();
                    var mainForm = new MainForm();
                    mainForm.Show();
                    Application.Run(mainForm);

                    if (Equals(exceptionHandler, exceptionHandler)) // типа так надо
                        exceptionHandler = null;
                }
            }
            // Обрабатываем исключение при некорректном вводе числа в консоль
            catch (Exception ex)
            {
                //Console.WriteLine("Это НЕ число!!!\n");
                Console.WriteLine("ОШИБКА: " + ex.Message + Environment.NewLine + ex.InnerException?.Message);
                Main();
            }
            finally
            {

                LogHolder.MessageLogEventHandler -= LogHolderOnMessageLogEventHandler;
            }
            Console.ReadLine();

        }

        private static void LogHolderOnMessageLogEventHandler(object sender, LogEventInfo logEventInfo)
        {
            Console.WriteLine(logEventInfo.Message);
        }

        private static string GetLastCandleResult(CandleChain candleChain)
        {
            var candle = candleChain.LastOrDefault();

            var lastCandleResult = "";
            
            if (candle != null)
            {
                //lastCandleResult = candle.GetMessageBySMA(false);
                var prediction = candle.Predictions.FirstOrDefault();
                if (prediction != null)
                {
                    lastCandleResult = prediction.Conclusion;
                }
            }
            return lastCandleResult;
        }
    }
}
