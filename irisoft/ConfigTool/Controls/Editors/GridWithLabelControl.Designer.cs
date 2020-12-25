using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    partial class GridWithLabelControl
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
            _dataGridView.RowEnter -= DataGridView_RowEnter;
            var assistant = Assistant.GetInstance();
            if(assistant!=null)
                assistant.BeforeHasDifferents -= BeforeHasDifferents;
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._columnQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssUp = new System.Windows.Forms.ToolStripSplitButton();
            this.tssDown = new System.Windows.Forms.ToolStripSplitButton();
            this._bDeleteRow = new System.Windows.Forms.ToolStripSplitButton();
            this._tsbQuestion = new System.Windows.Forms.ToolStripSplitButton();
            this.panelTop = new System.Windows.Forms.Panel();
            this._labelCommentXelement = new System.Windows.Forms.Label();
            this._labelXelement = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGridView
            // 
            this._dataGridView.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnQueue,
            this._columnText,
            this._columnComment});
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(33, 21);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(645, 99);
            this._dataGridView.TabIndex = 0;
            this._dataGridView.DataError += _dataGridView_DataError;
            // 
            // _columnQueue
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this._columnQueue.DefaultCellStyle = dataGridViewCellStyle2;
            this._columnQueue.HeaderText = "номер";
            this._columnQueue.MaxInputLength = 2;
            this._columnQueue.Name = "_columnQueue";
            this._columnQueue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this._columnQueue.ToolTipText = "порядковый номер строки (-1 если отколючена)";
            this._columnQueue.Width = 50;
            // 
            // _columnText
            // 
            this._columnText.HeaderText = "Значение";
            this._columnText.Name = "_columnText";
            this._columnText.Width = 210;
            // 
            // _columnComment
            // 
            this._columnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._columnComment.HeaderText = "Комментарий";
            this._columnComment.Name = "_columnComment";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssUp,
            this.tssDown,
            this._bDeleteRow,
            this._tsbQuestion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 21);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(33, 99);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssUp
            // 
            this.tssUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssUp.DropDownButtonWidth = 0;
            this.tssUp.Image = global::Configuration.Properties.Resources.arrow_up_green;
            this.tssUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssUp.Name = "tssUp";
            this.tssUp.Size = new System.Drawing.Size(31, 20);
            this.tssUp.Text = "Вверх";
            this.tssUp.ToolTipText = "Переместить строку вверх";
            this.tssUp.Visible = false;
            this.tssUp.ButtonClick += new System.EventHandler(this.tssUp_ButtonClick);
            // 
            // tssDown
            // 
            this.tssDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssDown.DropDownButtonWidth = 0;
            this.tssDown.Image = global::Configuration.Properties.Resources.arrow_down_green;
            this.tssDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssDown.Name = "tssDown";
            this.tssDown.Size = new System.Drawing.Size(31, 20);
            this.tssDown.Text = "Вниз";
            this.tssDown.ToolTipText = "Переместить строку вниз";
            this.tssDown.Visible = false;
            this.tssDown.ButtonClick += new System.EventHandler(this.tssDown_ButtonClick);
            // 
            // _bDeleteRow
            // 
            this._bDeleteRow.AutoToolTip = false;
            this._bDeleteRow.BackColor = System.Drawing.SystemColors.Control;
            this._bDeleteRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._bDeleteRow.DropDownButtonWidth = 0;
            this._bDeleteRow.Image = global::Configuration.Properties.Resources.row_delete;
            this._bDeleteRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._bDeleteRow.Name = "_bDeleteRow";
            this._bDeleteRow.Size = new System.Drawing.Size(31, 20);
            this._bDeleteRow.Text = "Удалить текущую строку";
            this._bDeleteRow.ButtonClick += new System.EventHandler(this._bDeleteRow_ButtonClick);
            // 
            // _tsbQuestion
            // 
            this._tsbQuestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbQuestion.DropDownButtonWidth = 0;
            this._tsbQuestion.Image = global::Configuration.Properties.Resources.information;
            this._tsbQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbQuestion.Name = "_tsbQuestion";
            this._tsbQuestion.Size = new System.Drawing.Size(31, 20);
            this._tsbQuestion.ToolTipText = "Для добавления строки используйте строку со звездочкой.";
            this._tsbQuestion.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this._labelCommentXelement);
            this.panelTop.Controls.Add(this._labelXelement);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(678, 21);
            this.panelTop.TabIndex = 2;
            // 
            // _labelCommentXelement
            // 
            this._labelCommentXelement.AutoSize = true;
            this._labelCommentXelement.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelCommentXelement.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._labelCommentXelement.Location = new System.Drawing.Point(41, 0);
            this._labelCommentXelement.Name = "_labelCommentXelement";
            this._labelCommentXelement.Padding = new System.Windows.Forms.Padding(3);
            this._labelCommentXelement.Size = new System.Drawing.Size(41, 19);
            this._labelCommentXelement.TabIndex = 1;
            this._labelCommentXelement.Text = "label1";
            this._labelCommentXelement.Visible = false;
            // 
            // _labelXelement
            // 
            this._labelXelement.AutoSize = true;
            this._labelXelement.Dock = System.Windows.Forms.DockStyle.Left;
            this._labelXelement.Location = new System.Drawing.Point(0, 0);
            this._labelXelement.Name = "_labelXelement";
            this._labelXelement.Padding = new System.Windows.Forms.Padding(3);
            this._labelXelement.Size = new System.Drawing.Size(41, 19);
            this._labelXelement.TabIndex = 0;
            this._labelXelement.Text = "label1";
            this._labelXelement.Visible = false;
            // 
            // GridWithLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelTop);
            this.Name = "GridWithLabelControl";
            this.Size = new System.Drawing.Size(678, 120);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton tssUp;
        private System.Windows.Forms.ToolStripSplitButton tssDown;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label _labelCommentXelement;
        protected System.Windows.Forms.Label _labelXelement;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _columnQueue;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _columnText;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _columnComment;
        private System.Windows.Forms.ToolStripSplitButton _bDeleteRow;
        private System.Windows.Forms.ToolStripSplitButton _tsbQuestion;
    }
}
