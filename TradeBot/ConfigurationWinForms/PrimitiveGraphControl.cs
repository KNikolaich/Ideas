using AnalyticalCenter.Indicators;
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
    public partial class PrimitiveGraphControl : UserControl
    {
        private List<MacD> _res;

        public PrimitiveGraphControl()
        {
            InitializeComponent();
        }


        private void PrimitiveGraphControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.Clear(BackColor);
            g.TranslateTransform(150, 150);
            if (_res == null)
            {
                for (float x = -2; x <= 2; x += 0.001F)
                {
                    float y = (float)Math.Sqrt(1 - Math.Pow(x, 2) / 4);
                    g.FillEllipse(Brushes.Black, x * 50, y * 50, 2, 2);
                    g.FillEllipse(Brushes.Black, x * 50, -y * 50, 2, 2);
                }
            }
            else
            {
                g.DrawLine(Pens.Black, -150, 0, 150, 0);
                g.DrawLine(Pens.Black, 0, -150, 0, 150);
                var redPen = new Pen(Brushes.DarkRed);
                for (int i = 0; i < _res.Count; i++)
                {
                    var resItem = _res[i];
                    g.DrawLine(redPen, new Point(i*2, 0), new Point(i*2, (int)resItem.Difference));

                }
            }
        }

        internal void CreateGraphics(List<MacD> res)
        {
            _res = res;
            //RePaint();
        }
    }
}
