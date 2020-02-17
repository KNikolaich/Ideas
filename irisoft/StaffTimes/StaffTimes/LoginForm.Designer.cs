namespace StaffTimes
{
    partial class LoginForm
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
            _user = null;
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lLogin = new System.Windows.Forms.Label();
            this.lPasswd = new System.Windows.Forms.Label();
            this._bOk = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this._tbPasswd = new System.Windows.Forms.TextBox();
            this._cbSavePass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLogin.Location = new System.Drawing.Point(25, 14);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(50, 16);
            this.lLogin.TabIndex = 0;
            this.lLogin.Text = "Логин:";
            // 
            // lPasswd
            // 
            this.lPasswd.AutoSize = true;
            this.lPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPasswd.Location = new System.Drawing.Point(15, 45);
            this.lPasswd.Name = "lPasswd";
            this.lPasswd.Size = new System.Drawing.Size(60, 16);
            this.lPasswd.TabIndex = 0;
            this.lPasswd.Text = "Пароль:";
            // 
            // _bOk
            // 
            this._bOk.Location = new System.Drawing.Point(148, 72);
            this._bOk.Name = "_bOk";
            this._bOk.Size = new System.Drawing.Size(75, 23);
            this._bOk.TabIndex = 2;
            this._bOk.Text = "Вход";
            this._bOk.UseVisualStyleBackColor = true;
            this._bOk.Click += new System.EventHandler(this._bOk_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(81, 13);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(142, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLogin_KeyDown);
            // 
            // _tbPasswd
            // 
            this._tbPasswd.Location = new System.Drawing.Point(81, 44);
            this._tbPasswd.Name = "_tbPasswd";
            this._tbPasswd.PasswordChar = '*';
            this._tbPasswd.Size = new System.Drawing.Size(141, 20);
            this._tbPasswd.TabIndex = 1;
            this._tbPasswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this._tbPasswd_KeyDown);
            // 
            // _cbSavePass
            // 
            this._cbSavePass.AutoSize = true;
            this._cbSavePass.Checked = true;
            this._cbSavePass.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbSavePass.Location = new System.Drawing.Point(114, 77);
            this._cbSavePass.Name = "_cbSavePass";
            this._cbSavePass.Size = new System.Drawing.Size(15, 14);
            this._cbSavePass.TabIndex = 3;
            this._cbSavePass.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this._cbSavePass.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(15, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сохранять пароль:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 107);
            this.Controls.Add(this._cbSavePass);
            this.Controls.Add(this._tbPasswd);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this._bOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lPasswd);
            this.Controls.Add(this.lLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "вход";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Label lPasswd;
        private System.Windows.Forms.Button _bOk;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox _tbPasswd;
        private System.Windows.Forms.CheckBox _cbSavePass;
        private System.Windows.Forms.Label label1;
    }
}