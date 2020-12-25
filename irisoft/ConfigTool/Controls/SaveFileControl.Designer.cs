namespace Configuration.Controls
{
    partial class SaveFileControl
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bDifference = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbLeft = new System.Windows.Forms.RichTextBox();
            this.rtfRight = new System.Windows.Forms.RichTextBox();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.bSave);
            this.panelBottom.Controls.Add(this.bDifference);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 302);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(547, 29);
            this.panelBottom.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(469, 3);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bDifference
            // 
            this.bDifference.Location = new System.Drawing.Point(3, 3);
            this.bDifference.Name = "bDifference";
            this.bDifference.Size = new System.Drawing.Size(75, 23);
            this.bDifference.TabIndex = 0;
            this.bDifference.Text = "Сравнить";
            this.bDifference.UseVisualStyleBackColor = true;
            this.bDifference.Click += new System.EventHandler(this.bDifference_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtfRight);
            this.splitContainer1.Size = new System.Drawing.Size(547, 302);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 1;
            // 
            // rtbLeft
            // 
            this.rtbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLeft.Location = new System.Drawing.Point(0, 0);
            this.rtbLeft.Name = "rtbLeft";
            this.rtbLeft.Size = new System.Drawing.Size(261, 302);
            this.rtbLeft.TabIndex = 0;
            this.rtbLeft.Text = "";
            this.rtbLeft.VScroll += new System.EventHandler(this.rtbLeft_VScroll);
            // 
            // rtfRight
            // 
            this.rtfRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfRight.Location = new System.Drawing.Point(0, 0);
            this.rtfRight.Name = "rtfRight";
            this.rtfRight.Size = new System.Drawing.Size(282, 302);
            this.rtfRight.TabIndex = 0;
            this.rtfRight.Text = "";
            this.rtfRight.VScroll += new System.EventHandler(this.rtfRight_VScroll);
            // 
            // SaveFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelBottom);
            this.Name = "SaveFileControl";
            this.Size = new System.Drawing.Size(547, 331);
            this.panelBottom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbLeft;
        private System.Windows.Forms.RichTextBox rtfRight;
        private System.Windows.Forms.Button bDifference;
        private System.Windows.Forms.Button bSave;
    }
}
