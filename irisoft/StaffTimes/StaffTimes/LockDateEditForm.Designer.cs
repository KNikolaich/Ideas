namespace StaffTimes
{
    partial class LockDateEditForm
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
            this._dtpLock = new System.Windows.Forms.DateTimePicker();
            this._bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _dtpLock
            // 
            this._dtpLock.Location = new System.Drawing.Point(12, 15);
            this._dtpLock.Name = "_dtpLock";
            this._dtpLock.Size = new System.Drawing.Size(200, 20);
            this._dtpLock.TabIndex = 0;
            // 
            // _bSave
            // 
            this._bSave.Location = new System.Drawing.Point(219, 15);
            this._bSave.Name = "_bSave";
            this._bSave.Size = new System.Drawing.Size(82, 21);
            this._bSave.TabIndex = 1;
            this._bSave.Text = "Ок";
            this._bSave.UseVisualStyleBackColor = true;
            this._bSave.Click += new System.EventHandler(this._bSave_Click);
            // 
            // LockDateEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 47);
            this.Controls.Add(this._bSave);
            this.Controls.Add(this._dtpLock);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockDateEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дата блокировки записей";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _dtpLock;
        private System.Windows.Forms.Button _bSave;
    }
}