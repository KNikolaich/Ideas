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
        private ContextAdapter _repository;

        public StaffsForm()
        {
            InitializeComponent();
        }

        private void StaffsForm_Load(object sender, EventArgs e)
        {
            _repository = new ContextAdapter();
            //gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None; // пока отклдючено, не работает
            RefreshData();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _repository.Update();
            base.OnClosing(e);
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Row is DataRowView drw)
            {
                _repository.SetAndUpdateUser(drw, e.RowHandle < 0);
            }
            RefreshData();
        }

        private void RefreshData()
        {
            gridControl1.DataSource = _repository.GetDataTableUser();
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
