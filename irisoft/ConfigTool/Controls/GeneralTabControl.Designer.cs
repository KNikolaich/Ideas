using Configuration.Helpers;

namespace Configuration.Controls
{
    partial class GeneralTabControl
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
            Assistant.GetInstance().BeforeHasDifferents -= BeforeHasDifferents;
            foreach (var abonentDictValue in _abonentDict.Values)
            {
                var xElement = abonentDictValue.Element("id");
                xElement.Changed -= AbonentId_Changed;
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
            this._tabAbonsControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // _tabAbonsControl
            // 
            this._tabAbonsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabAbonsControl.Location = new System.Drawing.Point(0, 0);
            this._tabAbonsControl.Name = "_tabAbonsControl";
            this._tabAbonsControl.SelectedIndex = 0;
            this._tabAbonsControl.ShowToolTips = true;
            this._tabAbonsControl.Size = new System.Drawing.Size(428, 213);
            this._tabAbonsControl.TabIndex = 3;
            // 
            // GeneralTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tabAbonsControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GeneralTabControl";
            this.Size = new System.Drawing.Size(428, 213);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabAbonsControl;
    }
}
