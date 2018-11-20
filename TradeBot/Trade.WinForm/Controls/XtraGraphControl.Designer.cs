namespace WindowsFormApp.Controls
{
    partial class XtraGraphControl
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
            DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY2 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY3 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY4 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StepLineSeriesView stepLineSeriesView1 = new DevExpress.XtraCharts.StepLineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StepLineSeriesView stepLineSeriesView2 = new DevExpress.XtraCharts.StepLineSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView2 = new DevExpress.XtraCharts.AreaSeriesView();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView5 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            this.usdtCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.stochRsiK_Collection = new DevExpress.Xpo.XPCollection(this.components);
            this.StochRSI_DCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.btcCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.rsiCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.rsiTrandCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.usdtCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stochRsiK_Collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StochRSI_DCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btcCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiTrandCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stepLineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stepLineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).BeginInit();
            this.SuspendLayout();
            // 
            // usdtCollection
            // 
            this.usdtCollection.CriteriaString = "StartsWith([CurrencyName], \'USDT\')";
            this.usdtCollection.DisplayableProperties = "ID;Volume;CurrencyName;Date;Price";
            this.usdtCollection.ObjectType = typeof(Trader.Balance);
            this.usdtCollection.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[Date]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // stochRsiK_Collection
            // 
            this.stochRsiK_Collection.CriteriaString = "[CurrencyName] = \'StochRSI_K\' And [Volume] < 500.0m";
            this.stochRsiK_Collection.DisplayableProperties = "Volume;CurrencyName;Date";
            this.stochRsiK_Collection.ObjectType = typeof(Trader.Balance);
            this.stochRsiK_Collection.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[Date]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // StochRSI_DCollection
            // 
            this.StochRSI_DCollection.CriteriaString = "[CurrencyName] = \'StochRSI_D\' And [Volume] < 500.0m";
            this.StochRSI_DCollection.DisplayableProperties = "Volume;CurrencyName;Date;Price";
            this.StochRSI_DCollection.ObjectType = typeof(Trader.Balance);
            this.StochRSI_DCollection.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[Date]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // btcCollection
            // 
            this.btcCollection.CriteriaString = "[CurrencyName] = \'BTC\'";
            this.btcCollection.DisplayableProperties = "ID;Volume;CurrencyName;Date;Price";
            this.btcCollection.ObjectType = typeof(Trader.Balance);
            this.btcCollection.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[Date]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // rsiCollection
            // 
            this.rsiCollection.CriteriaString = "[CurrencyName] = \'Rsi\'";
            this.rsiCollection.DisplayableProperties = "Volume;CurrencyName;Date;Price";
            this.rsiCollection.ObjectType = typeof(Trader.Balance);
            this.rsiCollection.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[Date]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // rsiTrandCollection
            // 
            this.rsiTrandCollection.CriteriaString = "[CurrencyName] = \'RSI_trand\'";
            this.rsiTrandCollection.DisplayableProperties = "Volume;CurrencyName;Date;Price";
            this.rsiTrandCollection.ObjectType = typeof(Trader.Balance);
            this.rsiTrandCollection.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[Date]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // chartControl1
            // 
            this.chartControl1.DataBindings = null;
            this.chartControl1.DataSource = this.StochRSI_DCollection;
            xyDiagram1.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
            xyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Minute;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Color = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            constantLine1.AxisValueSerializable = "30";
            constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            constantLine1.Name = "_buttomLevel";
            constantLine1.ShowInLegend = false;
            constantLine1.Title.Text = "перепроданность";
            constantLine2.AxisValueSerializable = "70";
            constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            constantLine2.Name = "_topLevel";
            constantLine2.ShowInLegend = false;
            constantLine2.Title.Text = "перекупленность";
            xyDiagram1.AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            constantLine1,
            constantLine2});
            xyDiagram1.AxisY.Interlaced = true;
            xyDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "";
            xyDiagram1.AxisY.VisualRange.Auto = false;
            xyDiagram1.AxisY.VisualRange.MaxValueSerializable = "90";
            xyDiagram1.AxisY.VisualRange.MinValueSerializable = "10";
            xyDiagram1.AxisY.WholeRange.Auto = false;
            xyDiagram1.AxisY.WholeRange.MaxValueSerializable = "90";
            xyDiagram1.AxisY.WholeRange.MinValueSerializable = "10";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            secondaryAxisY1.Alignment = DevExpress.XtraCharts.AxisAlignment.Near;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "AxisY USD";
            secondaryAxisY1.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY2.Alignment = DevExpress.XtraCharts.AxisAlignment.Near;
            secondaryAxisY2.AxisID = 1;
            secondaryAxisY2.Name = "AxisY BTC";
            secondaryAxisY2.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY2.VisibleInPanesSerializable = "-1";
            secondaryAxisY3.AxisID = 2;
            secondaryAxisY3.Name = "AxisY Hysto";
            secondaryAxisY3.VisibleInPanesSerializable = "-1";
            secondaryAxisY3.VisualRange.Auto = false;
            secondaryAxisY3.VisualRange.MaxValueSerializable = "100";
            secondaryAxisY3.VisualRange.MinValueSerializable = "0";
            secondaryAxisY3.WholeRange.Auto = false;
            secondaryAxisY3.WholeRange.MaxValueSerializable = "100";
            secondaryAxisY3.WholeRange.MinValueSerializable = "0";
            secondaryAxisY4.AxisID = 3;
            secondaryAxisY4.Name = "AxisY Signal";
            secondaryAxisY4.Tickmarks.Visible = false;
            secondaryAxisY4.VisibleInPanesSerializable = "-1";
            secondaryAxisY5.AxisID = 4;
            secondaryAxisY5.LabelVisibilityMode = DevExpress.XtraCharts.AxisLabelVisibilityMode.AutoGeneratedAndCustom;
            secondaryAxisY5.Name = "AxisY Price";
            secondaryAxisY5.VisibleInPanesSerializable = "-1";
            secondaryAxisY5.WholeRange.Auto = false;
            secondaryAxisY5.WholeRange.MaxValueSerializable = "20000";
            secondaryAxisY5.WholeRange.MinValueSerializable = "6000";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1,
            secondaryAxisY2,
            secondaryAxisY3,
            secondaryAxisY4,
            secondaryAxisY5});
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.chartControl1.Legend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Marquee";
            this.chartControl1.SeriesDataMember = "CurrencyName";
            series1.ArgumentDataMember = "Date";
            series1.DataSource = this.usdtCollection;
            series1.Name = "USD";
            series1.ToolTipHintDataMember = "Volume";
            series1.ValueDataMembersSerializable = "Volume";
            stepLineSeriesView1.AxisYName = "AxisY USD";
            stepLineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            series1.View = stepLineSeriesView1;
            series2.ArgumentDataMember = "Date";
            series2.DataSource = this.stochRsiK_Collection;
            series2.Name = "StochRSI K";
            series2.ToolTipHintDataMember = "Volume";
            series2.ValueDataMembersSerializable = "Volume";
            areaSeriesView1.AxisYName = "AxisY Hysto";
            areaSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(197)))), ((int)(((byte)(246)))), ((int)(((byte)(49)))));
            series2.View = areaSeriesView1;
            series3.ArgumentDataMember = "Date";
            series3.DataSource = this.StochRSI_DCollection;
            series3.LegendName = "Default Legend";
            series3.Name = "StochRSI D";
            series3.ToolTipHintDataMember = "Volume";
            series3.ValueDataMembersSerializable = "Volume";
            lineSeriesView1.AxisYName = "AxisY Hysto";
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series3.View = lineSeriesView1;
            series4.ArgumentDataMember = "Date";
            series4.DataSource = this.btcCollection;
            series4.Name = "BTC";
            series4.ValueDataMembersSerializable = "Volume";
            stepLineSeriesView2.AxisYName = "AxisY BTC";
            stepLineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            series4.View = stepLineSeriesView2;
            series5.ArgumentDataMember = "Date";
            series5.Name = "Price";
            series5.ToolTipHintDataMember = "Price";
            series5.ValueDataMembersSerializable = "Price";
            lineSeriesView2.AxisYName = "AxisY Price";
            lineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series5.View = lineSeriesView2;
            series6.ArgumentDataMember = "Date";
            series6.DataSource = this.rsiCollection;
            series6.Name = "RSI";
            series6.ToolTipHintDataMember = "CurrencyName";
            series6.ValueDataMembersSerializable = "Volume";
            areaSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            areaSeriesView2.Transparency = ((byte)(200));
            series6.View = areaSeriesView2;
            series7.ArgumentDataMember = "Date";
            series7.DataSource = this.rsiCollection;
            series7.Name = "RSI stoch";
            series7.ToolTipHintDataMember = "Price";
            series7.ValueDataMembersSerializable = "Price";
            lineSeriesView3.AxisYName = "AxisY Hysto";
            lineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series7.View = lineSeriesView3;
            series8.ArgumentDataMember = "Date";
            series8.DataSource = this.rsiTrandCollection;
            series8.LegendName = "Default Legend";
            series8.Name = "trand line";
            series8.ToolTipHintDataMember = "Volume";
            series8.ValueDataMembersSerializable = "Volume";
            lineSeriesView4.AxisYName = "AxisY Price";
            lineSeriesView4.Color = System.Drawing.Color.Red;
            series8.View = lineSeriesView4;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4,
        series5,
        series6,
        series7,
        series8};
            this.chartControl1.SeriesTemplate.ArgumentDataMember = "Date";
            this.chartControl1.SeriesTemplate.LegendName = "Default Legend";
            this.chartControl1.SeriesTemplate.ToolTipHintDataMember = "Price";
            this.chartControl1.SeriesTemplate.ValueDataMembersSerializable = "Price";
            lineSeriesView5.AxisYName = "AxisY Price";
            lineSeriesView5.LineMarkerOptions.Size = 8;
            lineSeriesView5.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesUnwindAnimation1.Direction = DevExpress.XtraCharts.AnimationDirection.FromBottom;
            lineSeriesView5.SeriesAnimation = xySeriesUnwindAnimation1;
            this.chartControl1.SeriesTemplate.View = lineSeriesView5;
            this.chartControl1.SeriesTemplate.Visible = false;
            this.chartControl1.Size = new System.Drawing.Size(1036, 477);
            this.chartControl1.TabIndex = 0;
            // 
            // XtraGraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Name = "XtraGraphControl";
            this.Size = new System.Drawing.Size(1036, 477);
            ((System.ComponentModel.ISupportInitialize)(this.usdtCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stochRsiK_Collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StochRSI_DCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btcCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiTrandCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stepLineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stepLineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.Xpo.XPCollection usdtCollection;
        //private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.Xpo.XPCollection btcCollection;
        private DevExpress.Xpo.XPCollection stochRsiK_Collection;
        private DevExpress.Xpo.XPCollection StochRSI_DCollection;
        private DevExpress.Xpo.XPCollection rsiCollection;
        private DevExpress.Xpo.XPCollection rsiTrandCollection;
    }
}
