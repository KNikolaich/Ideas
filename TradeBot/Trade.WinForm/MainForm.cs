using System;
using System.Windows.Forms;
using WindowsFormApp.Controls;
using DevExpress.XtraEditors;
using NLog;
using Trader.Ancillary;

namespace WindowsFormApp
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LogHolder.MessageLogEventHandler += LogHolder_MessageLogEventHandler;
            InitContextMenu();
        }

        private void InitContextMenu()
        {
            var tsmiShow = new ToolStripMenuItem
            {
                Name = "tsmiShow",
                Size = new System.Drawing.Size(128, 22),
                Text = "Показать",
                ToolTipText = "Показать основное окно приложения"
            };

            tsmiShow.Click += tsmiShow_Click;

            var tsmiExit = new ToolStripMenuItem
            {
                Name = "tsmiExit",
                Size = new System.Drawing.Size(128, 22),
                Text = "Выход",
            };

            tsmiExit.Click += TsmiExit_Click;
            
            var tsmiStopWork = new ToolStripMenuItem
            {
                Name = "tsmiStopWork",
                Size = new System.Drawing.Size(128, 22),
                Text = "Остановить обработку",
            };
            tsmiStopWork.Click += tsmiStopWork_Click;

            _contextMenu.Items.AddRange(new ToolStripItem[] {
                tsmiShow,
                tsmiExit,
                tsmiStopWork
            });
            _contextMenu.Name = "_contextMenu";
            _contextMenu.Size = new System.Drawing.Size(129, 48);
        }

        private async void tsmiStopWork_Click(object sender, EventArgs e)
        {
            var algorithm = await testDataUserControl1.GetAlgorithm();
            algorithm.Stop();
        }
        
        private void SbClear_Click(object sender, EventArgs e)
        {

            sbClear.Enabled = false;
            foreach (Control selectedPageControl in tabPane1.SelectedPage.Controls)
            {
                if (selectedPageControl is IBernControl)
                {
                    ((IBernControl)selectedPageControl).Clean();
                    //LogHolder.MainLogInfo("пыщь");
                }
            }
            sbClear.Enabled = true;
        }

        private void LogHolder_MessageLogEventHandler(object sender, LogEventInfo e)
        {
            notifyIcon.BalloonTipIcon = GetIcon(e.Level);
            notifyIcon.BalloonTipText = e.FormattedMessage + e.Exception?.Message + e.Exception?.InnerException?.Message;
            notifyIcon.BalloonTipTitle = e.Message;
            if(e.Level == LogLevel.Info || e.Level == LogLevel.Warn || e.Level == LogLevel.Error)
                notifyIcon.ShowBalloonTip(1);
            if (e.Level == LogLevel.Debug)
            {
                notifyIcon.Text = e.FormattedMessage.Length > 63 ? e.FormattedMessage.Remove(63) : e.FormattedMessage;
            }
        }

        private ToolTipIcon GetIcon(LogLevel logLevel)
        {
            ToolTipIcon imgIndx = ToolTipIcon.None;
            if (logLevel == LogLevel.Error)
            {
                imgIndx = ToolTipIcon.Error;
            }
            else if (logLevel == LogLevel.Warn || logLevel == LogLevel.Debug)
            {
                imgIndx = ToolTipIcon.Warning;
            }
            else if (logLevel == LogLevel.Trace || logLevel == LogLevel.Info)
            {
                imgIndx = ToolTipIcon.Info;

            }
            return imgIndx;
        }
        
        private void sbBern_Click(object sender, EventArgs e)
        {

            sbBern.Enabled = false;
            foreach (Control selectedPageControl in tabPane1.SelectedPage.Controls)
            {
                if (selectedPageControl is IBernControl)
                {
                    ((IBernControl)selectedPageControl).BernAsync();
                    //LogHolder.MainLogInfo("пыщь");
                }
            }
            sbBern.Enabled = true;
        }

        private void sbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void sbHide_Click(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
            notifyIcon.Visible = true;

        }


        private void TsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}