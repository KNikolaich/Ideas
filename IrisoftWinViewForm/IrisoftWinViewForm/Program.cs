using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace IrisoftWinViewForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Включить обработку исключений
            ExceptionHandler exceptionHandler = new ExceptionHandler();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalcCoefficientForm());

            if (Equals(exceptionHandler, exceptionHandler)) // так надо чтобы оптимизатор не убил этот объект
            {
                exceptionHandler.ToString();
            }
        }
    }
}
