namespace IrisoftWinViewForm
{
    partial class CalcCoefficientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalcCoefficientForm));
            this.tableLayoutPanelOnFill = new System.Windows.Forms.TableLayoutPanel();
            this._textBoxLeft = new System.Windows.Forms.TextBox();
            this._textBoxRight = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelOnButtom = new System.Windows.Forms.TableLayoutPanel();
            this._labelResult = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.bCalc = new System.Windows.Forms.Button();
            this.tableLayoutPanelOnFill.SuspendLayout();
            this.tableLayoutPanelOnButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelOnFill
            // 
            this.tableLayoutPanelOnFill.ColumnCount = 2;
            this.tableLayoutPanelOnFill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOnFill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOnFill.Controls.Add(this._textBoxLeft, 0, 0);
            this.tableLayoutPanelOnFill.Controls.Add(this._textBoxRight, 1, 0);
            this.tableLayoutPanelOnFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOnFill.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOnFill.Name = "tableLayoutPanelOnFill";
            this.tableLayoutPanelOnFill.RowCount = 1;
            this.tableLayoutPanelOnFill.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOnFill.Size = new System.Drawing.Size(839, 436);
            this.tableLayoutPanelOnFill.TabIndex = 1;
            // 
            // _textBoxLeft
            // 
            this._textBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBoxLeft.Location = new System.Drawing.Point(3, 3);
            this._textBoxLeft.Multiline = true;
            this._textBoxLeft.Name = "_textBoxLeft";
            this._textBoxLeft.Size = new System.Drawing.Size(413, 430);
            this._textBoxLeft.TabIndex = 1;
            this._textBoxLeft.Text = "Съешь же ещё этих мягких французских булок да выпей чаю";
            // 
            // _textBoxRight
            // 
            this._textBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBoxRight.Location = new System.Drawing.Point(422, 3);
            this._textBoxRight.Multiline = true;
            this._textBoxRight.Name = "_textBoxRight";
            this._textBoxRight.Size = new System.Drawing.Size(414, 430);
            this._textBoxRight.TabIndex = 0;
            this._textBoxRight.Text = "!!мягких ЖЕ франЦузских,булОк ещЁ этИх Съешь.да выПей?`ЧАЮ!!!";
            // 
            // tableLayoutPanelOnButtom
            // 
            this.tableLayoutPanelOnButtom.ColumnCount = 3;
            this.tableLayoutPanelOnButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOnButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelOnButtom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOnButtom.Controls.Add(this._labelResult, 1, 0);
            this.tableLayoutPanelOnButtom.Controls.Add(this.bExit, 2, 0);
            this.tableLayoutPanelOnButtom.Controls.Add(this.bCalc, 0, 0);
            this.tableLayoutPanelOnButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelOnButtom.Location = new System.Drawing.Point(0, 436);
            this.tableLayoutPanelOnButtom.Name = "tableLayoutPanelOnButtom";
            this.tableLayoutPanelOnButtom.RowCount = 1;
            this.tableLayoutPanelOnButtom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOnButtom.Size = new System.Drawing.Size(839, 43);
            this.tableLayoutPanelOnButtom.TabIndex = 0;
            // 
            // _labelResult
            // 
            this._labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelResult.AutoSize = true;
            this._labelResult.Location = new System.Drawing.Point(372, 0);
            this._labelResult.Name = "_labelResult";
            this._labelResult.Size = new System.Drawing.Size(94, 43);
            this._labelResult.TabIndex = 0;
            this._labelResult.Text = "результат";
            this._labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Location = new System.Drawing.Point(722, 3);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(114, 37);
            this.bExit.TabIndex = 1;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bCalc
            // 
            this.bCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCalc.Location = new System.Drawing.Point(3, 3);
            this.bCalc.Name = "bCalc";
            this.bCalc.Size = new System.Drawing.Size(114, 37);
            this.bCalc.TabIndex = 2;
            this.bCalc.Text = "Расчет";
            this.bCalc.UseVisualStyleBackColor = true;
            this.bCalc.Click += new System.EventHandler(this.bCalc_Click);
            // 
            // CalcCoefficientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 479);
            this.Controls.Add(this.tableLayoutPanelOnFill);
            this.Controls.Add(this.tableLayoutPanelOnButtom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalcCoefficientForm";
            this.Text = "Коэффициент похожести текстов";
            this.tableLayoutPanelOnFill.ResumeLayout(false);
            this.tableLayoutPanelOnFill.PerformLayout();
            this.tableLayoutPanelOnButtom.ResumeLayout(false);
            this.tableLayoutPanelOnButtom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOnFill;
        private System.Windows.Forms.TextBox _textBoxLeft;
        private System.Windows.Forms.TextBox _textBoxRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOnButtom;
        private System.Windows.Forms.Label _labelResult;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bCalc;
    }
}

