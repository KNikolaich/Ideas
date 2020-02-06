using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Model;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraRichEdit.API.Word;

namespace StaffTimes
{
    public partial class GeneralForm : Form
    {
        GeneralFormFinder _finder = new GeneralFormFinder();
        private ContextAdapter _contextDb;

        public GeneralForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _contextDb = new ContextAdapter();
            _finder.Db = _contextDb;
            if (_finder.IsAdmin)
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

            GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            item1.FieldName = colDuration.FieldName;
            item1.SummaryType = SummaryItemType.Sum;
            item1.DisplayFormat = "{0}";
            item1.ShowInGroupColumnFooter = colDuration;
            gridView1.GroupSummary.Add(item1);

            showAllStaffToolStripMenuItem.CheckState = CheckState.Unchecked;

            showAllStaffToolStripMenuItem.Visible = _finder.IsAdmin;
            _nsiTsmi.Visible = _finder.IsAdmin;

            _projRepositoryItemLookUpEdit.DataSource = _contextDb.GetDataTableProjects(_finder.ProjectIds.ToArray());
            _usersRepositoryItem.DataSource = _contextDb.GetDataTableUser(true);
            //_projCheckedListBoxControl.DataSource = GenerateProjList();

            //this.layoutViewField_layoutViewColumn1
            RefreshGridDataSource();
        }

        private List<CheckedListBoxItem> GenerateProjList()
        {
            List<CheckedListBoxItem> res = new List<CheckedListBoxItem>();
            var projects = _finder.GetSelectProjects();
            foreach (Project project in projects)
            {
                res.Add(new CheckedListBoxItem(project, CheckState.Unchecked));
            }
            return res;
        }

        private void RefreshGridDataSource()
        {

            _finder.ShowAllUsers = showAllStaffToolStripMenuItem.CheckState == CheckState.Checked;
            _finder.StartDate = _dateNavigator.SelectionStart;
            _finder.EndDate = _dateNavigator.SelectionEnd;

            _projRepositoryItemLookUpEdit.DataSource = _contextDb.GetDataTableProjects(); // загружаем все для отображения
            var userId = _finder.IsAdmin && _finder.ShowAllUsers ? -1 : _finder.UserId;
            gridControl1.DataSource = _contextDb.GetDataTableTasks(userId, _finder.StartDate, _finder.EndDate);
            gridView1.ExpandAllGroups();

            SetProjectIds();
            _projRepositoryItemLookUpEdit.DataSource = _contextDb.GetDataTableProjects(_finder.ProjectIds.ToArray()); // загружаем только фильтрованные
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


        private void GeneralForm_Load(object sender, EventArgs e)
        {
            using (LoginForm logForm = new LoginForm())
            {
                if (logForm.ShowDialog() == DialogResult.OK)
                {
                    _finder.CurrentUser = logForm.GetUser();
                    Text += (" - " + _finder.CurrentUser);
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
            // тут срабатывает не во-время
            
        }


        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dataRow = gridView1.GetDataRow(e.RowHandle);

            if (dataRow["Userid"] == DBNull.Value)
                dataRow["Userid"] = _finder.UserId;

            var idUser = (int)dataRow["Userid"];
            Tuple<DateTime, int> newDateDurat = _finder.CalcNewDate(idUser);

            if (dataRow["Date"] == DBNull.Value)
                dataRow["Date"] = newDateDurat.Item1;

            if (dataRow["Duration"] == DBNull.Value)
                dataRow["Duration"] = newDateDurat.Item2;

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
        
        private void SetProjectIds()
        {
            _finder.RecalcActiveProjects();
            
        }

        private void _sButtonFind_Click(object sender, EventArgs e)
        {
            RefreshGridDataSource();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = Guid.NewGuid() + ".xlsx";
            gridControl1.ExportToXlsx(filePath);
            System.Diagnostics.Process.Start(filePath);
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gridView1.ActiveEditor == null)
            {
                var focusedRow = gridView1.GetFocusedDataRow();
                
                if (MessageBox.Show("Удалить строку?", "Удаление записи и работе.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    // Удаляем строку
                {
                    _contextDb.Delete<Core.Task>((int) focusedRow["id"]);
                    RefreshGridDataSource();
                }

            }
        }

        private void activeProjSettingsTsmi_Click(object sender, EventArgs e)
        {
            using (ActiveProjectsEditForm acProjForm = new ActiveProjectsEditForm(_finder.CurrentUser))
            {
                acProjForm.ShowDialog();
                _finder.RecalcActiveProjects();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void lockDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LockDateEditForm dateEditForm = new LockDateEditForm())
            {
                if(dateEditForm.ShowDialog() == DialogResult.OK)
                    RefreshGridDataSource();
            }
        }
    }
}
