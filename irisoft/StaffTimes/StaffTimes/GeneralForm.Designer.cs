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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._gridWeeks = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeekNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditStarted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditEndet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.colApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._gridWeeks)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _gridWeeks
            // 
            this._gridWeeks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gridWeeks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridWeeks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colWeekNumber,
            this.colEditStarted,
            this.colEditEndet,
            this.colStatus,
            this.colApproved});
            this._gridWeeks.GridColor = System.Drawing.SystemColors.Control;
            this._gridWeeks.Location = new System.Drawing.Point(12, 37);
            this._gridWeeks.Name = "_gridWeeks";
            this._gridWeeks.Size = new System.Drawing.Size(776, 401);
            this._gridWeeks.TabIndex = 1;
            this._gridWeeks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._gridWeeks_CellContentClick);
            this._gridWeeks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._gridWeeks_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colWeekNumber
            // 
            this.colWeekNumber.DataPropertyName = "WeekNumber";
            this.colWeekNumber.FillWeight = 200F;
            this.colWeekNumber.HeaderText = "Номер недели";
            this.colWeekNumber.MinimumWidth = 10;
            this.colWeekNumber.Name = "colWeekNumber";
            this.colWeekNumber.ReadOnly = true;
            this.colWeekNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colWeekNumber.Width = 150;
            // 
            // colEditStarted
            // 
            this.colEditStarted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEditStarted.DataPropertyName = "EditStarted";
            this.colEditStarted.FillWeight = 200F;
            this.colEditStarted.HeaderText = "Начало заполнения";
            this.colEditStarted.Name = "colEditStarted";
            this.colEditStarted.ReadOnly = true;
            // 
            // colEditEndet
            // 
            this.colEditEndet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEditEndet.DataPropertyName = "EditEnded";
            this.colEditEndet.FillWeight = 200F;
            this.colEditEndet.HeaderText = "Завершено заполнение";
            this.colEditEndet.Name = "colEditEndet";
            this.colEditEndet.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colApproved
            // 
            this.colApproved.DataPropertyName = "Approved";
            this.colApproved.HeaderText = "Одобрено";
            this.colApproved.Name = "colApproved";
            this.colApproved.ReadOnly = true;
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._gridWeeks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GeneralForm";
            this.Text = "Учет времени";
            this.Load += new System.EventHandler(this.GeneralForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._gridWeeks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView _gridWeeks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeekNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEditStarted;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEditEndet;
        private System.Windows.Forms.DataGridViewImageColumn colStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colApproved;
    }
}

