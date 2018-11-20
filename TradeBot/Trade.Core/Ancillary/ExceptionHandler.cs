using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.XtraMessageBox;

namespace Trader.Ancillary
{
    /// <summary>
    /// Обработчик исключений приложения
    /// </summary>
    public sealed class ExceptionHandler
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ExceptionHandler()
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
            LogHolder.ErrorLogInfo(e.Exception);
            
            if (!FormException.Execute(e.Exception))
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Ошибка обновления базы отображается более спокойно, чем все остальные эксепшены.
        /// </summary>
        /// <param name="message"></param>
        private static void ShowInvalidColumnException(string message)
        {
            if (MessageBox.Show(message, "Ошибка",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error) == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
