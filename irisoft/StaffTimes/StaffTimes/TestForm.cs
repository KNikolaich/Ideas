using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Model;

namespace StaffTimes
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            /* var _repository = new StaffTimesContainer();
             _repository.Project.F
             //MetaTable metaTable = _repository.GetTable("Your EntitySetName");
             var returnDataTable = ((IObjectContextAdapter)_repository).ObjectContext.ExecuteStoreQuery<DataTable>("Id", "ProjectName", "Description");
             //return returnDataTable;
             List<Project> pList = new List<Project>();
             pList.Add(new Project() { ProjectName = "Первый", Id = 1, Description = "Описание 1 " });
             pList.Add(new Project() { ProjectName = "Второй", Id = 2, Description = "Описание 2 " });
             pList.Add(new Project() { ProjectName = "Третий", Id = 3, Description = "Описание 3 " });
             DataTable dataTable= new DataTable("proj");
 
             dataTable.Load();*/
            //          dataTable.Columns.Add("ProjectName");
            //          dataTable.Columns.Add("Id", typeof(int));
            //            dataTable.Columns.Add("Description");
            //
            //            pList.ForEach(p => dataTable.Rows.Add(p));

            var table = new DataTable();
            using (var ctx = new StaffTimeDbContainer())
            {
                var cmd = ctx.Database.Connection.CreateCommand();
                cmd.CommandText = "Select Id, ProjectName,Description from Project";

                cmd.Connection.Open();
                table.Load(cmd.ExecuteReader());
            }
            gridControl1.DataSource = table;
        }
    }
}