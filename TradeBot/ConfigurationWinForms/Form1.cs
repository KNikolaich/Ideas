using AnalyticalCenter;
using AnalyticalCenter.Helpers;
using Binance.API.Csharp.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigurationWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunStrategy();
        }

        private async Task RunStrategy()
        {

            var strategy = new MacDStrategy();
            var res = await strategy.TestForPeriodAsync(new DateTime(2020, 01, 01), new DateTime(2020, 12, 01), TimeInterval.Days_3);
            TextFileSaver.SaveData(res);
            panel1.CreateGraphics(res);
        }
    }
}
