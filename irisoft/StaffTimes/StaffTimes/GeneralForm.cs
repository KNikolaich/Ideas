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
            if (_finder.IsAdmin)
            {
                ContextMenu = null;
            }

            InitRowStyles();
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
            if (!_finder.IsAdmin)
            {
                colUser.Visible = false;
                colUser.UnGroup();
                gridTaskView.Columns.Remove(colUser);
            }
            _nsiTsmi.Visible = _finder.IsAdmin;

            _projRepositoryItemLookUpEdit.DataSource = _finder.GetDataTableProjects();
            _usersRepositoryItem.DataSource = _finder.GetDataTableUser();
            //_projCheckedListBoxControl.DataSource = GenerateProjList();

            //this.layoutViewField_layoutViewColumn1
            RefreshGridDataSource();
        }

        private void RefreshGridDataSource()
        {
            _finder.StartDate = _dateNavigator.SelectionStart;
            _finder.EndDate = _dateNavigator.SelectionEnd;
            _finder.ShowAllUsers = showAllStaffToolStripMenuItem.CheckState == CheckState.Checked;
            _projRepositoryItemLookUpEdit.DataSource = _finder.GetDataTableProjects(true); // загружаем все для отображения
            
            gridTaskControl.DataSource = _finder.GetDataTableTasks();
            gridTaskView.ExpandAllGroups();

            SetProjectIds();
            _projRepositoryItemLookUpEdit.DataSource =
                _finder.GetDataTableProjects(); // загружаем только фильтрованные
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
            }
        }

        private void InitRowStyles()
        {
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.ReadOnly, Color.LightGray));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.LessThenNecessary, Color.AliceBlue));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.Normal, Color.PaleGreen));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.MoreThenNecessary, Color.LightPink));
        }

        private GridFormatRule GetFormatRule(StateTaskEnum stateTaskEnum, Color backColor)
        {
            var conditionRuleValue = new FormatConditionRuleValue
            {
                Condition = FormatCondition.Equal,
                Value1 = stateTaskEnum
            };

            conditionRuleValue.Appearance.BackColor = backColor;
            //formatConditionRuleValue1.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("resource.ForeColor3")));
            conditionRuleValue.Appearance.Options.UseBackColor = true;
            conditionRuleValue.Appearance.Options.UseForeColor = true;

            var formatRule = new GridFormatRule
            {
                Column = colState,
                Name = stateTaskEnum.ToString(),
                ApplyToRow = true,
                Rule = conditionRuleValue
            };
            return formatRule;
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


        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            if (e.Row is DataRowView drw)
            {
                e.Valid = _finder.ValidateTask(drw, e.RowHandle < 0);
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

                    _finder.DeleteTask((int) focusedRow["id"]);
                    //var dt = gridTaskControl.DataSource as DataTable;
                    //dt.remo
                    //gridTaskView.RefreshData();
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

        private void gridTaskView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = true;
            if (gridTaskView.FocusedColumn.FieldName == "Duration")
            {
                if (e.Value != null)
                {
                    if (int.TryParse(e.Value.ToString(), out int value))
                    {
                        if (value <= 0)
                        {
                            e.Valid = false;
                            e.ErrorText = "Длительность задачи не может мыть меньше 1 часа в день.";
                        }
                        else if (value > 8)
                        {
                            e.Valid = false;
                            e.ErrorText = "Длительность задачи не может превышать 8 часов в день.";
                        }
                    }
                }
            }

        }

        private void gridTaskView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var date = StateTaskEnum.TryParse(dateTime);
            if (gridTaskView.GetRow(gridTaskView.FocusedRowHandle) is DataRowView rowDrowing) // Удаляем строку
            {
                e.Cancel = (StateTaskEnum) rowDrowing["StateTask"] == StateTaskEnum.ReadOnly;
            }
        }

    }
}