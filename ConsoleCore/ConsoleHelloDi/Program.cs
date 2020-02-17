using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelloDi
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMessageWriter writer = new ConsoleMessageWriter();
            var typeName = Properties.Settings.Default.messageWriter;
            var typeMsg = Type.GetType(typeName, true);
            IMessageWriter writer = (IMessageWriter) Activator.CreateInstance(typeMsg);
            var salutation = new Salutation(writer);

            salutation.Exclaim();

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
