namespace MouseRecord
{
    partial class MouseRecControl
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
            this.bRec = new System.Windows.Forms.Button();
            this.bPlay = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this._listBoxResult = new System.Windows.Forms.ListBox();
            this.tableLayoutPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // bRec
            // 
            this.bRec.Location = new System.Drawing.Point(3, 3);
            this.bRec.Name = "bRec";
            this.bRec.Size = new System.Drawing.Size(75, 23);
            this.bRec.TabIndex = 0;
            this.bRec.Text = "Запись";
            this.bRec.UseVisualStyleBackColor = true;
            this.bRec.Click += new System.EventHandler(this.bRec_Click);
            // 
            // bPlay
            // 
            this.bPlay.Location = new System.Drawing.Point(89, 3);
            this.bPlay.Name = "bPlay";
            this.bPlay.Size = new System.Drawing.Size(75, 23);
            this.bPlay.TabIndex = 1;
            this.bPlay.Text = "Играть";
            this.bPlay.UseVisualStyleBackColor = true;
            this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(175, 3);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(69, 23);
            this.bStop.TabIndex = 2;
            this.bStop.Text = "Стоп";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 3;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanelTop.Controls.Add(this.bRec, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.bStop, 2, 0);
            this.tableLayoutPanelTop.Controls.Add(this.bPlay, 1, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 1;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(247, 32);
            this.tableLayoutPanelTop.TabIndex = 3;
            // 
            // _listBoxResult
            // 
            this._listBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listBoxResult.FormattingEnabled = true;
            this._listBoxResult.Location = new System.Drawing.Point(0, 32);
            this._listBoxResult.Name = "_listBoxResult";
            this._listBoxResult.Size = new System.Drawing.Size(247, 238);
            this._listBoxResult.TabIndex = 4;
            // 
            // MouseRecControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listBoxResult);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Name = "MouseRecControl";
            this.Size = new System.Drawing.Size(247, 270);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bRec;
        private System.Windows.Forms.Button bPlay;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.ListBox _listBoxResult;
    }
}
