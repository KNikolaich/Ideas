using System;

namespace ConsoleCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var runnerBy = new RunnerByTimer();
            runnerBy.LoggerDelegate += Logger;
            Console.ReadKey();
        }

        private static void Logger(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }
    }
}
