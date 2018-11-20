namespace WindowsFormApp.Controls
{
    partial class ManualExcangeControl
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
            this._sbBuyAll = new DevExpress.XtraEditors.SimpleButton();
            this._sbSaleAll = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // _sbBuyAll
            // 
            this._sbBuyAll.Location = new System.Drawing.Point(0, 3);
            this._sbBuyAll.Name = "_sbBuyAll";
            this._sbBuyAll.Size = new System.Drawing.Size(97, 23);
            this._sbBuyAll.TabIndex = 0;
            this._sbBuyAll.Text = "Купить на все";
            this._sbBuyAll.Click += new System.EventHandler(this._sbBuyAll_Click);
            // 
            // _sbSaleAll
            // 
            this._sbSaleAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._sbSaleAll.Location = new System.Drawing.Point(331, 3);
            this._sbSaleAll.Name = "_sbSaleAll";
            this._sbSaleAll.Size = new System.Drawing.Size(97, 23);
            this._sbSaleAll.TabIndex = 0;
            this._sbSaleAll.Text = "Продать все";
            this._sbSaleAll.Click += new System.EventHandler(this._sbSaleAll_Click);
            // 
            // ManualExcangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._sbSaleAll);
            this.Controls.Add(this._sbBuyAll);
            this.Name = "ManualExcangeControl";
            this.Size = new System.Drawing.Size(431, 298);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton _sbBuyAll;
        private DevExpress.XtraEditors.SimpleButton _sbSaleAll;
    }
}