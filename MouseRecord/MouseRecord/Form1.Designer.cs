namespace MouseRecord
{
    partial class Form1
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
            this.mouseRecControl1 = new MouseRecord.MouseRecControl();
            this.userControl11 = new MouseRecord.UserControl1();
            this.SuspendLayout();
            // 
            // mouseRecControl1
            // 
            this.mouseRecControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.mouseRecControl1.Location = new System.Drawing.Point(0, 0);
            this.mouseRecControl1.Name = "mouseRecControl1";
            this.mouseRecControl1.Size = new System.Drawing.Size(199, 671);
            this.mouseRecControl1.TabIndex = 0;
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(199, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(694, 671);
            this.userControl11.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 671);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.mouseRecControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MouseRecControl mouseRecControl1;
        private UserControl1 userControl11;

    }
}

