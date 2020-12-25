namespace Configuration.Controls
{
    partial class SettingEditControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingEditControl));
            this.dataGridFolders = new System.Windows.Forms.DataGridView();
            this._columnIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._columnFolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colBtnOpenFileDlg = new System.Windows.Forms.DataGridViewButtonColumn();
            this._columnSharedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gridHiddenControls = new Configuration.Controls.Editors.GridWithLabelControl();
            this.labelReplication = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiValidate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipGrid = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridFolders
            // 
            this.dataGridFolders.AllowUserToAddRows = false;
            this.dataGridFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnIsActive,
            this._columnFolderName,
            this._colBtnOpenFileDlg,
            this._columnSharedStatus});
            this.dataGridFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridFolders.Location = new System.Drawing.Point(126, 21);
            this.dataGridFolders.Name = "dataGridFolders";
            this.dataGridFolders.Size = new System.Drawing.Size(344, 325);
            this.dataGridFolders.TabIndex = 0;
            this.dataGridFolders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // _columnIsActive
            // 
            this._columnIsActive.DataPropertyName = "IsActive";
            this._columnIsActive.Frozen = true;
            this._columnIsActive.HeaderText = "Активен";
            this._columnIsActive.Name = "_columnIsActive";
            this._columnIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._columnIsActive.ToolTipText = "Можно на время деактивировать каталог";
            this._columnIsActive.Visible = false;
            // 
            // _columnFolderName
            // 
            this._columnFolderName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._columnFolderName.DataPropertyName = "FolderName";
            this._columnFolderName.FillWeight = 141.5094F;
            this._columnFolderName.HeaderText = "Путь к папке";
            this._columnFolderName.MinimumWidth = 200;
            this._columnFolderName.Name = "_columnFolderName";
            this._columnFolderName.ToolTipText = "Путь к папке для репликации";
            // 
            // _colBtnOpenFileDlg
            // 
            this._colBtnOpenFileDlg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this._colBtnOpenFileDlg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._colBtnOpenFileDlg.HeaderText = "Выбор";
            this._colBtnOpenFileDlg.MinimumWidth = 15;
            this._colBtnOpenFileDlg.Name = "_colBtnOpenFileDlg";
            this._colBtnOpenFileDlg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._colBtnOpenFileDlg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._colBtnOpenFileDlg.Text = "Выбор каталога";
            this._colBtnOpenFileDlg.ToolTipText = "Выбор каталога через диалог";
            this._colBtnOpenFileDlg.UseColumnTextForButtonValue = true;
            this._colBtnOpenFileDlg.Width = 65;
            // 
            // _columnSharedStatus
            // 
            this._columnSharedStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._columnSharedStatus.DataPropertyName = "SharedStatus";
            this._columnSharedStatus.FillWeight = 158.4906F;
            this._columnSharedStatus.HeaderText = "Статус";
            this._columnSharedStatus.MinimumWidth = 200;
            this._columnSharedStatus.Name = "_columnSharedStatus";
            this._columnSharedStatus.ReadOnly = true;
            this._columnSharedStatus.ToolTipText = "Статус проверки папки";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_find.png");
            this.imageList1.Images.SetKeyName(1, "files_export.png");
            this.imageList1.Images.SetKeyName(2, "del.png");
            this.imageList1.Images.SetKeyName(3, "save.png");
            this.imageList1.Images.SetKeyName(4, "block1.png");
            this.imageList1.Images.SetKeyName(5, "folder_add.ico");
            this.imageList1.Images.SetKeyName(6, "folder_delete.ico");
            this.imageList1.Images.SetKeyName(7, "folder_preferences.ico");
            // 
            // gridHiddenControls
            // 
            this.gridHiddenControls.AutoScroll = true;
            this.gridHiddenControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHiddenControls.Location = new System.Drawing.Point(0, 0);
            this.gridHiddenControls.Name = "gridHiddenControls";
            this.gridHiddenControls.Size = new System.Drawing.Size(235, 346);
            this.gridHiddenControls.TabIndex = 0;
            this.gridHiddenControls.VisibleTop = true;
            // 
            // labelReplication
            // 
            this.labelReplication.AutoSize = true;
            this.labelReplication.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelReplication.Location = new System.Drawing.Point(0, 0);
            this.labelReplication.Name = "labelReplication";
            this.labelReplication.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.labelReplication.Size = new System.Drawing.Size(74, 21);
            this.labelReplication.TabIndex = 3;
            this.labelReplication.Text = "Репликация";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridHiddenControls);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridFolders);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.labelReplication);
            this.splitContainer1.Size = new System.Drawing.Size(709, 346);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiDelete,
            this._tsmiAdd,
            this._tsmiValidate});
            this.menuStrip1.Location = new System.Drawing.Point(0, 21);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(126, 325);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _tsmiDelete
            // 
            this._tsmiDelete.Image = global::Configuration.Properties.Resources.row_delete;
            this._tsmiDelete.Name = "_tsmiDelete";
            this._tsmiDelete.Size = new System.Drawing.Size(21, 20);
            this._tsmiDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this._tsmiDelete.ToolTipText = "Удалить строку репликации из настройки";
            this._tsmiDelete.Click += new System.EventHandler(this._tsmiDelete_Click);
            // 
            // _tsmiAdd
            // 
            this._tsmiAdd.Image = global::Configuration.Properties.Resources.row_add_after;
            this._tsmiAdd.Name = "_tsmiAdd";
            this._tsmiAdd.Size = new System.Drawing.Size(21, 20);
            this._tsmiAdd.ToolTipText = "Добавить строку для репликации";
            this._tsmiAdd.Click += new System.EventHandler(this._tsmiAdd_Click);
            // 
            // _tsmiValidate
            // 
            this._tsmiValidate.Image = global::Configuration.Properties.Resources.column_preferences1;
            this._tsmiValidate.Name = "_tsmiValidate";
            this._tsmiValidate.Size = new System.Drawing.Size(21, 20);
            this._tsmiValidate.ToolTipText = "Проверить доступность перечисленных путей для репликации";
            this._tsmiValidate.Click += new System.EventHandler(this._tsmiValidate_Click);
            // 
            // toolTipGrid
            // 
            this.toolTipGrid.AutoPopDelay = 5000;
            this.toolTipGrid.InitialDelay = 1500;
            this.toolTipGrid.IsBalloon = true;
            this.toolTipGrid.ReshowDelay = 100;
            this.toolTipGrid.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipGrid.ToolTipTitle = "После изменений этих настроек, необходимо перезагрузить приложение.";
            // 
            // SettingEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SettingEditControl";
            this.Size = new System.Drawing.Size(709, 346);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFolders)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFolders;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _columnIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnFolderName;
        private System.Windows.Forms.DataGridViewButtonColumn _colBtnOpenFileDlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnSharedStatus;
        private Editors.GridWithLabelControl gridHiddenControls;
        private System.Windows.Forms.Label labelReplication;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem _tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem _tsmiValidate;
        private System.Windows.Forms.ToolTip toolTipGrid;
    }
}
