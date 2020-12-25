using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Configuration.Exceptions
{
    /// <summary>
    /// Обработчик исключений приложения
    /// </summary>
    public sealed class IriExceptionHandler : IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IriExceptionHandler()
        {
            // Подписываемся на событие генерации исключения в текущем потоке
            Application.ThreadException += OnApplicationThreadException;
        }

        /// <summary>
        /// Переопределение обработки исключения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowMessageException(e.Exception);
        }

        /// <summary>
        /// Ошибка обновления базы отображается более спокойно, чем все остальные эксепшены.
        /// </summary>
        /// <param name="ex">исключение</param>
        private static void ShowMessageException(Exception ex)
        {
            string message = null;
            var messageBoxButtons = ex is UndeclaredValueException || ex is UnuniqueValueException || ex is FormatException
                ? MessageBoxButtons.OK 
                : MessageBoxButtons.OKCancel;
            if (ex.Message.Equals("The underlying provider failed on Open."))
            {
                messageBoxButtons = MessageBoxButtons.OK;
            }
            message = ex.Message;

#if Test
            message += Environment.NewLine + ex.InnerException?.Message + Environment.NewLine + ex.InnerException?.InnerException?.Message + Environment.NewLine + ex.StackTrace;
#endif
            if (MessageBox.Show(message, "Ошибка", messageBoxButtons, MessageBoxIcon.Error) == DialogResult.Cancel) 
            {
                Application.Exit();
            }
        }

        public void Dispose()
        {
        }
    }
}