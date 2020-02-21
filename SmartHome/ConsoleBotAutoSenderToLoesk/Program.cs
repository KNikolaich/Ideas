using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using Telegram.Bot;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleBotAutoSenderToLoesk.Model;
using MihaZupan;

namespace ConsoleBotAutoSenderToLoesk
{
    public class Program
    {
        private static ObservableCollection<TeleUser> _users;
        

        static void Main(string[] args)
        {
            Telega t = new Telega();
            
                
                //Console.WriteLine(DateTime.Now.ToLocalTime());
                t.SendMessage("");

                //Task.Run(RunBot);
                //RunBot();
             while (true)
            {   
                Thread.Sleep(500);
            }

            Console.ReadLine();
            Console.WriteLine(t.ToString());
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        public static void RunBot()
        {
            _users = new ObservableCollection<TeleUser>();
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("token " + Model.Telega.token);
            //var proxy = new HttpToSocks5Proxy("95.217.23.149", 46211);
            //var proxy = new WebProxy();
            

        }

    }
}
