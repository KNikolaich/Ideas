namespace StaffTimes
{
    partial class StaffEditForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._textBoxRole = new System.Windows.Forms.TextBox();
            this._textBoxPasswd = new System.Windows.Forms.TextBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.lLogin = new System.Windows.Forms.Label();
            this.lPasswd = new System.Windows.Forms.Label();
            this.lRole = new System.Windows.Forms.Label();
            this._textBoxLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._textBoxRole, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this._textBoxPasswd, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.bExit, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.bOk, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lLogin, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lPasswd, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lRole, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this._textBoxLogin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._textBoxName, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 206);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // _textBoxRole
            // 
            this._textBoxRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBoxRole.Location = new System.Drawing.Point(186, 109);
            this._textBoxRole.Name = "_textBoxRole";
            this._textBoxRole.Size = new System.Drawing.Size(177, 20);
            this._textBoxRole.TabIndex = 3;
            // 
            // _textBoxPasswd
            // 
            this._textBoxPasswd.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBoxPasswd.Location = new System.Drawing.Point(186, 77);
            this._textBoxPasswd.Name = "_textBoxPasswd";
            this._textBoxPasswd.Size = new System.Drawing.Size(177, 20);
            this._textBoxPasswd.TabIndex = 2;
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Location = new System.Drawing.Point(186, 177);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(177, 23);
            this.bExit.TabIndex = 5;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.Location = new System.Drawing.Point(3, 177);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(177, 23);
            this.bOk.TabIndex = 4;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // lLogin
            // 
            this.lLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lLogin.AutoSize = true;
            this.lLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLogin.Location = new System.Drawing.Point(3, 42);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(177, 32);
            this.lLogin.TabIndex = 1;
            this.lLogin.Text = "Логин:";
            this.lLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lPasswd
            // 
            this.lPasswd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lPasswd.AutoSize = true;
            this.lPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPasswd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lPasswd.Location = new System.Drawing.Point(3, 74);
            this.lPasswd.Name = "lPasswd";
            this.lPasswd.Size = new System.Drawing.Size(177, 32);
            this.lPasswd.TabIndex = 2;
            this.lPasswd.Text = "Пароль:";
            this.lPasswd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lRole
            // 
            this.lRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lRole.AutoSize = true;
            this.lRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lRole.Location = new System.Drawing.Point(3, 106);
            this.lRole.Name = "lRole";
            this.lRole.Size = new System.Drawing.Size(177, 32);
            this.lRole.TabIndex = 2;
            this.lRole.Text = "Роль:";
            this.lRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _textBoxLogin
            // 
            this._textBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxLogin.Location = new System.Drawing.Point(186, 48);
            this._textBoxLogin.Name = "_textBoxLogin";
            this._textBoxLogin.Size = new System.Drawing.Size(177, 20);
            this._textBoxLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _textBoxName
            // 
            this._textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxName.Location = new System.Drawing.Point(186, 16);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(177, 20);
            this._textBoxName.TabIndex = 0;
            // 
            // StaffEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 206);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StaffEditForm";
            this.Text = "StaffEditForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.TextBox _textBoxPasswd;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Label lPasswd;
        private System.Windows.Forms.Label lRole;
        private System.Windows.Forms.TextBox _textBoxLogin;
        private System.Windows.Forms.TextBox _textBoxRole;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.Label label1;
    }
}