namespace WindowsFormApp.Controls
{
    partial class TestDataUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestDataUserControl));
            this._progressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this._imageListBoxControl = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkedComboBoxEditShowInfo = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this._progressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._imageListBoxControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEditShowInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _progressBarControl
            // 
            this._progressBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._progressBarControl.Location = new System.Drawing.Point(2, 2);
            this._progressBarControl.Name = "_progressBarControl";
            this._progressBarControl.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this._progressBarControl.Properties.PercentView = false;
            this._progressBarControl.Properties.ShowTitle = true;
            this._progressBarControl.Size = new System.Drawing.Size(267, 14);
            this._progressBarControl.TabIndex = 1;
            this._progressBarControl.ToolTip = "Прогресс";
            // 
            // _imageListBoxControl
            // 
            this._imageListBoxControl.Cursor = System.Windows.Forms.Cursors.Default;
            this._imageListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._imageListBoxControl.ImageList = this.imageList1;
            this._imageListBoxControl.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "Предупреждение", 1),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "Trace", 3),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "Отладочная инфа", 2),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "Ошибки", 4),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "Инфо", 0)});
            this._imageListBoxControl.Location = new System.Drawing.Point(0, 0);
            this._imageListBoxControl.Name = "_imageListBoxControl";
            this._imageListBoxControl.Size = new System.Drawing.Size(470, 282);
            this._imageListBoxControl.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "about.ico");
            this.imageList1.Images.SetKeyName(1, "warning.ico");
            this.imageList1.Images.SetKeyName(2, "wrench.ico");
            this.imageList1.Images.SetKeyName(3, "step.ico");
            this.imageList1.Images.SetKeyName(4, "error.ico");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this._progressBarControl);
            this.panelControl1.Controls.Add(this.checkedComboBoxEditShowInfo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 282);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(470, 18);
            this.panelControl1.TabIndex = 4;
            // 
            // checkedComboBoxEditShowInfo
            // 
            this.checkedComboBoxEditShowInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkedComboBoxEditShowInfo.EditValue = "0, 3, 1, 2, 4";
            this.checkedComboBoxEditShowInfo.Location = new System.Drawing.Point(269, 2);
            this.checkedComboBoxEditShowInfo.Name = "checkedComboBoxEditShowInfo";
            this.checkedComboBoxEditShowInfo.Properties.Appearance.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedComboBoxEditShowInfo.Properties.Appearance.Options.UseFont = true;
            this.checkedComboBoxEditShowInfo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEditShowInfo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(0, "Инфо", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(3, "Trace", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(1, "Warning", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(2, "Debug", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(4, "Error", System.Windows.Forms.CheckState.Checked)});
            this.checkedComboBoxEditShowInfo.Size = new System.Drawing.Size(199, 20);
            this.checkedComboBoxEditShowInfo.TabIndex = 4;
            // 
            // TestDataUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._imageListBoxControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "TestDataUserControl";
            this.Size = new System.Drawing.Size(470, 300);
            ((System.ComponentModel.ISupportInitialize)(this._progressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._imageListBoxControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEditShowInfo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ProgressBarControl _progressBarControl;
        private DevExpress.XtraEditors.ImageListBoxControl _imageListBoxControl;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEditShowInfo;
    }
}
