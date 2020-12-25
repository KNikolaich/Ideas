
namespace Configuration.Controls.Editors
{
    partial class TypeConfigControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeConfigControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._lTypeConfig = new System.Windows.Forms.Label();
            this._gridFaControl = new Configuration.Controls.Editors.GridWithLabelControl();
            this._filterAttribsOther = new Configuration.Controls.Editors.StringCollectionControl();
            this.panelComment = new System.Windows.Forms.Panel();
            this._tbFilterComments = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this._tbFilterName = new System.Windows.Forms.TextBox();
            this._bDelete = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelComment.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._tbFilterComments, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._lTypeConfig, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._gridFaControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._filterAttribsOther, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 102);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _lTypeConfig
            // 
            this._lTypeConfig.AutoSize = true;
            this._lTypeConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lTypeConfig.Location = new System.Drawing.Point(3, 0);
            this._lTypeConfig.Name = "_lTypeConfig";
            this._lTypeConfig.Size = new System.Drawing.Size(71, 13);
            this._lTypeConfig.TabIndex = 2;
            this._lTypeConfig.Text = "TypeConfig";
            // 
            // _gridFaControl
            // 
            this._gridFaControl.AutoScroll = true;
            this._gridFaControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridFaControl.Location = new System.Drawing.Point(319, 3);
            this._gridFaControl.Name = "_gridFaControl";
            this.tableLayoutPanel1.SetRowSpan(this._gridFaControl, 3);
            this._gridFaControl.Size = new System.Drawing.Size(274, 96);
            this._gridFaControl.TabIndex = 0;
            this._gridFaControl.VisibleTop = true;
            // 
            // _filterAttribsOther
            // 
            this._filterAttribsOther.AutoScroll = true;
            this._filterAttribsOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this._filterAttribsOther.Location = new System.Drawing.Point(599, 3);
            this._filterAttribsOther.Name = "_filterAttribsOther";
            this.tableLayoutPanel1.SetRowSpan(this._filterAttribsOther, 3);
            this._filterAttribsOther.Size = new System.Drawing.Size(274, 96);
            this._filterAttribsOther.TabIndex = 6;
            // 
            // panelComment
            // 
            this.panelComment.Controls.Add(this._tbFilterName);
            this.panelComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelComment.Location = new System.Drawing.Point(23, 3);
            this.panelComment.Name = "panelComment";
            this.panelComment.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panelComment.Size = new System.Drawing.Size(284, 20);
            this.panelComment.TabIndex = 9;
            // 
            // _tbFilterComments
            // 
            this._tbFilterComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbFilterComments.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._tbFilterComments.Location = new System.Drawing.Point(3, 58);
            this._tbFilterComments.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this._tbFilterComments.Multiline = true;
            this._tbFilterComments.Name = "_tbFilterComments";
            this._tbFilterComments.ReadOnly = true;
            this._tbFilterComments.Size = new System.Drawing.Size(310, 41);
            this._tbFilterComments.TabIndex = 4;
            this._tbFilterComments.Text = "тут комментарий к фильтру";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelComment);
            this.panelTop.Controls.Add(this._bDelete);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 24);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(3);
            this.panelTop.Size = new System.Drawing.Size(310, 26);
            this.panelTop.TabIndex = 2;
            // 
            // _tbFilterName
            // 
            this._tbFilterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbFilterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbFilterName.Location = new System.Drawing.Point(10, 0);
            this._tbFilterName.Name = "_tbFilterName";
            this._tbFilterName.Size = new System.Drawing.Size(274, 20);
            this._tbFilterName.TabIndex = 1;
            this._tbFilterName.Text = "имя фильтра";
            // 
            // _bDelete
            // 
            this._bDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this._bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._bDelete.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._bDelete.ImageIndex = 0;
            this._bDelete.ImageList = this.imageList1;
            this._bDelete.Location = new System.Drawing.Point(3, 3);
            this._bDelete.MaximumSize = new System.Drawing.Size(50, 57);
            this._bDelete.Name = "_bDelete";
            this._bDelete.Size = new System.Drawing.Size(20, 20);
            this._bDelete.TabIndex = 5;
            this._bDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this._bDelete.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "delete_x_24.png");
            // 
            // TypeConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TypeConfigControl";
            this.Size = new System.Drawing.Size(876, 102);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelComment.ResumeLayout(false);
            this.panelComment.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private StringCollectionControl _filterAttribsOther;
        private System.Windows.Forms.Panel panelComment;
        private System.Windows.Forms.TextBox _tbFilterComments;
        private System.Windows.Forms.Button _bDelete;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label _lTypeConfig;
        private System.Windows.Forms.TextBox _tbFilterName;
        private GridWithLabelControl _gridFaControl;
    }
}
