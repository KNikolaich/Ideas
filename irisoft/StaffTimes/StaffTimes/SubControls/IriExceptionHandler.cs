using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace StaffTimes.SubControls
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
            /*ISession session = Avicenna.Instance.GetSession();
            if (session == null)
            {
                Application.Exit();
            }*/
            //else if (Session.SysUser == null
            //    || BaseObject.IsPermission("84"))

            {
                if ((e.Exception is InvalidOperationException
                    && e.Exception.InnerException is SqlException) ||
                    (e.Exception is TargetInvocationException
                    && e.Exception.InnerException is InvalidOperationException
                    && e.Exception.InnerException.InnerException is SqlException))
                {

                    var ex = e.Exception.InnerException as SqlException;
                    if (ex == null)
                        ex = e.Exception.InnerException.InnerException as SqlException;

                    if (ex != null && ex.Number == 229)
                    {
                        String action = "<действие>";
                        if (ex.Data["Action"] == null)
                        {
                            if (ex.Message.Contains("SELECT"))
                            { action = "чтение"; }
                            else if (ex.Message.Contains("INSERT"))
                            { action = "добавление"; }
                            else if (ex.Message.Contains("UPDATE"))
                            { action = "обновление"; }
                            else if (ex.Message.Contains("DELETE"))
                            { action = "удаление"; }
                        }
                        else
                        {
                            if (Equals(ex.Data["Action"], "SELECT"))
                            {
                                action = "чтение";
                            }
                            else if (Equals(ex.Data["Action"], "INSERT"))
                            {
                                action = "добавление";
                            }
                            else if (Equals(ex.Data["Action"], "UPDATE"))
                            {
                                action = "обновление";
                            }
                            else if (Equals(ex.Data["Action"], "DELETE"))
                            {
                                action = "удаление";
                            }
                        }
                        MessageBox.Show(String.Format("У Вас нет прав на {2} информации в [{0}] - {1}",
                                                          ex.Data["Name"], ex.Data["Description"], action), "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ShowMessageException(e.Exception);
                }
            }
            //else
            //{
            //    XtraMessageBox.Show("Операция прервана, обратитесь к администратору системы.", "Ошибка",
            //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// Ошибка обновления базы отображается более спокойно, чем все остальные эксепшены.
        /// </summary>
        /// <param name="ex">исключение</param>
        private static void ShowMessageException(Exception ex)
        {
            var messageBoxButtons = MessageBoxButtons.OKCancel;
            if (ex.Message.Equals("The underlying provider failed on Open."))
            {
                messageBoxButtons = MessageBoxButtons.OK;
            }
            string message = ex.Message + Environment.NewLine + ex.InnerException?.Message + Environment.NewLine + ex.InnerException?.InnerException?.Message;
            
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
