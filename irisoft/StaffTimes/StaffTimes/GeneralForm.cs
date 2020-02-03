using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;

namespace StaffTimes
{
    public partial class GeneralForm : Form
    {
        private User _user;

        public GeneralForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            using (var repository = new StaffTimeModelContainer())
            {
                _gridWeeks.DataSource = repository.Week.ToList();
            }
        }

        private void stmiUsers_Click(object sender, EventArgs e)
        {
            using (StaffsForm sf = new StaffsForm())
            {
                sf.ShowDialog();
            }
        }

        private void _gridWeeks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var col = _gridWeeks.Columns[e.ColumnIndex];

        }

        private void _gridWeeks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //_gridWeeks.DataSource
            //e.RowIndex
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            using (LoginForm logForm = new LoginForm())
            {
                if (logForm.ShowDialog() == DialogResult.OK)
                {
                    _user = logForm.GetUser();
                }
                else
                {
                    Hide();
                    Close();
                }
            }
        }
    }
}
