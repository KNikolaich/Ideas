using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core.Model;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using StaffTimes.SubControls;

namespace StaffTimes
{
    public partial class GeneralForm : Form
    {
        private readonly GeneralFormFinder _finder = new GeneralFormFinder();
        
        public GeneralForm()
        {
            InitializeComponent();
        }


        #region Загрузка

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_finder.CurrentUser != null) // если на входе отказались от идеи запускать ПО
            {
                if (_finder.IsAdmin)
                {
                    ContextMenu = null;
                }

                InitRowStyles();
                InitDateNavigator();
                InitDateSource();

            }

            
            //var days = _contextDb.Day.Where(w => w.UserId == _user.Id).ToList();
            //var source = days.Select(w=> new {w.Id, w.Approved, w.Date, w.Status} ).ToList();
            //_gridDays.DataSource = source;
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            using (LoginForm logForm = new LoginForm())
            {
                if (logForm.ShowDialog() == DialogResult.OK)
                {
                    _finder.CurrentUser = logForm.GetUser();
                    Text += @" - " + _finder.CurrentUser;
                    _tsmiVersion.Text += AboutBox.AssemblyVersion;
                }
                else
                {
                    Hide();
                    Close();
                }
            }
        }

        #endregion

        #region Инициализация

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

            var dataTable = _finder.GetDataTableTasks();
            gridTaskControl.DataSource = dataTable;
            gridTaskView.ExpandAllGroups();

            _repositoryItemDateEdit.MinValue = _finder.GetMinData();
            _repositoryItemDateEdit.MaxValue = _finder.EndDate;

            _finder.RecalcActiveProjects();
            
            //_projRepositoryItemLookUpEdit.DataSource = _finder.GetDataTableProjects(); // загружаем только фильтрованные
            _labelTop.Text = _finder.ToString();

            _summaryGrid.SetDataSource(_finder, dataTable);
        }

        private void InitDateNavigator()
        {
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
                _repositoryItemDateEdit.MinValue = _finder.GetMinData();
            }
        }

        private void InitRowStyles()
        {
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.ReadOnly | StateTaskEnum.LessThenNecessary, Color.PaleGoldenrod));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.ReadOnly | StateTaskEnum.Normal, Color.LightGreen));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.ReadOnly | StateTaskEnum.MoreThenNecessary, Color.Pink));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.LessThenNecessary, Color.LightYellow));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.Normal, Color.PaleGreen));
            gridTaskView.FormatRules.Add(GetFormatRule(StateTaskEnum.MoreThenNecessary, Color.LightPink));
        }

        #endregion

        private GridFormatRule GetFormatRule(StateTaskEnum stateTaskEnum, Color backColor)
        {
            var conditionRuleValue = new FormatConditionRuleValue
            {
                Condition = FormatCondition.Equal,
                Value1 = stateTaskEnum
            };

            if (stateTaskEnum.HasFlag(StateTaskEnum.ReadOnly))
            {
                conditionRuleValue.Appearance.Font = new Font(conditionRuleValue.Appearance.Font, FontStyle.Italic | FontStyle.Bold);
                conditionRuleValue.Appearance.ForeColor = Color.SlateGray;
            }
            conditionRuleValue.Appearance.BackColor = backColor;
            
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


        #region События грида

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dataRow = gridTaskView.GetDataRow(e.RowHandle);

            if (dataRow["Userid"] == DBNull.Value)
                dataRow["Userid"] = _finder.UserId;

//            var idUser = (int) dataRow["Userid"];
            Tuple<DateTime, int> newDateDurat = _finder.CalcNewDate((DataTable)gridTaskControl.DataSource);

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
            //var dataTable = (DataTable)gridTaskControl.DataSource;
            // _finder.RecalcStatesTask(dataTable);
            //gridTaskControl.DataSource = dataTable;
            RefreshGridDataSource();
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
                            e.ErrorText = "Длительность задачи не может быть меньше 1 часа в день.";
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
                e.Cancel = rowDrowing["StateTask"] != DBNull.Value && ((StateTaskEnum) rowDrowing["StateTask"]).HasFlag(StateTaskEnum.ReadOnly);
            }
        }

        private void _projRepositoryItemLookUpEdit_BeforePopup(object sender, EventArgs e)
        {
            _finder.FiltredDataTableProjects((DataTable) _projRepositoryItemLookUpEdit.DataSource); 
        }

        private void _projRepositoryItemLookUpEdit_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            _finder.FiltredDataTableProjects((DataTable)_projRepositoryItemLookUpEdit.DataSource, true);
        }

        #endregion

        #region События менюшек и кнопок

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = Guid.NewGuid() + ".xlsx";
            gridTaskControl.ExportToXlsx(filePath);
            System.Diagnostics.Process.Start(filePath);
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StaffsForm sf = new StaffsForm())
            {
                sf.ShowDialog();
                RefreshGridDataSource();
            }
        }

        private void activeProjSettingsTsmi_Click(object sender, EventArgs e)
        {
            using (ActiveProjectsEditForm acProjForm = new ActiveProjectsEditForm(_finder.CurrentUser))
            {
                acProjForm.ShowDialog();
                RefreshGridDataSource();
            }
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProjectsForm pf = new ProjectsForm())
            {
                pf.ShowDialog();
                RefreshGridDataSource();
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
                {
                    SetLockedDate();
                    RefreshGridDataSource();
                }
            }
        }

        private void showAllStaffToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            RefreshGridDataSource();
        }

        private void _exitTsmi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _tsmiAbout2_Click(object sender, EventArgs e)
        {
            GetAboutForm();
        }

        private void _sButtonFind_Click(object sender, EventArgs e)
        {
            RefreshGridDataSource();
        }

        private void _tsmiDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = gridTaskView.GetSelectedRows();
            if (selectedRows.Length == 0)
            {
                MessageBox.Show("Нет выделенных строк.", "Удаление записи о работе.", MessageBoxButtons.OK);


            }
            else
            {

                var dateOfLock = _finder.GetDateOfLock();
                Dictionary<int, string> dictDels= new Dictionary<int, string>();
                foreach (var rowHandle in selectedRows)
                {
                    var delRow = gridTaskView.GetRow(rowHandle) as DataRowView;
                    if (delRow != null)
                    {
                        var dateTime = Convert.ToDateTime(delRow["Date"]);
                        
                        var strDelRow =$"Работа сотрудника {dateTime.ToString(_finder.FormatDate)} на {delRow["Duration"]}ч. {Environment.NewLine}";
                        dictDels.Add((int) delRow["id"], strDelRow);
                        if (dateOfLock.HasValue && dateTime <= dateOfLock)
                        {
                            MessageBox.Show("Удаление записей за границей даты блокировки запрещено.",
                                $"Невозможно удалить запись от {dateTime.ToString(_finder.FormatDate)}.", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }

                string collection = dictDels.Values.Aggregate("", (s, s1) => s + s1);
                if (MessageBox.Show(collection, "Удаление записи о работе.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    // Удаляем строку
                {
                    foreach (int id in dictDels.Keys)
                    {
                        _finder.DeleteTask(id);
                    }
                    //var dt = gridTaskControl.DataSource as DataTable;
                    //dt.remo
                    //gridTaskView.RefreshData();
                    RefreshGridDataSource();
                }
            }
            
        }

        private void _tsmiChangePassword_Click(object sender, EventArgs e)
        {
            using (ChangePasswordForm cpf = new ChangePasswordForm(_finder.CurrentUser.Id))
            {
                cpf.ShowDialog();
            }
        }

        #endregion

        private static void GetAboutForm()
        {
            using (var about = new AboutBox())
            {
                about.ShowDialog();
            }
        }
    }
}