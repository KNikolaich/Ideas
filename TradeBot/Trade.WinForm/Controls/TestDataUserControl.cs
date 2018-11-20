using System;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormApp.Properties;
using DevExpress.XtraEditors.Controls;
using NLog;
using Trader.Ancillary;

namespace WindowsFormApp.Controls
{
    public partial class TestDataUserControl : DevExpress.XtraEditors.XtraUserControl, IBernControl
    {
        private bool isStart = false;
        private Algorithm _algo;


        public TestDataUserControl()
        {
            InitializeComponent();
        }

        /// <summary> Это наш расчетный модуль </summary>
        /// <param name="onlyViewMode"></param>
        public async Task<Algorithm> GetAlgorithm(bool onlyViewMode = false)
        {
            if (_algo == null)
            {
                var market = await Market.GetDefault(BalanceTailEnum.Rsi, onlyViewMode);
                _algo = new Algorithm(market);
            }

            return _algo;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            LogHolder.MessageLogEventHandler -= LogHolder_MessageLogEventHandler;
            LogHolder.MessageLogEventHandler += LogHolder_MessageLogEventHandler;

            LogHolder.PropgressEventHandler -= LogHolder_PropgressEventHandler;
            LogHolder.PropgressEventHandler += LogHolder_PropgressEventHandler;
        }

        public async void BernAsync()
        {
            try
            {

                if (!isStart)
                {
                    Clean();
                    isStart = true;
                    var stopped = Settings.Default.StopAfterNow;
                    var algorithm = await GetAlgorithm(Settings.Default.OnlyViewMode);
                    algorithm.AlgorithmNumberOne(stopped);
                }
                else
                {
                    var algorithm = await GetAlgorithm();
                    algorithm.Stop();
                    isStart = false;
                }

            }
            catch (Exception exception)
            {
                LogHolder.ErrorLogInfo(exception);
                //if (!tokenSource2.IsCancellationRequested)
                //{
                //    tokenSource2.Cancel(false);

                //    isStart = false;
                //}

            }
        }


        public void Clean()
        {
            _imageListBoxControl.Items.Clear();
        }

        private void LogHolder_PropgressEventHandler(object sender, ProgressInfo e)
        {
            _progressBarControl.BeginInvoke((Action)(() =>
            {
                _progressBarControl.Properties.Maximum = e.MaximumValue;
                _progressBarControl.EditValue = e.MaximumValue - e.CurrentValue;
                _progressBarControl.ToolTipTitle = e.Comment;

            }));
        }

        private void LogHolder_MessageLogEventHandler(object sender, LogEventInfo e)
        {
            var levelImgIndx = ConvertImageIndx(e.Level);
            if (checkedComboBoxEditShowInfo.EditValue.ToString().Contains(levelImgIndx.ToString()))
            {
                if (e.Level != LogLevel.Debug || Settings.Default.LogDebugInfo)
                {

                    _imageListBoxControl.Invoke((Action) (
                        () =>
                        {
                            var imageListBoxItem = new ImageListBoxItem(null, e.Message,
                                ConvertImageIndx(e.Level));
                            _imageListBoxControl.Items.Insert(0, imageListBoxItem);
                        }));
                    //_memoEdit.Text += Environment.NewLine + e.Message;
                }
            }
        }

        private int ConvertImageIndx(LogLevel logLevel)
        {
            int imgIndx = -1;
            if (logLevel == LogLevel.Debug)
            {
                imgIndx = 2;
            }
            else if (logLevel == LogLevel.Error)
            {
                imgIndx = 4;
            }
            else if (logLevel == LogLevel.Warn)
            {
                imgIndx = 1;
            }
            else if (logLevel == LogLevel.Trace)
            {
                imgIndx = 3;
            }
            else if (logLevel == LogLevel.Info)
            {
                imgIndx = 0;

            }
            return imgIndx;
        }
    }
}
