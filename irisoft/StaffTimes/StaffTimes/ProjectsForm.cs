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
        private StaffTimesContainer _repository;

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
            _repository = new StaffTimesContainer();
            RefreshData();
        }

        private void RefreshData()
        {
            var fields = new List<string> {"Id", "ProjectName", "Description"};
            gridControl1.DataSource = _repository.GetDataTable(fields, "Project");
        }


        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRowView drw = e.Row as DataRowView;
            if (drw != null)
            {
                Type targerType = typeof(Project);

                if (e.RowHandle < 0)
                {
                    //var targetObj = ((System.Data.Entity.Infrastructure.IObjectContextAdapter) _repository).ObjectContext.CreateObject<Project>();
                    //var target = new Project();
                    var targetObj = _repository.Project.Create();
                    SetValues(targerType, drw, targetObj);
                    _repository.Project.Add(targetObj);
                    _repository.SaveChanges();
                }
                else
                {

                    int i = (int)drw["Id"];
                    var pEditable = _repository.Project.FirstOrDefault(p => p.Id ==  i);
                    SetValues(targerType, drw, pEditable);
                    _repository.SaveChanges();
                }
                //_repository.SaveDataTable(drw.Row.Table);



                //_repository.Configuration.AutoDetectChangesEnabled  = true;
                //_repository.ChangeTracker.DetectChanges();
                //_repository.Entry(targetObj).State;
                RefreshData();

            }
            //var row = gridView1.GetDataRow(e.RowHandle);

            //_repository.SaveChanges();
        }

        private static void SetValues(Type targerType, DataRowView drw, Project targetObj)
        {
            foreach (var property in targerType.GetProperties())
            {
                if (drw.Row.Table.Columns.Contains(property.Name))
                {
                    var value = drw[property.Name];
                    if(value != DBNull.Value)
                        property.SetValue(targetObj, value); 
                }
            }
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
