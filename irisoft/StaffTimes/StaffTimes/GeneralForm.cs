using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Core.Model;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace StaffTimes
{
    public partial class GeneralForm : Form
    {
        private readonly GeneralFormFinder _finder = new GeneralFormFinder();
        private ContextAdapter _contextDb;
        private FormatConditionRuleValue _formatConditionRuleValue1;
        private GridFormatRule _gridFormatRule5;

        public GeneralForm()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                GetAboutForm();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private static void GetAboutForm()
        {
            using (var about = new AboutBox())
            {
                about.ShowDialog();
            }
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
            GridGroupSummaryItem summaryItem = new GridGroupSummaryItem
            {
                FieldName = colDuration.FieldName,
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = @"{0}",
                ShowInGroupColumnFooter = colDuration
            };
            gridTaskView.GroupSummary.Add(summaryItem);

           
            showAllStaffToolStripMenuItem.CheckState = CheckState.Unchecked;

            showAllStaffToolStripMenuItem.Visible = _finder.IsAdmin;
            _nsiTsmi.Visible = _finder.IsAdmin;

            _projRepositoryItemLookUpEdit.DataSource = _contextDb.GetDataTableProjects(_finder.ProjectIds.ToArray());
            _usersRepositoryItem.DataSource = _contextDb.GetDataTableUser(true);
            //_projCheckedListBoxControl.DataSource = GenerateProjList();

            //this.layoutViewField_layoutViewColumn1
            RefreshGridDataSource();
        }

        private void RefreshGridDataSource()
        {
            _finder.StartDate = _dateNavigator.SelectionStart;
            _finder.EndDate = _dateNavigator.SelectionEnd;
            _finder.ShowAllUsers = showAllStaffToolStripMenuItem.CheckState == CheckState.Checked;
            _projRepositoryItemLookUpEdit.DataSource =
                _contextDb.GetDataTableProjects(); // загружаем все для отображения
            var userId = _finder.IsAdmin && _finder.ShowAllUsers ? -1 : _finder.UserId;
            gridTaskControl.DataSource = _contextDb.GetDataTableTasks(userId, _finder.StartDate, _finder.EndDate);
            gridTaskView.ExpandAllGroups();

            SetProjectIds();
            _projRepositoryItemLookUpEdit.DataSource =
                _contextDb.GetDataTableProjects(_finder.ProjectIds.ToArray()); // загружаем только фильтрованные
        }

        private void InitDateNavigator()
        {
            //            _dateNavigator.TodayButton.Text = "Сегодня";
            //            _dateNavigator.TodayButton.PerformClick();

            /*foreach (var dateTime in dtList.OrderBy(dt=>dt.DayOfYear))
            {
                _dateNavigator.Selection.Add(dateTime);
            }*/
            SetLockedDate();
            _dateNavigator.DateTime = DateTime.Today;
            _dateNavigator.HotDate = DateTime.Today;
            _dateNavigator.SetSelection(_finder.StartDate, _finder.EndDate);
        }

        private void SetLockedDate()
        {
            var dateOfLock = _finder.GetDateOfLock(true);
            if (dateOfLock != null)
            {
                _repositoryItemDateEdit.MinValue = dateOfLock.Value;
                if (!gridTaskView.FormatRules.Contains(_gridFormatRule5))
                {
                    _formatConditionRuleValue1 =
                    new FormatConditionRuleValue
                    {
                        Condition = FormatCondition.LessOrEqual,
                        Value1 = dateOfLock
                    };
                    _formatConditionRuleValue1.Appearance.BackColor = Color.LightGray;
                    //formatConditionRuleValue1.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("resource.ForeColor3")));
                    _formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
                    _formatConditionRuleValue1.Appearance.Options.UseForeColor = true;

                    _gridFormatRule5 = new GridFormatRule
                    {
                        Column = colDate,
                        Name = "FormatLock",
                        ApplyToRow = true,
                        Rule = _formatConditionRuleValue1
                    };
                    gridTaskView.FormatRules.Add(_gridFormatRule5);
                }
                else
                {
                    _formatConditionRuleValue1.Value1 = dateOfLock;
                }

            }
        }


        private void GeneralForm_Load(object sender, EventArgs e)
        {
            using (LoginForm logForm = new LoginForm())
            {
                if (logForm.ShowDialog() == DialogResult.OK)
                {
                    _finder.CurrentUser = logForm.GetUser();
                    Text += @" - " + _finder.CurrentUser;
                }
                else
                {
                    Hide();
                    Close();
                }
            }
        }

        private void _dateNavigator_Validated(object sender, EventArgs e)
        {
            // тут срабатывает не во-время
        }


        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dataRow = gridTaskView.GetDataRow(e.RowHandle);

            if (dataRow["Userid"] == DBNull.Value)
                dataRow["Userid"] = _finder.UserId;

            var idUser = (int) dataRow["Userid"];
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
                //e.Valid = _contextDb.GreateOrUpdateRow<Task>(drw, e.RowHandle < 0);
            }
            //RefreshGridDataSource();
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
            gridTaskControl.ExportToXlsx(filePath);
            System.Diagnostics.Process.Start(filePath);
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gridTaskView.ActiveEditor == null)
            {
                var focusedRow = gridTaskView.GetFocusedDataRow();

                if (focusedRow != null && MessageBox.Show("Удалить строку?", "Удаление записи о работе.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            gridTaskControl.ShowPrintPreview();
        }

        private void lockDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LockDateEditForm dateEditForm = new LockDateEditForm())
            {
                if (dateEditForm.ShowDialog() == DialogResult.OK)
                    SetLockedDate();
            }
        }

        private void GridTaskView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var dateOfLock = _finder.GetDateOfLock();
            if (dateOfLock != null && e.RowHandle >= 0)
            {
                bool rowIsReadOnly = false;
                if (gridTaskView.GetRow(e.RowHandle) is DataRowView rowDrowing) // Удаляем строку
                {
                    var dateTime = rowDrowing["Date"];
                    var date = Convert.ToDateTime(dateTime);
                    rowIsReadOnly = date <= dateOfLock;
                    if (rowIsReadOnly)
                    {
                       /* e.Appearance.BackColor = Color.LightGray;
                        e.Appearance.BackColor2 = Color.LightGray;
                        gridTaskView.RefreshRow(e.RowHandle);*/
                    }
                }

                _finder.SetReadOnlyRowHandle(e.RowHandle, rowIsReadOnly);
            }
        }

        private void gridTaskView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = true;
            if (gridTaskView.FocusedColumn.FieldName == "Duration")
            {
                if (e.Value != null)
                {
                    if (int.TryParse(e.Value.ToString(), out int value))
                    {
                        if (value <= 0 || value > 8)
                        {
                            e.Valid = false;
                        }
                    }
                    if (!e.Valid)
                    {
                        e.ErrorText = "Длительность задачи не может превышать 8 часов в день.";
                    }
                }
            }

        }

        private void gridTaskView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = _finder.FocusedRowIsReadOnly(gridTaskView.FocusedRowHandle);
        }

    }
}