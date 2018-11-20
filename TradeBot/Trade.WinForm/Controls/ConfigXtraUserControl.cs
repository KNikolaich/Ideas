using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormApp.Properties;
using Binance.API.Csharp.Client.Models.Enums;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace WindowsFormApp.Controls
{
    public partial class ConfigXtraUserControl : DevExpress.XtraEditors.XtraUserControl, IBernControl
    {
        public ConfigXtraUserControl()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            GetPropertys();
            base.OnLoad(e);
        }

        public async void BernAsync()
        {
            await Task.Run(() => SavePropertys());
        }

        public void SavePropertys()
        {
            Settings.Default["StartDate"] = dateEditStart.EditValue;
            Settings.Default["StopDate"] = _deStopDate.EditValue;
            Settings.Default["DepthQueue"] = (short)spinEditDepth.Value;
            Settings.Default["TimeInterval"] = (TimeInterval)timeframeTrackBarControl.Value;
            Settings.Default["LogDebugInfo"] = checkEditDebugInfoSave.EditValue;
            Settings.Default["StopAfterNow"] = _ceStopAfterNow.EditValue;
            Settings.Default.Save();
        }

        public void Clean()
        {
            GetPropertys();
        }

        private void GetPropertys()
        {
            var property = Settings.Default;
            dateEditStart.EditValue = property.StartDate;
            _deStopDate.EditValue = property.StopDate;

            timeframeTrackBarControl.Value = (int) property.TimeInterval;
            spinEditDepth.Value = property.DepthQueue;
            checkEditDebugInfoSave.EditValue = property.LogDebugInfo;
            _ceStopAfterNow.EditValue = property.StopAfterNow;
        }

    }
}
