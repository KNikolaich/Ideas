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
            this.panelTop = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmiProjects = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this._dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this._projRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this._projectRepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this._projectRepositoryItemView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.DateCol = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.durationCol = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.projectCol = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.panel1 = new System.Windows.Forms.Panel();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelTop.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._projRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._projectRepositoryItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._projectRepositoryItemView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.ContextMenuStrip = this.contextMenuStrip1;
            this.panelTop.Controls.Add(this._dateNavigator);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(5);
            this.panelTop.Size = new System.Drawing.Size(800, 174);
            this.panelTop.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiProjects,
            this._tsmiUsers});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 48);
            // 
            // _tsmiProjects
            // 
            this._tsmiProjects.Name = "_tsmiProjects";
            this._tsmiProjects.Size = new System.Drawing.Size(173, 22);
            this._tsmiProjects.Text = "Ведение проектов";
            this._tsmiProjects.Click += new System.EventHandler(this._tsmiProjects_Click);
            // 
            // _tsmiUsers
            // 
            this._tsmiUsers.Name = "_tsmiUsers";
            this._tsmiUsers.Size = new System.Drawing.Size(173, 22);
            this._tsmiUsers.Text = "Сотрудники";
            this._tsmiUsers.Click += new System.EventHandler(this._tsmiUsers_Click);
            // 
            // _dateNavigator
            // 
            this._dateNavigator.DateTime = new System.DateTime(((long)(0)));
            this._dateNavigator.HotDate = null;
            this._dateNavigator.Location = new System.Drawing.Point(5, 8);
            this._dateNavigator.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this._dateNavigator.Name = "_dateNavigator";
            this._dateNavigator.Padding = new System.Windows.Forms.Padding(5);
            this._dateNavigator.Size = new System.Drawing.Size(398, 166);
            this._dateNavigator.TabIndex = 0;
            this._dateNavigator.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFourDayWeek;
            this._dateNavigator.EditDateModified += new System.EventHandler(this._dateNavigator_EditDateModified);
            this._dateNavigator.Validated += new System.EventHandler(this._dateNavigator_Validated);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.taskBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(5, 5);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Padding = new System.Windows.Forms.Padding(5);
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this._projectRepositoryItem,
            this._projRepositoryItemLookUpEdit});
            this.gridControl1.Size = new System.Drawing.Size(790, 347);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.layoutView1});
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataSource = typeof(Core.Model.Task);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser,
            this.colDate,
            this.colDuration,
            this.colProject,
            this.colComment});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colUser
            // 
            this.colUser.Caption = "Сотрудник";
            this.colUser.FieldName = "UserName";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            // 
            // colDate
            // 
            this.colDate.Caption = "Дата";
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 100;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            // 
            // colDuration
            // 
            this.colDuration.Caption = "Длительность";
            this.colDuration.FieldName = "Duration";
            this.colDuration.MaxWidth = 100;
            this.colDuration.Name = "colDuration";
            this.colDuration.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Duration", "Сумма: {0}")});
            this.colDuration.Visible = true;
            this.colDuration.VisibleIndex = 3;
            // 
            // colProject
            // 
            this.colProject.Caption = "Проект";
            this.colProject.ColumnEdit = this._projRepositoryItemLookUpEdit;
            this.colProject.FieldName = "ProjectId";
            this.colProject.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colProject.Name = "colProject";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 2;
            // 
            // _projRepositoryItemLookUpEdit
            // 
            this._projRepositoryItemLookUpEdit.AutoHeight = false;
            this._projRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._projRepositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProjectName", "Проект", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this._projRepositoryItemLookUpEdit.DisplayMember = "ProjectName";
            this._projRepositoryItemLookUpEdit.Name = "_projRepositoryItemLookUpEdit";
            this._projRepositoryItemLookUpEdit.NullText = "необходимо заполнить";
            this._projRepositoryItemLookUpEdit.ValueMember = "ProjectId";
            // 
            // colComment
            // 
            this.colComment.Caption = "Комментарий";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 4;
            // 
            // _projectRepositoryItem
            // 
            this._projectRepositoryItem.AutoHeight = false;
            this._projectRepositoryItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._projectRepositoryItem.Name = "_projectRepositoryItem";
            this._projectRepositoryItem.NullText = "Выбераем проект";
            this._projectRepositoryItem.View = this._projectRepositoryItemView;
            // 
            // _projectRepositoryItemView
            // 
            this._projectRepositoryItemView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this._projectRepositoryItemView.Name = "_projectRepositoryItemView";
            this._projectRepositoryItemView.OptionsLayout.Columns.AddNewColumns = false;
            this._projectRepositoryItemView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._projectRepositoryItemView.OptionsView.ShowGroupPanel = false;
            // 
            // layoutView1
            // 
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.DateCol,
            this.durationCol,
            this.projectCol});
            this.layoutView1.GridControl = this.gridControl1;
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
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn2,
            this.layoutViewField_layoutViewColumn3});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 174);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(800, 357);
            this.panel1.TabIndex = 9;
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(Core.Model.Project);
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralForm";
            this.Text = "Учет времени";
            this.Load += new System.EventHandler(this.GeneralForm_Load);
            this.panelTop.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._projRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._projectRepositoryItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._projectRepositoryItemView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraGrid.GridControl gridControl1;
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
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit _projectRepositoryItem;
        private DevExpress.XtraGrid.Views.Grid.GridView _projectRepositoryItemView;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _tsmiProjects;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem _tsmiUsers;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit _projRepositoryItemLookUpEdit;
        private System.Windows.Forms.BindingSource projectBindingSource;
    }
}

