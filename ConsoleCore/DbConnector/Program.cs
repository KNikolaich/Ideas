using System;
using System.Linq;
using DbConnector;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach (var item in new ClassTest().GetEntryGenerator())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
