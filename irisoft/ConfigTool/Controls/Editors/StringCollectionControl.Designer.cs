namespace Configuration.Controls.Editors
{
    partial class StringCollectionControl
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
            if (_assistant != null)
            {
                _assistant.BeforeHasDifferents -= BeforeHasDifferents;
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
            this._gridControl = new Configuration.Controls.Editors.GridWithLabelControl();
            this._textBoxComment = new System.Windows.Forms.TextBox();
            this._textBoxTop = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _gridControl
            // 
            this._gridControl.AutoScroll = true;
            this._gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridControl.Location = new System.Drawing.Point(130, 13);
            this._gridControl.Name = "_gridControl";
            this._gridControl.Size = new System.Drawing.Size(549, 105);
            this._gridControl.TabIndex = 2;
            this._gridControl.VisibleTop = true;
            // 
            // _textBoxComment
            // 
            this._textBoxComment.Dock = System.Windows.Forms.DockStyle.Left;
            this._textBoxComment.Enabled = false;
            this._textBoxComment.ForeColor = System.Drawing.SystemColors.ControlDark;
            this._textBoxComment.Location = new System.Drawing.Point(0, 13);
            this._textBoxComment.Multiline = true;
            this._textBoxComment.Name = "_textBoxComment";
            this._textBoxComment.ReadOnly = true;
            this._textBoxComment.Size = new System.Drawing.Size(130, 105);
            this._textBoxComment.TabIndex = 1;
            // 
            // _textBoxTop
            // 
            this._textBoxTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._textBoxTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._textBoxTop.Location = new System.Drawing.Point(0, 0);
            this._textBoxTop.Padding = new System.Windows.Forms.Padding(0, 0, 3, 5);
            this._textBoxTop.Name = "_textBoxTop";
            this._textBoxTop.ReadOnly = true;
            this._textBoxTop.Size = new System.Drawing.Size(679, 13);
            this._textBoxTop.TabIndex = 2;
            // 
            // StringCollectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._gridControl);
            this.Controls.Add(this._textBoxComment);
            this.Controls.Add(this._textBoxTop);
            this.Name = "StringCollectionControl";
            this.Size = new System.Drawing.Size(679, 118);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox _textBoxComment;
        private GridWithLabelControl _gridControl;
        private System.Windows.Forms.TextBox _textBoxTop;
    }
}
