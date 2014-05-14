using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MouseRecord
{
    public partial class MouseRecControl : UserControl
    {
        private bool _recording;
        private Queue<MyAction> queueActions = new Queue<MyAction>();
        private DateTime _startDate;

        public MouseRecControl()
        {
            InitializeComponent();
        }

        private void bRec_Click(object sender, EventArgs e)
        {
            queueActions.Clear();
            _listBoxResult.Text = "";
            _startDate = DateTime.Now;
            _recording = true;
        }

        private void bPlay_Click(object sender, EventArgs e)
        {
            
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            _recording = false;
        }

        #region Overrides of Control

        public void OnMouseClick(MouseEventArgs e)
        {
            if (_recording)
            {
                var action = new MyAction(DateTime.Now - _startDate, new Point(e.X, e.Y));
                queueActions.Enqueue(action);
                _listBoxResult.Items.Add("\n\r" + action);
            }
            base.OnMouseClick(e);

        }

        #endregion
    }
}
