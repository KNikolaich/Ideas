using System;
using System.Windows.Forms;
using StaffTimes.SubControls;

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
            var exceptionHandler = new IriExceptionHandler();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GeneralForm());
            if (exceptionHandler == exceptionHandler)
            {
                exceptionHandler = null;
            }
        }
    }
}