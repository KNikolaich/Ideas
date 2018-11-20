using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using Trader;
using Trader.Model;
using Trader.ORMDataModelCode;

namespace WindowsFormApp.Controls
{
    public partial class XtraGraphControl : XtraUserControl, IBernControl
    {

        SecondaryAxisY secondaryAxisY5 = new SecondaryAxisY();

        public XtraGraphControl()
        {
            InitializeComponent();
        }

        public void BernAsync()
        {
            
            this.usdtCollection.Session = OrmDataHelper.GetNewUnitOfWork();
            this.btcCollection.Session = OrmDataHelper.GetNewUnitOfWork();
            this.stochRsiK_Collection.Session = OrmDataHelper.GetNewUnitOfWork();
            this.StochRSI_DCollection.Session = OrmDataHelper.GetNewUnitOfWork();
            this.rsiCollection.Session = OrmDataHelper.GetNewUnitOfWork();
            this.rsiTrandCollection.Session = OrmDataHelper.GetNewUnitOfWork();

            var maxB = rsiCollection.Count > 0 ? rsiCollection.Cast<Balance>().Max(b => b.Price) : 100;

            var minB = rsiCollection.Count > 0 ? rsiCollection.Cast<Balance>().Min(b => b.Price) : 0;


            secondaryAxisY5.WholeRange.Auto = false;

            secondaryAxisY5.WholeRange.MaxValue = Math.Round(maxB) + 100;
            secondaryAxisY5.WholeRange.MinValue = Math.Round(minB) - 100;
            // unitOfWork1.ConnectionString = Trader.ConnectionHelper.ConnectionString;
            //usdtCollection.Load();

            //btcCollection.Load();

            //hystogramCollection.Load();
            //signalCollection.Load();
        }

        public void Clean()
        {
            OrmDataHelper.DeleteAllBalances();
            Foreman.ClearChain(Properties.Settings.Default.PairCurrency, Properties.Settings.Default.TimeInterval);
        }
        
    }
}
