namespace Configuration
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this._mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this._geniralEditCfgControl1 = new Configuration.Controls.GeniralEditCfgControl();
            this.tabPageSharing = new System.Windows.Forms.TabPage();
            this._settingEditControl = new Configuration.Controls.SettingEditControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPageSave = new System.Windows.Forms.TabPage();
            this._saveFileControl = new Configuration.Controls.SaveFileControl();
            this.panelButton = new System.Windows.Forms.Panel();
            this.lSourceFileName = new System.Windows.Forms.Label();
            this._buttonExit = new System.Windows.Forms.Button();
            this._bOpen = new System.Windows.Forms.Button();
            this._bSave = new System.Windows.Forms.Button();
            this._buttonSend = new System.Windows.Forms.Button();
            this._mainTabControl.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.tabPageSharing.SuspendLayout();
            this.tabPageSave.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTabControl
            // 
            this._mainTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this._mainTabControl.Controls.Add(this.tabPageEdit);
            this._mainTabControl.Controls.Add(this.tabPageSharing);
            this._mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._mainTabControl.ImageList = this.imageList1;
            this._mainTabControl.ItemSize = new System.Drawing.Size(24, 30);
            this._mainTabControl.Location = new System.Drawing.Point(0, 0);
            this._mainTabControl.Multiline = true;
            this._mainTabControl.Name = "_mainTabControl";
            this._mainTabControl.SelectedIndex = 0;
            this._mainTabControl.Size = new System.Drawing.Size(1264, 617);
            this._mainTabControl.TabIndex = 2;
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Controls.Add(this._geniralEditCfgControl1);
            this.tabPageEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageEdit.ImageIndex = 0;
            this.tabPageEdit.Location = new System.Drawing.Point(34, 4);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdit.Size = new System.Drawing.Size(1226, 609);
            this.tabPageEdit.TabIndex = 0;
            this.tabPageEdit.Text = "Правка файла";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // _geniralEditCfgControl1
            // 
            this._geniralEditCfgControl1.AutoScroll = true;
            this._geniralEditCfgControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._geniralEditCfgControl1.Location = new System.Drawing.Point(3, 3);
            this._geniralEditCfgControl1.Name = "_geniralEditCfgControl1";
            this._geniralEditCfgControl1.Size = new System.Drawing.Size(1220, 603);
            this._geniralEditCfgControl1.TabIndex = 0;
            // 
            // tabPageSharing
            // 
            this.tabPageSharing.Controls.Add(this._settingEditControl);
            this.tabPageSharing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageSharing.ImageIndex = 1;
            this.tabPageSharing.Location = new System.Drawing.Point(34, 4);
            this.tabPageSharing.Name = "tabPageSharing";
            this.tabPageSharing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSharing.Size = new System.Drawing.Size(1042, 460);
            this.tabPageSharing.TabIndex = 1;
            this.tabPageSharing.Text = "Настройки";
            this.tabPageSharing.UseVisualStyleBackColor = true;
            // 
            // _settingEditControl
            // 
            this._settingEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingEditControl.Location = new System.Drawing.Point(3, 3);
            this._settingEditControl.Name = "_settingEditControl";
            this._settingEditControl.Size = new System.Drawing.Size(1036, 454);
            this._settingEditControl.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "app_edit.png");
            this.imageList1.Images.SetKeyName(1, "gears.ico");
            this.imageList1.Images.SetKeyName(2, "folder_into.ico");
            this.imageList1.Images.SetKeyName(3, "disk_green.ico");
            this.imageList1.Images.SetKeyName(4, "Action_Exit_32x32.png");
            this.imageList1.Images.SetKeyName(5, "open_document_24_h.png");
            // 
            // tabPageSave
            // 
            this.tabPageSave.Controls.Add(this._saveFileControl);
            this.tabPageSave.Location = new System.Drawing.Point(4, 22);
            this.tabPageSave.Name = "tabPageSave";
            this.tabPageSave.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSave.Size = new System.Drawing.Size(912, 424);
            this.tabPageSave.TabIndex = 2;
            this.tabPageSave.Text = "Сохранение";
            this.tabPageSave.UseVisualStyleBackColor = true;
            // 
            // _saveFileControl
            // 
            this._saveFileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveFileControl.Location = new System.Drawing.Point(3, 3);
            this._saveFileControl.Name = "_saveFileControl";
            this._saveFileControl.Size = new System.Drawing.Size(906, 418);
            this._saveFileControl.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.lSourceFileName);
            this.panelButton.Controls.Add(this._buttonExit);
            this.panelButton.Controls.Add(this._bOpen);
            this.panelButton.Controls.Add(this._bSave);
            this.panelButton.Controls.Add(this._buttonSend);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 617);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1264, 44);
            this.panelButton.TabIndex = 3;
            // 
            // lSourceFileName
            // 
            this.lSourceFileName.AutoSize = true;
            this.lSourceFileName.Location = new System.Drawing.Point(128, 18);
            this.lSourceFileName.Name = "lSourceFileName";
            this.lSourceFileName.Size = new System.Drawing.Size(88, 13);
            this.lSourceFileName.TabIndex = 1;
            this.lSourceFileName.Text = "Открытый файл";
            // 
            // _buttonExit
            // 
            this._buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonExit.ImageIndex = 4;
            this._buttonExit.ImageList = this.imageList1;
            this._buttonExit.Location = new System.Drawing.Point(1163, 6);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(94, 35);
            this._buttonExit.TabIndex = 0;
            this._buttonExit.Text = "Закрыть";
            this._buttonExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonExit.UseVisualStyleBackColor = true;
            this._buttonExit.Click += new System.EventHandler(this._buttonExit_Click);
            // 
            // _bOpen
            // 
            this._bOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._bOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._bOpen.ImageIndex = 5;
            this._bOpen.ImageList = this.imageList1;
            this._bOpen.Location = new System.Drawing.Point(3, 6);
            this._bOpen.Name = "_bOpen";
            this._bOpen.Size = new System.Drawing.Size(119, 35);
            this._bOpen.TabIndex = 0;
            this._bOpen.Text = "Открыть файл";
            this._bOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._bOpen.UseVisualStyleBackColor = true;
            this._bOpen.Click += new System.EventHandler(this._bOpen_Click);
            // 
            // _bSave
            // 
            this._bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._bSave.ImageIndex = 3;
            this._bSave.ImageList = this.imageList1;
            this._bSave.Location = new System.Drawing.Point(930, 6);
            this._bSave.Name = "_bSave";
            this._bSave.Size = new System.Drawing.Size(95, 35);
            this._bSave.TabIndex = 0;
            this._bSave.Text = "Сохранить";
            this._bSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._bSave.UseVisualStyleBackColor = true;
            this._bSave.Click += new System.EventHandler(this._bSave_Click);
            // 
            // _buttonSend
            // 
            this._buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonSend.ImageIndex = 2;
            this._buttonSend.ImageList = this.imageList1;
            this._buttonSend.Location = new System.Drawing.Point(1031, 6);
            this._buttonSend.Name = "_buttonSend";
            this._buttonSend.Size = new System.Drawing.Size(119, 35);
            this._buttonSend.TabIndex = 0;
            this._buttonSend.Text = "Реплицировать";
            this._buttonSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonSend.UseVisualStyleBackColor = true;
            this._buttonSend.Click += new System.EventHandler(this._buttonSend_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 661);
            this.Controls.Add(this._mainTabControl);
            this.Controls.Add(this.panelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигуратор передачи ПДЭ";
            this._mainTabControl.ResumeLayout(false);
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageSharing.ResumeLayout(false);
            this.tabPageSave.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl _mainTabControl;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.TabPage tabPageSharing;
        private Controls.GeniralEditCfgControl _geniralEditCfgControl1;
        private Controls.SettingEditControl _settingEditControl;
        private System.Windows.Forms.TabPage tabPageSave;
        private Controls.SaveFileControl _saveFileControl;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button _buttonExit;
        private System.Windows.Forms.Button _buttonSend;
        private System.Windows.Forms.Button _bOpen;
        private System.Windows.Forms.Button _bSave;
        private System.Windows.Forms.Label lSourceFileName;
    }
}

