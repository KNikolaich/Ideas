namespace StaffTimes.SubControls
{
    partial class ChangePasswordForm
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
            _context = null;
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this._sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this._sbOk = new DevExpress.XtraEditors.SimpleButton();
            this._teNewParrdw2 = new DevExpress.XtraEditors.TextEdit();
            this._teNewPasswrd = new DevExpress.XtraEditors.TextEdit();
            this._teOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._teNewParrdw2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._teNewPasswrd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._teOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this._sbCancel);
            this.layoutControl1.Controls.Add(this._sbOk);
            this.layoutControl1.Controls.Add(this._teNewParrdw2);
            this.layoutControl1.Controls.Add(this._teNewPasswrd);
            this.layoutControl1.Controls.Add(this._teOldPassword);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(304, 131);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // _sbCancel
            // 
            this._sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._sbCancel.Location = new System.Drawing.Point(12, 97);
            this._sbCancel.Name = "_sbCancel";
            this._sbCancel.Size = new System.Drawing.Size(137, 22);
            this._sbCancel.StyleController = this.layoutControl1;
            this._sbCancel.TabIndex = 5;
            this._sbCancel.Text = "Отменить";
            // 
            // _sbOk
            // 
            this._sbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._sbOk.Location = new System.Drawing.Point(153, 97);
            this._sbOk.Name = "_sbOk";
            this._sbOk.Size = new System.Drawing.Size(139, 22);
            this._sbOk.StyleController = this.layoutControl1;
            this._sbOk.TabIndex = 5;
            this._sbOk.Text = "Меняем";
            this._sbOk.Click += new System.EventHandler(this._sbOk_Click);
            // 
            // _teNewParrdw2
            // 
            this._teNewParrdw2.EditValue = "";
            this._teNewParrdw2.Location = new System.Drawing.Point(93, 60);
            this._teNewParrdw2.Name = "_teNewParrdw2";
            this._teNewParrdw2.Properties.NullText = "*";
            this._teNewParrdw2.Properties.UseSystemPasswordChar = true;
            this._teNewParrdw2.Size = new System.Drawing.Size(199, 20);
            this._teNewParrdw2.StyleController = this.layoutControl1;
            this._teNewParrdw2.TabIndex = 4;
            // 
            // _teNewPasswrd
            // 
            this._teNewPasswrd.EditValue = "";
            this._teNewPasswrd.Location = new System.Drawing.Point(93, 36);
            this._teNewPasswrd.Name = "_teNewPasswrd";
            this._teNewPasswrd.Properties.NullText = "*";
            this._teNewPasswrd.Properties.UseSystemPasswordChar = true;
            this._teNewPasswrd.Size = new System.Drawing.Size(199, 20);
            this._teNewPasswrd.StyleController = this.layoutControl1;
            this._teNewPasswrd.TabIndex = 4;
            // 
            // _teOldPassword
            // 
            this._teOldPassword.Location = new System.Drawing.Point(93, 12);
            this._teOldPassword.Name = "_teOldPassword";
            this._teOldPassword.Size = new System.Drawing.Size(199, 20);
            this._teOldPassword.StyleController = this.layoutControl1;
            this._teOldPassword.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(304, 131);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this._teOldPassword;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem1.Text = "Старый пароль";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this._teNewPasswrd;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem2.Text = "Новый пароль";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this._teNewParrdw2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem3.Text = "Повтор пароля";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this._sbOk;
            this.layoutControlItem4.Location = new System.Drawing.Point(141, 85);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(143, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this._sbCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 85);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(141, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(284, 13);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 131);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Смена пароля";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._teNewParrdw2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._teNewPasswrd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._teOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton _sbCancel;
        private DevExpress.XtraEditors.SimpleButton _sbOk;
        private DevExpress.XtraEditors.TextEdit _teNewParrdw2;
        private DevExpress.XtraEditors.TextEdit _teNewPasswrd;
        private DevExpress.XtraEditors.TextEdit _teOldPassword;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}