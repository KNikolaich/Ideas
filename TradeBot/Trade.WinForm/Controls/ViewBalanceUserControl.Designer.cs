namespace WindowsFormApp.Controls
{
    partial class ViewBalanceUserControl
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this._deEndCalc = new DevExpress.XtraEditors.DateEdit();
            this._deStartCalc = new DevExpress.XtraEditors.DateEdit();
            this.sbCalc = new DevExpress.XtraEditors.SimpleButton();
            this._meResultCalc = new DevExpress.XtraEditors.MemoEdit();
            this._gridControlOrders = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrigQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this._mePairInfo = new DevExpress.XtraEditors.MemoEdit();
            this._meBalance = new DevExpress.XtraEditors.MemoEdit();
            this._deLastView = new DevExpress.XtraEditors.DateEdit();
            this.layoutBalance = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLastView = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPairInfo = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.lciGridOrders = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this._lciDateFrom = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEndCalc = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBalance = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._deEndCalc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deEndCalc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deStartCalc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deStartCalc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._meResultCalc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridControlOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mePairInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._meBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deLastView.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deLastView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLastView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPairInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._lciDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEndCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this._deEndCalc);
            this.layoutControl1.Controls.Add(this._deStartCalc);
            this.layoutControl1.Controls.Add(this.sbCalc);
            this.layoutControl1.Controls.Add(this._meResultCalc);
            this.layoutControl1.Controls.Add(this._gridControlOrders);
            this.layoutControl1.Controls.Add(this._mePairInfo);
            this.layoutControl1.Controls.Add(this._meBalance);
            this.layoutControl1.Controls.Add(this._deLastView);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2245, 129, 718, 518);
            this.layoutControl1.Root = this.layoutBalance;
            this.layoutControl1.Size = new System.Drawing.Size(706, 520);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // _deEndCalc
            // 
            this._deEndCalc.EditValue = null;
            this._deEndCalc.Location = new System.Drawing.Point(298, 82);
            this._deEndCalc.Name = "_deEndCalc";
            this._deEndCalc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._deEndCalc.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this._deEndCalc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._deEndCalc.Properties.DisplayFormat.FormatString = "g";
            this._deEndCalc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._deEndCalc.Properties.EditFormat.FormatString = "g";
            this._deEndCalc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._deEndCalc.Properties.Mask.EditMask = "g";
            this._deEndCalc.Size = new System.Drawing.Size(277, 20);
            this._deEndCalc.StyleController = this.layoutControl1;
            this._deEndCalc.TabIndex = 11;
            // 
            // _deStartCalc
            // 
            this._deStartCalc.EditValue = null;
            this._deStartCalc.Location = new System.Drawing.Point(298, 58);
            this._deStartCalc.Name = "_deStartCalc";
            this._deStartCalc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._deStartCalc.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this._deStartCalc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._deStartCalc.Properties.DisplayFormat.FormatString = "g";
            this._deStartCalc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this._deStartCalc.Properties.EditFormat.FormatString = "g";
            this._deStartCalc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._deStartCalc.Properties.Mask.EditMask = "g";
            this._deStartCalc.Size = new System.Drawing.Size(277, 20);
            this._deStartCalc.StyleController = this.layoutControl1;
            this._deStartCalc.TabIndex = 10;
            // 
            // sbCalc
            // 
            this.sbCalc.Location = new System.Drawing.Point(579, 42);
            this.sbCalc.Name = "sbCalc";
            this.sbCalc.Size = new System.Drawing.Size(103, 22);
            this.sbCalc.StyleController = this.layoutControl1;
            this.sbCalc.TabIndex = 9;
            this.sbCalc.Text = "Считать";
            this.sbCalc.Click += new System.EventHandler(this.sbCalc_Click);
            // 
            // _meResultCalc
            // 
            this._meResultCalc.Location = new System.Drawing.Point(298, 122);
            this._meResultCalc.Name = "_meResultCalc";
            this._meResultCalc.Size = new System.Drawing.Size(384, 122);
            this._meResultCalc.StyleController = this.layoutControl1;
            this._meResultCalc.TabIndex = 8;
            // 
            // _gridControlOrders
            // 
            this._gridControlOrders.Location = new System.Drawing.Point(12, 260);
            this._gridControlOrders.MainView = this.gridView1;
            this._gridControlOrders.Name = "_gridControlOrders";
            this._gridControlOrders.Size = new System.Drawing.Size(682, 248);
            this._gridControlOrders.TabIndex = 7;
            this._gridControlOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSymbol,
            this.colStatus,
            this.colTime,
            this.colSide,
            this.colPrice,
            this.colOrigQty});
            this.gridView1.GridControl = this._gridControlOrders;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStatus, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTime, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colSymbol
            // 
            this.colSymbol.Caption = "Валютная пара";
            this.colSymbol.FieldName = "Symbol";
            this.colSymbol.Name = "colSymbol";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Статус";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            // 
            // colTime
            // 
            this.colTime.Caption = "Время";
            this.colTime.DisplayFormat.FormatString = "G";
            this.colTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTime.FieldName = "CalcTime";
            this.colTime.Name = "colTime";
            this.colTime.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 0;
            // 
            // colSide
            // 
            this.colSide.Caption = "Сторона";
            this.colSide.FieldName = "Side";
            this.colSide.Name = "colSide";
            this.colSide.Visible = true;
            this.colSide.VisibleIndex = 1;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Цена";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            // 
            // colOrigQty
            // 
            this.colOrigQty.Caption = "Объем";
            this.colOrigQty.FieldName = "OrigQty";
            this.colOrigQty.Name = "colOrigQty";
            this.colOrigQty.Visible = true;
            this.colOrigQty.VisibleIndex = 3;
            // 
            // _mePairInfo
            // 
            this._mePairInfo.Location = new System.Drawing.Point(12, 68);
            this._mePairInfo.Name = "_mePairInfo";
            this._mePairInfo.Size = new System.Drawing.Size(265, 84);
            this._mePairInfo.StyleController = this.layoutControl1;
            this._mePairInfo.TabIndex = 6;
            // 
            // _meBalance
            // 
            this._meBalance.Location = new System.Drawing.Point(12, 172);
            this._meBalance.Name = "_meBalance";
            this._meBalance.Size = new System.Drawing.Size(265, 84);
            this._meBalance.StyleController = this.layoutControl1;
            this._meBalance.TabIndex = 6;
            // 
            // _deLastView
            // 
            this._deLastView.EditValue = null;
            this._deLastView.Location = new System.Drawing.Point(12, 28);
            this._deLastView.Name = "_deLastView";
            this._deLastView.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._deLastView.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this._deLastView.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._deLastView.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "g";
            this._deLastView.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._deLastView.Properties.CalendarTimeProperties.EditFormat.FormatString = "g";
            this._deLastView.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._deLastView.Properties.CalendarTimeProperties.Mask.EditMask = "g";
            this._deLastView.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this._deLastView.Properties.DisplayFormat.FormatString = "g";
            this._deLastView.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._deLastView.Properties.EditFormat.FormatString = "g";
            this._deLastView.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._deLastView.Properties.Mask.EditMask = "g";
            this._deLastView.Properties.ReadOnly = true;
            this._deLastView.Properties.ShowWeekNumbers = true;
            this._deLastView.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this._deLastView.Size = new System.Drawing.Size(265, 20);
            this._deLastView.StyleController = this.layoutControl1;
            this._deLastView.TabIndex = 4;
            this._deLastView.EditValueChanged += new System.EventHandler(this._deLastView_EditValueChanged);
            // 
            // layoutBalance
            // 
            this.layoutBalance.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutBalance.GroupBordersVisible = false;
            this.layoutBalance.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLastView,
            this.lciPairInfo,
            this.splitterItem1,
            this.lciGridOrders,
            this.layoutControlGroup1,
            this.lciBalance});
            this.layoutBalance.Location = new System.Drawing.Point(0, 0);
            this.layoutBalance.Name = "Root";
            this.layoutBalance.Size = new System.Drawing.Size(706, 520);
            this.layoutBalance.TextVisible = false;
            // 
            // lciLastView
            // 
            this.lciLastView.Control = this._deLastView;
            this.lciLastView.Location = new System.Drawing.Point(0, 0);
            this.lciLastView.Name = "lciLastView";
            this.lciLastView.Size = new System.Drawing.Size(269, 40);
            this.lciLastView.Text = "Последний просмотр";
            this.lciLastView.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciLastView.TextSize = new System.Drawing.Size(105, 13);
            // 
            // lciPairInfo
            // 
            this.lciPairInfo.Control = this._mePairInfo;
            this.lciPairInfo.Location = new System.Drawing.Point(0, 40);
            this.lciPairInfo.MaxSize = new System.Drawing.Size(269, 0);
            this.lciPairInfo.MinSize = new System.Drawing.Size(269, 36);
            this.lciPairInfo.Name = "lciPairInfo";
            this.lciPairInfo.Size = new System.Drawing.Size(269, 104);
            this.lciPairInfo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciPairInfo.Text = "Информация о паре";
            this.lciPairInfo.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciPairInfo.TextSize = new System.Drawing.Size(105, 13);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(269, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 248);
            // 
            // lciGridOrders
            // 
            this.lciGridOrders.Control = this._gridControlOrders;
            this.lciGridOrders.Location = new System.Drawing.Point(0, 248);
            this.lciGridOrders.Name = "lciGridOrders";
            this.lciGridOrders.Size = new System.Drawing.Size(686, 252);
            this.lciGridOrders.Text = "Мои ордера";
            this.lciGridOrders.TextSize = new System.Drawing.Size(0, 0);
            this.lciGridOrders.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this._lciDateFrom,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.lciEndCalc});
            this.layoutControlGroup1.Location = new System.Drawing.Point(274, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(412, 248);
            this.layoutControlGroup1.Text = "Расчет результатов реальных действий";
            // 
            // _lciDateFrom
            // 
            this._lciDateFrom.Control = this._deStartCalc;
            this._lciDateFrom.Location = new System.Drawing.Point(0, 0);
            this._lciDateFrom.Name = "_lciDateFrom";
            this._lciDateFrom.Size = new System.Drawing.Size(281, 40);
            this._lciDateFrom.Text = "Дата с";
            this._lciDateFrom.TextLocation = DevExpress.Utils.Locations.Top;
            this._lciDateFrom.TextSize = new System.Drawing.Size(105, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbCalc;
            this.layoutControlItem2.Location = new System.Drawing.Point(281, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(107, 64);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this._meResultCalc;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(388, 142);
            this.layoutControlItem1.Text = "Результаты расчета";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(105, 13);
            // 
            // lciEndCalc
            // 
            this.lciEndCalc.Control = this._deEndCalc;
            this.lciEndCalc.Location = new System.Drawing.Point(0, 40);
            this.lciEndCalc.Name = "lciEndCalc";
            this.lciEndCalc.Size = new System.Drawing.Size(281, 24);
            this.lciEndCalc.Text = "дата по";
            this.lciEndCalc.TextSize = new System.Drawing.Size(0, 0);
            this.lciEndCalc.TextVisible = false;
            // 
            // lciBalance
            // 
            this.lciBalance.Control = this._meBalance;
            this.lciBalance.Location = new System.Drawing.Point(0, 144);
            this.lciBalance.Name = "lciBalance";
            this.lciBalance.Size = new System.Drawing.Size(269, 104);
            this.lciBalance.Text = "баланс аккаунта";
            this.lciBalance.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciBalance.TextSize = new System.Drawing.Size(105, 13);
            // 
            // ViewBalanceUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ViewBalanceUserControl";
            this.Size = new System.Drawing.Size(706, 520);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._deEndCalc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deEndCalc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deStartCalc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deStartCalc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._meResultCalc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridControlOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mePairInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._meBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deLastView.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deLastView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLastView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPairInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._lciDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEndCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutBalance;
        private DevExpress.XtraEditors.DateEdit _deLastView;
        private DevExpress.XtraLayout.LayoutControlItem lciLastView;
        private DevExpress.XtraEditors.MemoEdit _mePairInfo;
        private DevExpress.XtraEditors.MemoEdit _meBalance;
        private DevExpress.XtraLayout.LayoutControlItem lciBalance;
        private DevExpress.XtraLayout.LayoutControlItem lciPairInfo;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraGrid.GridControl _gridControlOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem lciGridOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSide;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOrigQty;
        private DevExpress.XtraEditors.SimpleButton sbCalc;
        private DevExpress.XtraEditors.MemoEdit _meResultCalc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit _deEndCalc;
        private DevExpress.XtraEditors.DateEdit _deStartCalc;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem _lciDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem lciEndCalc;
    }
}
