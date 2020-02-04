using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffTimes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExceptionHandler exceptionHandler = new ExceptionHandler();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProjectsForm());
            if (Equals(exceptionHandler, exceptionHandler)) // так надо чтобы оптимизатор не убил этот объект
            {
                exceptionHandler.ToString();
            }
        }
    }
}
