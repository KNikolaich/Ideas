using System;
using DevExpress.XtraEditors;
using Trader.Ancillary;
using Trader.LiveCoin;

namespace WindowsFormApp.Controls
{
    public partial class ManualExcangeControl : DevExpress.XtraEditors.XtraUserControl, IBernControl
    {
        private Market _market;

        public ManualExcangeControl()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _market = await Market.GetDefault(BalanceTailEnum.Rsi, false);
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        private async void _sbBuyAll_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            _market.Order(null, true, StyleTickedEnum.BUY);
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        private async void _sbSaleAll_Click(object sender, EventArgs e)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            _market.Order(null, true, StyleTickedEnum.SELL);
        }

        public void BernAsync()
        {
            
        }

        public void Clean()
        {
            
        }
    }
}
