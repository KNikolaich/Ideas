using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;

namespace StaffTimes
{
    public partial class StaffsForm : Form
    {
        private StaffTimeModelContainer _repository;

        public StaffsForm()
        {
            InitializeComponent();
        }

        private void StaffsForm_Load(object sender, EventArgs e)
        {
            _repository = new StaffTimeModelContainer();
            _gridStaff.DataSource = _repository.User.ToArray();
        }

        private void tsmInsert_Click(object sender, EventArgs e)
        {
            using (StaffEditForm sef = new StaffEditForm(null))
            {
                if (sef.ShowDialog(this) == DialogResult.OK)
                {
                    _repository.CreateUser(sef.Staff.UserName, sef.Staff.Login, sef.Staff.Password, (RoleEnum) sef.Staff.Role);
                    _gridStaff.Refresh();
                }
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            _repository.User.Load();
            _gridStaff.Refresh();
        }
    }
}
