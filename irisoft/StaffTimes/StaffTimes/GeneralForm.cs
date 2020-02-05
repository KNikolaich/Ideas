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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit.API.Word;

namespace StaffTimes
{
    public partial class GeneralForm : Form
    {
        private User _user;
        private ContextAdapter _contextDb;

        public GeneralForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _contextDb = new ContextAdapter(); 

            if (_user.Role != StaffRole.Admin)
            {
                ContextMenu = null;
            }
            InitDateNavigator();


            InitDateSource();
            //var days = _contextDb.Day.Where(w => w.UserId == _user.Id).ToList();
            //var source = days.Select(w=> new {w.Id, w.Approved, w.Date, w.Status} ).ToList();
            //_gridDays.DataSource = source;
        }

        private void InitDateSource()
        {
            _projRepositoryItemLookUpEdit.DataSource = _contextDb.GetDataTableProjects();
            _usersRepositoryItem.DataSource = _contextDb.GetDataTableUser(true);
            _projCheckedListBoxControl.DataSource = GenerateProjList();
            //rojectRepositoryItemView.Columns.Clear();

            //this.layoutViewField_layoutViewColumn1
            RefreshGridDataSource();
        }

        private List<CheckedListBoxItem> GenerateProjList()
        {
            List<CheckedListBoxItem> res = new List<CheckedListBoxItem>();
            var projects = _contextDb.GetSelectProjects();
            foreach (Project project in projects)
            {
                res.Add(new CheckedListBoxItem(project, CheckState.Unchecked));
            }
            return res;
        }

        private void RefreshGridDataSource()
        {
            var dtList = GetSelectDatesListOnInit();
            var userId = _user.Role == StaffRole.User ? _user.Id : -1;
            gridControl1.DataSource = _contextDb.GetDataTableTasks(userId, dtList.Min(), dtList.Max());
            gridView1.ExpandAllGroups();
        }

        private void InitDateNavigator()
        {
            _dateNavigator.TodayButton.Text = "Сегодня";
            _dateNavigator.TodayButton.PerformClick();
            
            /*foreach (var dateTime in dtList.OrderBy(dt=>dt.DayOfYear))
            {
                _dateNavigator.Selection.Add(dateTime);
            }*/

            _dateNavigator.DateTime = DateTime.Today;
            _dateNavigator.HotDate = DateTime.Today;
        }

        private static List<DateTime> GetSelectDatesListOnInit()
        {
            DateTime end = DateTime.Today.AddDays(1);
            DateTime start = DateTime.Today.AddDays(-7);
            DateTime? additionDateTime = end;
            List<DateTime> dtList = new List<DateTime>();
            while (additionDateTime != null)
            {
                dtList.Add(additionDateTime.Value);
                additionDateTime = additionDateTime.Value.AddDays(-1);
                if (additionDateTime <= start && additionDateTime.Value.DayOfWeek == DayOfWeek.Monday
                ) // гоним до понедельника прошлой неделеи
                {
                    additionDateTime = null;
                }
            }
            return dtList;
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



        private void _dateNavigator_EditDateModified(object sender, EventArgs e)
        {

        }

        private void _dateNavigator_Validated(object sender, EventArgs e)
        {
            // тут меняем условия запроса
        }


        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dataRow = gridView1.GetDataRow(e.RowHandle);

            if (dataRow["Userid"] == DBNull.Value)
                dataRow["Userid"] = _user.Id;

            if (dataRow["Duration"] == DBNull.Value)
                dataRow["Duration"] = 8;

            if (dataRow["Comment"] == DBNull.Value)
                dataRow["Comment"] = "";
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.Row is DataRowView drw)
            {
                _contextDb.SetAndUpdateTask(drw, e.RowHandle < 0);
            }
            RefreshGridDataSource();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StaffsForm sf = new StaffsForm())
            {
                sf.ShowDialog();
            }
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProjectsForm pf = new ProjectsForm())
            {
                pf.ShowDialog();
            }
        }

        private void _exitTsmi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _projCheckedListBoxControl_SelectedValueChanged(object sender, EventArgs e)
        {
            // смена чекбоксом массива проектов
        }
    }
}
