
using System.Drawing;

namespace Configuration.Controls.Editors
{
    partial class ContainerConfigsGroupControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerConfigsGroupControl));
            this._groupBox = new System.Windows.Forms.GroupBox();
            this.labelCc = new System.Windows.Forms.Label();
            this._panelTop = new System.Windows.Forms.Panel();
            this._tbComment = new System.Windows.Forms.TextBox();
            this._bAdd = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this._groupBox.SuspendLayout();
            this._panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this.labelCc);
            this._groupBox.Controls.Add(this._panelTop);
            this._groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox.Location = new System.Drawing.Point(0, 0);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(219, 46);
            this._groupBox.TabIndex = 0;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "groupBox1";
            // 
            // labelCc
            // 
            this.labelCc.AutoSize = true;
            this.labelCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCc.Location = new System.Drawing.Point(6, 0);
            this.labelCc.Name = "labelCc";
            this.labelCc.Size = new System.Drawing.Size(130, 18);
            this.labelCc.TabIndex = 1;
            this.labelCc.Text = "ContainerConfigs";
            // 
            // _panelTop
            // 
            this._panelTop.Controls.Add(this._tbComment);
            this._panelTop.Controls.Add(this._bAdd);
            this._panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelTop.Location = new System.Drawing.Point(3, 16);
            this._panelTop.Name = "_panelTop";
            this._panelTop.Size = new System.Drawing.Size(213, 30);
            this._panelTop.TabIndex = 0;
            // 
            // _tbComment
            // 
            this._tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbComment.Enabled = false;
            this._tbComment.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._tbComment.Location = new System.Drawing.Point(29, 0);
            this._tbComment.Multiline = true;
            this._tbComment.Name = "_tbComment";
            this._tbComment.ReadOnly = true;
            this._tbComment.Size = new System.Drawing.Size(181, 30);
            this._tbComment.TabIndex = 1;
            this._tbComment.Text = "Тут какой то комментарий должен быть";
            // 
            // _bAdd
            // 
            this._bAdd.ImageIndex = 1;
            this._bAdd.ImageList = this.imageList1;
            this._bAdd.Location = new System.Drawing.Point(6, 3);
            this._bAdd.Name = "_bAdd";
            this._bAdd.Size = new System.Drawing.Size(20, 20);
            this._bAdd.TabIndex = 0;
            this._bAdd.UseVisualStyleBackColor = true;
            this._bAdd.Click += new System.EventHandler(this._bAdd_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "row_add_after.png");
            this.imageList1.Images.SetKeyName(1, "plus.ico");
            // 
            // ContainerConfigsGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._groupBox);
            this.Name = "ContainerConfigsGroupControl";
            this.Size = new System.Drawing.Size(219, 46);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this._panelTop.ResumeLayout(false);
            this._panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.Panel _panelTop;
        private System.Windows.Forms.Button _bAdd;
        private System.Windows.Forms.TextBox _tbComment;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labelCc;
    }
}
