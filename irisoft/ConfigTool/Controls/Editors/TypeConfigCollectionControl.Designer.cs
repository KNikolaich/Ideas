namespace Configuration.Controls.Editors
{
    partial class TypeConfigCollectionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeConfigCollectionControl));
            this._bAdd = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this._groupBox = new System.Windows.Forms.GroupBox();
            this.labelTypeConfigs = new System.Windows.Forms.Label();
            this.panelUp = new System.Windows.Forms.Panel();
            this._labelComment = new System.Windows.Forms.Label();
            this._groupBox.SuspendLayout();
            this.panelUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _bAdd
            // 
            this._bAdd.ImageIndex = 0;
            this._bAdd.ImageList = this.imageList1;
            this._bAdd.Location = new System.Drawing.Point(7, 4);
            this._bAdd.Margin = new System.Windows.Forms.Padding(5);
            this._bAdd.Name = "_bAdd";
            this._bAdd.Padding = new System.Windows.Forms.Padding(2);
            this._bAdd.Size = new System.Drawing.Size(20, 20);
            this._bAdd.TabIndex = 1;
            this._bAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._bAdd.UseVisualStyleBackColor = true;
            this._bAdd.Click += new System.EventHandler(this._bAdd_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.ico");
            this.imageList1.Images.SetKeyName(1, "row_add_after.png");
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this.labelTypeConfigs);
            this._groupBox.Controls.Add(this.panelUp);
            this._groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox.Location = new System.Drawing.Point(0, 0);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(485, 59);
            this._groupBox.TabIndex = 2;
            this._groupBox.TabStop = false;
            // 
            // labelTypeConfigs
            // 
            this.labelTypeConfigs.AutoSize = true;
            this.labelTypeConfigs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTypeConfigs.Location = new System.Drawing.Point(7, -1);
            this.labelTypeConfigs.Name = "labelTypeConfigs";
            this.labelTypeConfigs.Size = new System.Drawing.Size(102, 18);
            this.labelTypeConfigs.TabIndex = 1;
            this.labelTypeConfigs.Text = "TypeConfigs";
            // 
            // panelUp
            // 
            this.panelUp.Controls.Add(this._labelComment);
            this.panelUp.Controls.Add(this._bAdd);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUp.Location = new System.Drawing.Point(3, 18);
            this.panelUp.Name = "panelUp";
            this.panelUp.Padding = new System.Windows.Forms.Padding(2);
            this.panelUp.Size = new System.Drawing.Size(479, 38);
            this.panelUp.TabIndex = 0;
            // 
            // _labelComment
            // 
            this._labelComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelComment.AutoSize = true;
            this._labelComment.Location = new System.Drawing.Point(39, 4);
            this._labelComment.Name = "_labelComment";
            this._labelComment.Size = new System.Drawing.Size(447, 13);
            this._labelComment.TabIndex = 3;
            this._labelComment.Text = "Настройки для разных типов документов и частей, экспортируемых в заданную СРО. ";
            // 
            // TypeConfigCollectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._groupBox);
            this.Name = "TypeConfigCollectionControl";
            this.Size = new System.Drawing.Size(485, 59);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.panelUp.ResumeLayout(false);
            this.panelUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _bAdd;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Label _labelComment;
        private System.Windows.Forms.Label labelTypeConfigs;
    }
}
