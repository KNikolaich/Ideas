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
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 107);
            this.Controls.Add(this._tbPasswd);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this._bOk);
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
    }
}