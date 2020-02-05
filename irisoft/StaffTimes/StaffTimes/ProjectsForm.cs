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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace StaffTimes
{
    public partial class ProjectsForm : Form
    {
        private ContextAdapter _repository;

        public ProjectsForm()
        {
            InitializeComponent();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var row = gridView1.GetDataRow(e.RowHandle);
            //row//
        }

        private void ProjectsForm_Load(object sender, EventArgs e)
        {

            _repository = new ContextAdapter();
            RefreshData();
        }

        private void RefreshData()
        {
            gridControl1.DataSource = _repository.GetDataTableProjects();
        }



        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Row is DataRowView drw)
            {
                _repository.SetAndUpdateProject(drw, e.RowHandle < 0);
            }
            RefreshData();

            //var row = gridView1.GetDataRow(e.RowHandle);

            //_repository.SaveChanges();
        }


        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            /*var row = gridView1.GetDataRow(e.RowHandle);
            if (e.RowHandle < 0)
            {
                gridView1.AddNewRow();
            }*/
            //
            //_repository.Project.Create();


        }
    }
}
