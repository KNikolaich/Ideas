namespace Configuration.Controls.Editors
{
    partial class ContainerConfigControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerConfigControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._bRemove = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelSign = new System.Windows.Forms.Panel();
            this._radioButtonOff = new System.Windows.Forms.RadioButton();
            this._rbSignContent = new System.Windows.Forms.RadioButton();
            this._rbSignIUL = new System.Windows.Forms.RadioButton();
            this._lContainerConfig = new System.Windows.Forms.Label();
            this._gridControl = new Configuration.Controls.Editors.ContainerConfigGridControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSign.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelSign, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._lContainerConfig, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._gridControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 165);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._textBoxName);
            this.panel2.Controls.Add(this._bRemove);
            this.panel2.Location = new System.Drawing.Point(3, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 22);
            this.panel2.TabIndex = 1;
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(29, 0);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(95, 20);
            this._textBoxName.TabIndex = 2;
            // 
            // _bRemove
            // 
            this._bRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._bRemove.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._bRemove.ImageIndex = 0;
            this._bRemove.ImageList = this.imageList1;
            this._bRemove.Location = new System.Drawing.Point(3, 0);
            this._bRemove.Name = "_bRemove";
            this._bRemove.Size = new System.Drawing.Size(20, 20);
            this._bRemove.TabIndex = 4;
            this._bRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this._bRemove.UseVisualStyleBackColor = true;
            this._bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "delete_x_24.png");
            // 
            // panelSign
            // 
            this.panelSign.Controls.Add(this._radioButtonOff);
            this.panelSign.Controls.Add(this._rbSignContent);
            this.panelSign.Controls.Add(this._rbSignIUL);
            this.panelSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSign.Location = new System.Drawing.Point(3, 56);
            this.panelSign.Name = "panelSign";
            this.panelSign.Size = new System.Drawing.Size(124, 106);
            this.panelSign.TabIndex = 2;
            // 
            // _radioButtonOff
            // 
            this._radioButtonOff.AutoSize = true;
            this._radioButtonOff.Checked = true;
            this._radioButtonOff.Location = new System.Drawing.Point(3, 47);
            this._radioButtonOff.Name = "_radioButtonOff";
            this._radioButtonOff.Size = new System.Drawing.Size(88, 17);
            this._radioButtonOff.TabIndex = 5;
            this._radioButtonOff.TabStop = true;
            this._radioButtonOff.Text = "без подписи";
            this._radioButtonOff.UseVisualStyleBackColor = true;
            this._radioButtonOff.CheckedChanged += new System.EventHandler(this._radioButtonOff_CheckedChanged);
            // 
            // _rbSignContent
            // 
            this._rbSignContent.AutoSize = true;
            this._rbSignContent.Location = new System.Drawing.Point(3, 26);
            this._rbSignContent.Name = "_rbSignContent";
            this._rbSignContent.Size = new System.Drawing.Size(81, 17);
            this._rbSignContent.TabIndex = 5;
            this._rbSignContent.Text = "signContent";
            this._rbSignContent.UseVisualStyleBackColor = true;
            this._rbSignContent.CheckedChanged += new System.EventHandler(this._rbSignContent_CheckedChanged);
            // 
            // _rbSignIUL
            // 
            this._rbSignIUL.AutoSize = true;
            this._rbSignIUL.Location = new System.Drawing.Point(3, 3);
            this._rbSignIUL.Name = "_rbSignIUL";
            this._rbSignIUL.Size = new System.Drawing.Size(61, 17);
            this._rbSignIUL.TabIndex = 5;
            this._rbSignIUL.Text = "signIUL";
            this._rbSignIUL.UseVisualStyleBackColor = true;
            this._rbSignIUL.CheckedChanged += new System.EventHandler(this._rbSignIUL_CheckedChanged);
            // 
            // _lContainerConfig
            // 
            this._lContainerConfig.AutoSize = true;
            this._lContainerConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lContainerConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lContainerConfig.Location = new System.Drawing.Point(3, 0);
            this._lContainerConfig.Name = "_lContainerConfig";
            this._lContainerConfig.Size = new System.Drawing.Size(124, 25);
            this._lContainerConfig.TabIndex = 1;
            this._lContainerConfig.Text = "ContainerConfig";
            // 
            // _gridControl
            // 
            this._gridControl.AutoScroll = true;
            this._gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridControl.Location = new System.Drawing.Point(133, 3);
            this._gridControl.Name = "_gridControl";
            this.tableLayoutPanel1.SetRowSpan(this._gridControl, 3);
            this._gridControl.Size = new System.Drawing.Size(388, 159);
            this._gridControl.TabIndex = 3;
            this._gridControl.VisibleTop = true;
            // 
            // ContainerConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ContainerConfigControl";
            this.Size = new System.Drawing.Size(524, 165);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelSign.ResumeLayout(false);
            this.panelSign.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _lContainerConfig;
        private System.Windows.Forms.TextBox _textBoxName;
        private ContainerConfigGridControl _gridControl;
        private System.Windows.Forms.Button _bRemove;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSign;
        private System.Windows.Forms.RadioButton _radioButtonOff;
        private System.Windows.Forms.RadioButton _rbSignContent;
        private System.Windows.Forms.RadioButton _rbSignIUL;
    }
}
