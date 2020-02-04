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
        private StaffTimesContainer _repository;

        public GeneralForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _repository = new StaffTimesContainer();

            if (_user.Role != StaffRole.Admin)
            {
#if !DEBUG
                ContextMenu = null;
#endif
            }
            gridControl1.DataSource = _repository.Task.ToArray();
                //var days = _repository.Day.Where(w => w.UserId == _user.Id).ToList();
                //var source = days.Select(w=> new {w.Id, w.Approved, w.Date, w.Status} ).ToList();
                //_gridDays.DataSource = source;
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
            gridView1.ExpandAllGroups();
        }

        private void _tsmiProjects_Click(object sender, EventArgs e)
        {
            using (ProjectsForm pf = new ProjectsForm())
            {
                pf.ShowDialog();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void _tsmiUsers_Click(object sender, EventArgs e)
        {
            using (StaffsForm sf = new StaffsForm())
            {
                sf.ShowDialog();
            }
        }
    }
}
