using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetResponse(args));
        }

        private static string GetResponse(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    return JustGetter.GetSomeUrlResult(args[0]);
                case 2:
                    return JustGetter.GetStrFromRequiest(args[0], args[1]);
                default:
                    return "ожидается 2 аргумента: 1, - адрес запроса; 2 - имя свойства";
            }
        }
    }
}
