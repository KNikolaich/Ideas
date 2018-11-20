using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Trader.Ancillary
{
    public partial class FormException : DevExpress.XtraEditors.XtraForm
    {
        public FormException()
        {
            InitializeComponent();
        }

        private void sbExit_Click(object sender, EventArgs e)
        {

        }

        private void sbOk_Click(object sender, EventArgs e)
        {

        }

        public static bool Execute(Exception eException)
        {
            DialogResult result;
            using (var form = new FormException())
            {
                form._meExceptionText.Text = eException.Message + eException.InnerException?.Message;
                result = form.ShowDialog();
            }

            return result == DialogResult.OK;
        }
    }
}