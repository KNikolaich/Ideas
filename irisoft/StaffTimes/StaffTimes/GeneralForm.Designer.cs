namespace StaffTimes
{
    partial class GeneralForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralForm));
            this.panelLeft = new System.Windows.Forms.Panel();
            this._groupBoxFinder = new System.Windows.Forms.GroupBox();
            this._dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.panelButtom = new System.Windows.Forms.Panel();
            this._sButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._topTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.activeProjSettingsTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._exitTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this._nsiTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridTaskControl = new DevExpress.XtraGrid.GridControl();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridTaskView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this._usersRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this._repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this._projRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.DateCol = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.durationCol = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.projectCol = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLeft.SuspendLayout();
            this._groupBoxFinder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dateNavigator.CalendarTimeProperties)).BeginInit();
            this.panelButtom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaskControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaskView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._usersRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._repositoryItemDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._repositoryItemDateEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._projRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this._groupBoxFinder);
            this.panelLeft.Controls.Add(this.panelButtom);
            this.panelLeft.Controls.Add(this.menuStrip1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(3);
            this.panelLeft.Size = new System.Drawing.Size(257, 531);
            this.panelLeft.TabIndex = 2;
            // 
            // _groupBoxFinder
            // 
            this._groupBoxFinder.Controls.Add(this._dateNavigator);
            this._groupBoxFinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxFinder.Location = new System.Drawing.Point(3, 27);
            this._groupBoxFinder.Name = "_groupBoxFinder";
            this._groupBoxFinder.Size = new System.Drawing.Size(251, 469);
            this._groupBoxFinder.TabIndex = 5;
            this._groupBoxFinder.TabStop = false;
            this._groupBoxFinder.Text = "Диапазона дат для отображения:";
            // 
            // _dateNavigator
            // 
            this._dateNavigator.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._dateNavigator.CellPadding = new System.Windows.Forms.Padding(1);
            this._dateNavigator.DateTime = new System.DateTime(((long)(0)));
            this._dateNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dateNavigator.EditValue = new System.DateTime(((long)(0)));
            this._dateNavigator.FirstDayOfWeek = System.DayOfWeek.Monday;
            this._dateNavigator.Location = new System.Drawing.Point(3, 16);
            this._dateNavigator.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this._dateNavigator.Name = "_dateNavigator";
            this._dateNavigator.NavigationMode = DevExpress.XtraScheduler.DateNavigationMode.ScrollCalendar;
            this._dateNavigator.Padding = new System.Windows.Forms.Padding(5);
            this._dateNavigator.Size = new System.Drawing.Size(245, 450);
            this._dateNavigator.TabIndex = 1;
            this._dateNavigator.ToolTip = "Выбор дат для отображения данных";
            this._dateNavigator.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFourDayWeek;
            this._dateNavigator.Validated += new System.EventHandler(this._dateNavigator_Validated);
            // 
            // panelButtom
            // 
            this.panelButtom.Controls.Add(this._sButtonFind);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtom.Location = new System.Drawing.Point(3, 496);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Padding = new System.Windows.Forms.Padding(3);
            this.panelButtom.Size = new System.Drawing.Size(251, 32);
            this.panelButtom.TabIndex = 4;
            // 
            // _sButtonFind
            // 
            this._sButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this._sButtonFind.Location = new System.Drawing.Point(136, 3);
            this._sButtonFind.Name = "_sButtonFind";
            this._sButtonFind.Size = new System.Drawing.Size(112, 26);
            this._sButtonFind.TabIndex = 3;
            this._sButtonFind.Text = "Выбрать";
            this._sButtonFind.ToolTip = "из диапазона дат";
            this._sButtonFind.ToolTipTitle = "Отобрать данные";
            this._sButtonFind.Click += new System.EventHandler(this._sButtonFind_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._topTsmi,
            this._nsiTsmi,
            this._reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(251, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _topTsmi
            // 
            this._topTsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeProjSettingsTsmi,
            this.showAllStaffToolStripMenuItem,
            this.toolStripSeparator1,
            this._exitTsmi});
            this._topTsmi.Name = "_topTsmi";
            this._topTsmi.Size = new System.Drawing.Size(55, 20);
            this._topTsmi.Text = "Меню";
            // 
            // activeProjSettingsTsmi
            // 
            this.activeProjSettingsTsmi.Name = "activeProjSettingsTsmi";
            this.activeProjSettingsTsmi.Size = new System.Drawing.Size(250, 22);
            this.activeProjSettingsTsmi.Text = "Настройка своих проектов...";
            this.activeProjSettingsTsmi.ToolTipText = "Позволяет настроить те проекты, \r\nкоторые будут выбираться в выпадающем списке\r\nв" +
    " таблице, когда мы добавляем новую строку работ.";
            this.activeProjSettingsTsmi.Click += new System.EventHandler(this.activeProjSettingsTsmi_Click);
            // 
            // showAllStaffToolStripMenuItem
            // 
            this.showAllStaffToolStripMenuItem.Checked = true;
            this.showAllStaffToolStripMenuItem.CheckOnClick = true;
            this.showAllStaffToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAllStaffToolStripMenuItem.Name = "showAllStaffToolStripMenuItem";
            this.showAllStaffToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.showAllStaffToolStripMenuItem.Text = "Показывать всех сотрудников";
            this.showAllStaffToolStripMenuItem.ToolTipText = "Отображение не только собственного времени в результатах поиска";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(247, 6);
            // 
            // _exitTsmi
            // 
            this._exitTsmi.Name = "_exitTsmi";
            this._exitTsmi.Size = new System.Drawing.Size(250, 22);
            this._exitTsmi.Text = "Выход";
            this._exitTsmi.ToolTipText = "Закрыть приложение";
            this._exitTsmi.Click += new System.EventHandler(this._exitTsmi_Click);
            // 
            // _nsiTsmi
            // 
            this._nsiTsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffToolStripMenuItem,
            this.projectsToolStripMenuItem,
            this.lockDateToolStripMenuItem});
            this._nsiTsmi.Name = "_nsiTsmi";
            this._nsiTsmi.Size = new System.Drawing.Size(97, 20);
            this._nsiTsmi.Text = "Справочники";
            this._nsiTsmi.ToolTipText = "Отображается только для администратора";
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.staffToolStripMenuItem.Text = "Сотрудники...";
            this.staffToolStripMenuItem.Click += new System.EventHandler(this.staffToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.projectsToolStripMenuItem.Text = "Проекты...";
            this.projectsToolStripMenuItem.Click += new System.EventHandler(this.projectsToolStripMenuItem_Click);
            // 
            // lockDateToolStripMenuItem
            // 
            this.lockDateToolStripMenuItem.Name = "lockDateToolStripMenuItem";
            this.lockDateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lockDateToolStripMenuItem.Text = "Дата блокировки";
            this.lockDateToolStripMenuItem.Click += new System.EventHandler(this.lockDateToolStripMenuItem_Click);
            // 
            // _reportsToolStripMenuItem
            // 
            this._reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.printToolStripMenuItem});
            this._reportsToolStripMenuItem.Name = "_reportsToolStripMenuItem";
            this._reportsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this._reportsToolStripMenuItem.Text = "Отчеты";
            this._reportsToolStripMenuItem.ToolTipText = "выгрузки данных в...";
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToExcelToolStripMenuItem.Text = "Экспорт в Excel...";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printToolStripMenuItem.Text = "Печать..";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // gridTaskControl
            // 
            this.gridTaskControl.DataSource = this.taskBindingSource;
            this.gridTaskControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTaskControl.Location = new System.Drawing.Point(3, 3);
            this.gridTaskControl.MainView = this.gridTaskView;
            this.gridTaskControl.Name = "gridTaskControl";
            this.gridTaskControl.Padding = new System.Windows.Forms.Padding(5);
            this.gridTaskControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this._projRepositoryItemLookUpEdit,
            this._usersRepositoryItem,
            this._repositoryItemDateEdit});
            this.gridTaskControl.Size = new System.Drawing.Size(743, 525);
            this.gridTaskControl.TabIndex = 0;
            this.gridTaskControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridTaskView,
            this.layoutView1});
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataSource = typeof(Core.Task);
            // 
            // gridTaskView
            // 
            this.gridTaskView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser,
            this.colDate,
            this.colDuration,
            this.colProject,
            this.colComment});
            this.gridTaskView.GridControl = this.gridTaskControl;
            this.gridTaskView.GroupCount = 1;
            this.gridTaskView.GroupFormat = " [#image]{1} {2}";
            this.gridTaskView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", this.colDate, "")});
            this.gridTaskView.Name = "gridTaskView";
            this.gridTaskView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridTaskView.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridTaskView.OptionsView.ShowGroupedColumns = true;
            this.gridTaskView.OptionsView.ShowGroupPanel = false;
            this.gridTaskView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUser, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridTaskView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GridTaskView_RowStyle);
            this.gridTaskView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridTaskView_ShowingEditor);
            this.gridTaskView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridTaskView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridTaskView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyUp);
            this.gridTaskView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridTaskView_ValidatingEditor);
            // 
            // colUser
            // 
            this.colUser.Caption = "Сотрудник";
            this.colUser.ColumnEdit = this._usersRepositoryItem;
            this.colUser.FieldName = "UserId";
            this.colUser.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUser.Name = "colUser";
            this.colUser.Width = 129;
            // 
            // _usersRepositoryItem
            // 
            this._usersRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._usersRepositoryItem.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "Сотрудник")});
            this._usersRepositoryItem.DisplayMember = "UserName";
            this._usersRepositoryItem.Name = "_usersRepositoryItem";
            this._usersRepositoryItem.NullText = "";
            this._usersRepositoryItem.ShowFooter = false;
            this._usersRepositoryItem.ValueMember = "UserId";
            // 
            // colDate
            // 
            this.colDate.Caption = "Дата";
            this.colDate.ColumnEdit = this._repositoryItemDateEdit;
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 100;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 100;
            // 
            // _repositoryItemDateEdit
            // 
            this._repositoryItemDateEdit.AutoHeight = false;
            this._repositoryItemDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._repositoryItemDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._repositoryItemDateEdit.Name = "_repositoryItemDateEdit";
            // 
            // colDuration
            // 
            this.colDuration.Caption = "Длительность";
            this.colDuration.FieldName = "Duration";
            this.colDuration.MaxWidth = 100;
            this.colDuration.Name = "colDuration";
            this.colDuration.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDuration.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Duration", "Сумма: {0}")});
            this.colDuration.Visible = true;
            this.colDuration.VisibleIndex = 2;
            this.colDuration.Width = 100;
            // 
            // colProject
            // 
            this.colProject.Caption = "Проект";
            this.colProject.ColumnEdit = this._projRepositoryItemLookUpEdit;
            this.colProject.FieldName = "ProjectId";
            this.colProject.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colProject.Name = "colProject";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 0;
            this.colProject.Width = 307;
            // 
            // _projRepositoryItemLookUpEdit
            // 
            this._projRepositoryItemLookUpEdit.AutoHeight = false;
            this._projRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._projRepositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProjectName", "Проект", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this._projRepositoryItemLookUpEdit.DisplayMember = "ProjectName";
            this._projRepositoryItemLookUpEdit.Name = "_projRepositoryItemLookUpEdit";
            this._projRepositoryItemLookUpEdit.NullText = "";
            this._projRepositoryItemLookUpEdit.NullValuePrompt = "необходимо заполнить";
            this._projRepositoryItemLookUpEdit.NullValuePromptShowForEmptyValue = true;
            this._projRepositoryItemLookUpEdit.ValueMember = "ProjectId";
            // 
            // colComment
            // 
            this.colComment.Caption = "Комментарий";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 3;
            this.colComment.Width = 237;
            // 
            // layoutView1
            // 
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.DateCol,
            this.durationCol,
            this.projectCol});
            this.layoutView1.GridControl = this.gridTaskControl;
            this.layoutView1.GroupCount = 1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.DateCol, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // DateCol
            // 
            this.DateCol.Caption = "Дата";
            this.DateCol.FieldName = "Date";
            this.DateCol.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.DateCol.Name = "DateCol";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(115, 20);
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(77, 13);
            // 
            // durationCol
            // 
            this.durationCol.Caption = "Длительность";
            this.durationCol.FieldName = "Duration";
            this.durationCol.LayoutViewField = this.layoutViewField_layoutViewColumn2;
            this.durationCol.Name = "durationCol";
            // 
            // layoutViewField_layoutViewColumn2
            // 
            this.layoutViewField_layoutViewColumn2.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn2.Location = new System.Drawing.Point(0, 20);
            this.layoutViewField_layoutViewColumn2.Name = "layoutViewField_layoutViewColumn2";
            this.layoutViewField_layoutViewColumn2.Size = new System.Drawing.Size(115, 20);
            this.layoutViewField_layoutViewColumn2.TextSize = new System.Drawing.Size(77, 13);
            // 
            // projectCol
            // 
            this.projectCol.Caption = "Проект";
            this.projectCol.FieldName = "Project";
            this.projectCol.LayoutViewField = this.layoutViewField_layoutViewColumn3;
            this.projectCol.Name = "projectCol";
            // 
            // layoutViewField_layoutViewColumn3
            // 
            this.layoutViewField_layoutViewColumn3.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn3.Location = new System.Drawing.Point(0, 40);
            this.layoutViewField_layoutViewColumn3.Name = "layoutViewField_layoutViewColumn3";
            this.layoutViewField_layoutViewColumn3.Size = new System.Drawing.Size(115, 20);
            this.layoutViewField_layoutViewColumn3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn2,
            this.layoutViewField_layoutViewColumn3});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(Core.Project);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridTaskControl);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 531);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 4;
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 531);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GeneralForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет времени";
            this.Load += new System.EventHandler(this.GeneralForm_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this._groupBoxFinder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dateNavigator.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dateNavigator)).EndInit();
            this.panelButtom.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaskControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaskView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._usersRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._repositoryItemDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._repositoryItemDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._projRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLeft;
        private DevExpress.XtraGrid.GridControl gridTaskControl;
        private DevExpress.XtraScheduler.DateNavigator _dateNavigator;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn DateCol;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn durationCol;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn projectCol;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridTaskView;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit _projRepositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit _usersRepositoryItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _topTsmi;
        private System.Windows.Forms.ToolStripMenuItem showAllStaffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _nsiTsmi;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _exitTsmi;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelButtom;
        private DevExpress.XtraEditors.SimpleButton _sButtonFind;
        private System.Windows.Forms.ToolStripMenuItem _reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.GroupBox _groupBoxFinder;
        private System.Windows.Forms.ToolStripMenuItem activeProjSettingsTsmi;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockDateToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit _repositoryItemDateEdit;
    }
}

