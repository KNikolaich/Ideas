using System;
using System.Windows.Forms;
using Core;
using Core.Exceptions;

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
            IriExceptionHandler iriExceptionHandler = new IriExceptionHandler();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User currentUser = null;
            using (LoginForm logForm = new LoginForm())
            {
                if (logForm.ShowDialog() == DialogResult.OK)
                {
                    currentUser = logForm.GetUser();
                }
            }
            if (currentUser != null)
                Application.Run(new GeneralForm(currentUser));
            if (iriExceptionHandler == iriExceptionHandler)
            {
                iriExceptionHandler = null;
            }
        }
    }
}