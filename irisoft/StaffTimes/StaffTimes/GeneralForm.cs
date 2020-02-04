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

            using (var repository = new StaffTimesContainer())
            {
                //var days = repository.Day.Where(w => w.UserId == _user.Id).ToList();
                //var source = days.Select(w=> new {w.Id, w.Approved, w.Date, w.Status} ).ToList();
                //_gridDays.DataSource = source;
            }
        }

        private void stmiUsers_Click(object sender, EventArgs e)
        {
            using (StaffsForm sf = new StaffsForm())
            {
                sf.ShowDialog();
            }
        }


        private void _gridWeeks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //_gridDays.DataSource
            //e.RowIndex
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            using (LoginForm logForm = new LoginForm())
            {
                if (logForm.ShowDialog() == DialogResult.OK)
                {
                    _user = logForm.GetUser();
                    Text += (" - " + _user);
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
