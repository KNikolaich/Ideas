namespace StaffTimes
{
    partial class ActiveProjectsEditForm
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
            this._checkedListBoxControl = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkBoxForAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._checkedListBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // _checkedListBoxControl
            // 
            this._checkedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._checkedListBoxControl.Location = new System.Drawing.Point(5, 22);
            this._checkedListBoxControl.Name = "_checkedListBoxControl";
            this._checkedListBoxControl.Size = new System.Drawing.Size(496, 318);
            this._checkedListBoxControl.TabIndex = 0;
            this._checkedListBoxControl.ToolTip = "Включаем/выключаем проекты, с которые работаем.";
            // 
            // checkBoxForAll
            // 
            this.checkBoxForAll.AutoSize = true;
            this.checkBoxForAll.Checked = true;
            this.checkBoxForAll.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxForAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxForAll.Location = new System.Drawing.Point(5, 5);
            this.checkBoxForAll.Name = "checkBoxForAll";
            this.checkBoxForAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxForAll.Size = new System.Drawing.Size(496, 17);
            this.checkBoxForAll.TabIndex = 1;
            this.checkBoxForAll.Text = "Отметить/снять сразу для всех проектов";
            this.checkBoxForAll.UseVisualStyleBackColor = true;
            // 
            // ActiveProjectsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 345);
            this.Controls.Add(this._checkedListBoxControl);
            this.Controls.Add(this.checkBoxForAll);
            this.Name = "ActiveProjectsEditForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбираем проекты, в которые можно логировать время.";
            ((System.ComponentModel.ISupportInitialize)(this._checkedListBoxControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl _checkedListBoxControl;
        private System.Windows.Forms.CheckBox checkBoxForAll;
    }
}