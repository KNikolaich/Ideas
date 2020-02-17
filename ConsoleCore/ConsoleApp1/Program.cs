using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string helloWorld = "Hello World! Как делы? Будет ли мясо?";
            var res = helloWorld.Split(" ").OrderBy(s => s).Aggregate("Begin :", (s, s1) => s + s1);
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
