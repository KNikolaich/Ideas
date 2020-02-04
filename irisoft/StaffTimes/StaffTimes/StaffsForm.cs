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
using DevExpress.XtraGrid.Views.Grid;

namespace StaffTimes
{
    public partial class StaffsForm : Form
    {
        private StaffTimesContainer _repository;

        public StaffsForm()
        {
            InitializeComponent();
        }

        private void StaffsForm_Load(object sender, EventArgs e)
        {
            _repository = new StaffTimesContainer();
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None; // пока отклдючено, не работает
            gridControl1.DataSource = _repository.User.ToArray();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _repository.SaveChanges();
            base.OnClosing(e);
        }

        private void tsmInsert_Click(object sender, EventArgs e)
        {
            using (StaffEditForm sef = new StaffEditForm(null))
            {
                if (sef.ShowDialog(this) == DialogResult.OK)
                {
                    //_repository.CreateUser(sef.Staff.UserName, sef.Staff.Login, sef.Staff.Password, (RoleEnum) sef.Staff.Role);
                    //_gridStaff.Refresh();
                }
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            //_repository.User.Load();
            //_gridStaff.Refresh();
        }
    }
}
