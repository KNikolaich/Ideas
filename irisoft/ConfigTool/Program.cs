using System;
using System.Windows.Forms;
using Configuration.Exceptions;

namespace Configuration
{
    static class Program
    {
        /// <summary>
        /// The main Entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var exceptionHandler = new IriExceptionHandler();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfigurationForm());
            if (exceptionHandler == exceptionHandler)
            {
                exceptionHandler = null;
            }
        }
    }
}