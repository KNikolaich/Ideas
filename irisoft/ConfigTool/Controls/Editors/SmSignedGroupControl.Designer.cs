using System.Windows.Forms;

namespace Configuration.Controls.Editors
{
    partial class SmSignedGroupControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._groupBoxSigned = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._beSmSignedContentControl = new Configuration.Controls.Editors.BoolEditControl();
            this._smSignedIULControl = new Configuration.Controls.Editors.BoolEditControl();
            this._signVoteControl = new Configuration.Controls.ElementBaseControl();
            this._signActivityControl = new Configuration.Controls.ElementBaseControl();
            this._groupBoxSigned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBoxSigned
            // 
            this._groupBoxSigned.Controls.Add(this.splitContainer1);
            this._groupBoxSigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxSigned.Location = new System.Drawing.Point(0, 5);
            this._groupBoxSigned.Name = "_groupBoxSigned";
            this._groupBoxSigned.Size = new System.Drawing.Size(658, 60);
            this._groupBoxSigned.TabIndex = 0;
            this._groupBoxSigned.TabStop = false;
            this._groupBoxSigned.Text = "Свойства экспорта спец-пакетов";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._signVoteControl);
            this.splitContainer1.Panel1.Controls.Add(this._signActivityControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._beSmSignedContentControl);
            this.splitContainer1.Panel2.Controls.Add(this._smSignedIULControl);
            this.splitContainer1.Size = new System.Drawing.Size(652, 41);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 1;
            // 
            // _beSmSignedContentControl
            // 
            this._beSmSignedContentControl.AutoScroll = true;
            this._beSmSignedContentControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._beSmSignedContentControl.Location = new System.Drawing.Point(0, 23);
            this._beSmSignedContentControl.Name = "_beSmSignedContentControl";
            this._beSmSignedContentControl.Size = new System.Drawing.Size(283, 23);
            this._beSmSignedContentControl.TabIndex = 1;
            // 
            // _smSignedIULControl
            // 
            this._smSignedIULControl.AutoScroll = true;
            this._smSignedIULControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._smSignedIULControl.Location = new System.Drawing.Point(0, 0);
            this._smSignedIULControl.Name = "_smSignedIULControl";
            this._smSignedIULControl.Size = new System.Drawing.Size(283, 23);
            this._smSignedIULControl.TabIndex = 0;
            // 
            // _signVoteControl
            // 
            this._signVoteControl.AutoScroll = true;
            this._signVoteControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._signVoteControl.Location = new System.Drawing.Point(0, 23);
            this._signVoteControl.Name = "_signVoteControl";
            this._signVoteControl.Size = new System.Drawing.Size(365, 23);
            this._signVoteControl.TabIndex = 1;
            // 
            // _signActivityControl
            // 
            this._signActivityControl.AutoScroll = true;
            this._signActivityControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._signActivityControl.Location = new System.Drawing.Point(0, 0);
            this._signActivityControl.Name = "_signActivityControl";
            this._signActivityControl.Size = new System.Drawing.Size(365, 23);
            this._signActivityControl.TabIndex = 0;
            // 
            // SmSignedGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._groupBoxSigned);
            this.Name = "SmSignedGroupControl";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Size = new System.Drawing.Size(658, 65);
            this._groupBoxSigned.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBoxSigned;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BoolEditControl _beSmSignedContentControl;
        private BoolEditControl _smSignedIULControl;
        private ElementBaseControl _signVoteControl;
        private ElementBaseControl _signActivityControl;
    }
}
