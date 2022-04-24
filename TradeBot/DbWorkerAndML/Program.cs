using System;
using System.IO;
using DbWorkerAndML.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbWorkerAndML
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Этап 2 создание советов
                Controller.TestAdvicesOnPerfectSphere();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
