namespace WindowsFormApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sbClear = new DevExpress.XtraEditors.SimpleButton();
            this.sbBern = new DevExpress.XtraEditors.SimpleButton();
            this.sbHide = new DevExpress.XtraEditors.SimpleButton();
            this.sbExit = new DevExpress.XtraEditors.SimpleButton();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPageConfig = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.configXtraUserControl1 = new WindowsFormApp.Controls.ConfigXtraUserControl();
            this.tabNavigationPageView = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.viewBalanceUserControl1 = new WindowsFormApp.Controls.ViewBalanceUserControl();
            this.tabNavigationPageLogs = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.testDataUserControl1 = new WindowsFormApp.Controls.TestDataUserControl();
            this.tabNavigationPageManual = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.manualExcangeControl1 = new WindowsFormApp.Controls.ManualExcangeControl();
            this._xtraGraphControl1 = new WindowsFormApp.Controls.XtraGraphControl();
            this.tabNavigationPageGraph = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPageAbout = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._aboutPanel = new Controls.AboutControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPageConfig.SuspendLayout();
            this.tabNavigationPageView.SuspendLayout();
            this.tabNavigationPageLogs.SuspendLayout();
            this.tabNavigationPageManual.SuspendLayout();
            this.tabNavigationPageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sbClear);
            this.panelControl1.Controls.Add(this.sbBern);
            this.panelControl1.Controls.Add(this.sbHide);
            this.panelControl1.Controls.Add(this.sbExit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 527);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(720, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // sbClear
            // 
            this.sbClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbClear.ImageUri.Uri = "Clear;Size16x16";
            this.sbClear.Location = new System.Drawing.Point(5, 6);
            this.sbClear.Name = "sbClear";
            this.sbClear.Size = new System.Drawing.Size(75, 23);
            this.sbClear.TabIndex = 0;
            this.sbClear.Text = "Чистим";
            this.sbClear.Click += SbClear_Click;
            // 
            // sbBern
            // 
            this.sbBern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbBern.ImageUri.Uri = "Refresh;Size16x16";
            this.sbBern.Location = new System.Drawing.Point(476, 5);
            this.sbBern.Name = "sbBern";
            this.sbBern.Size = new System.Drawing.Size(75, 23);
            this.sbBern.TabIndex = 0;
            this.sbBern.Text = "Жги";
            this.sbBern.Click += new System.EventHandler(this.sbBern_Click);
            // 
            // sbHide
            // 
            this.sbHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbHide.ImageUri.Uri = "FontSizeDecrease;Size16x16";
            this.sbHide.Location = new System.Drawing.Point(557, 5);
            this.sbHide.Name = "sbHide";
            this.sbHide.Size = new System.Drawing.Size(75, 23);
            this.sbHide.TabIndex = 0;
            this.sbHide.Text = "Скрыть";
            this.sbHide.Click += new System.EventHandler(this.sbHide_Click);
            // 
            // sbExit
            // 
            this.sbExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbExit.ImageUri.Uri = "Cancel;Size16x16";
            this.sbExit.Location = new System.Drawing.Point(640, 5);
            this.sbExit.Name = "sbExit";
            this.sbExit.Size = new System.Drawing.Size(75, 23);
            this.sbExit.TabIndex = 0;
            this.sbExit.Text = "Выход";
            this.sbExit.Click += new System.EventHandler(this.sbExit_Click);
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPageConfig);
            this.tabPane1.Controls.Add(this.tabNavigationPageView);
            this.tabPane1.Controls.Add(this.tabNavigationPageLogs);
            this.tabPane1.Controls.Add(this.tabNavigationPageManual);
            this.tabPane1.Controls.Add(this.tabNavigationPageGraph);
            this.tabPane1.Controls.Add(this.tabNavigationPageAbout);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPageLogs,
            this.tabNavigationPageGraph,
            this.tabNavigationPageView,
            this.tabNavigationPageManual,
            this.tabNavigationPageConfig,
            this.tabNavigationPageAbout});
            this.tabPane1.RegularSize = new System.Drawing.Size(720, 527);
            this.tabPane1.SelectedPage = this.tabNavigationPageView;
            this.tabPane1.Size = new System.Drawing.Size(720, 527);
            this.tabPane1.TabIndex = 1;
            this.tabPane1.Text = "tabPane1";
            // 
            // tabNavigationPageConfig
            // 
            this.tabNavigationPageConfig.Caption = "Настройки";
            this.tabNavigationPageConfig.Controls.Add(this.configXtraUserControl1);
            this.tabNavigationPageConfig.ImageUri.Uri = "CustomizeGrid;Size16x16";
            this.tabNavigationPageConfig.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageConfig.Name = "tabNavigationPageConfig";
            this.tabNavigationPageConfig.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageConfig.Size = new System.Drawing.Size(702, 479);
            // 
            // configXtraUserControl1
            // 
            this.configXtraUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configXtraUserControl1.Location = new System.Drawing.Point(0, 0);
            this.configXtraUserControl1.Name = "configXtraUserControl1";
            this.configXtraUserControl1.Size = new System.Drawing.Size(702, 479);
            this.configXtraUserControl1.TabIndex = 0;
            // 
            // tabNavigationPageView
            // 
            this.tabNavigationPageView.Caption = "Просмотр";
            this.tabNavigationPageView.Controls.Add(this.viewBalanceUserControl1);
            this.tabNavigationPageView.ImageUri.Uri = "Currency;Size16x16";
            this.tabNavigationPageView.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageView.Name = "tabNavigationPageView";
            this.tabNavigationPageView.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageView.Size = new System.Drawing.Size(702, 479);
            // 
            // viewBalanceUserControl1
            // 
            this.viewBalanceUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewBalanceUserControl1.Location = new System.Drawing.Point(0, 0);
            this.viewBalanceUserControl1.Name = "viewBalanceUserControl1";
            this.viewBalanceUserControl1.Size = new System.Drawing.Size(702, 479);
            this.viewBalanceUserControl1.TabIndex = 0;
            // 
            // tabNavigationPageLogs
            // 
            this.tabNavigationPageLogs.Caption = "Логи";
            this.tabNavigationPageLogs.Controls.Add(this.testDataUserControl1);
            this.tabNavigationPageLogs.ImageUri.Uri = "AlignLeft;Size16x16";
            this.tabNavigationPageLogs.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageLogs.Name = "tabNavigationPageLogs";
            this.tabNavigationPageLogs.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageLogs.Size = new System.Drawing.Size(702, 479);
            // 
            // testDataUserControl1
            // 
            this.testDataUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testDataUserControl1.Location = new System.Drawing.Point(0, 0);
            this.testDataUserControl1.Name = "testDataUserControl1";
            this.testDataUserControl1.Size = new System.Drawing.Size(702, 479);
            this.testDataUserControl1.TabIndex = 0;
            // 
            // tabNavigationPageManual
            // 
            this.tabNavigationPageManual.Caption = "Ручная обработка";
            this.tabNavigationPageManual.Controls.Add(this.manualExcangeControl1);
            this.tabNavigationPageManual.ImageUri.Uri = "Replace;Size16x16";
            this.tabNavigationPageManual.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageManual.Name = "tabNavigationPageManual";
            this.tabNavigationPageManual.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageManual.Size = new System.Drawing.Size(702, 479);
            // 
            // manualExcangeControl1
            // 
            this.manualExcangeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manualExcangeControl1.Location = new System.Drawing.Point(0, 0);
            this.manualExcangeControl1.Name = "manualExcangeControl1";
            this.manualExcangeControl1.Size = new System.Drawing.Size(702, 479);
            this.manualExcangeControl1.TabIndex = 0;
            // 
            // tabNavigationPageGraph
            // 
            this.tabNavigationPageGraph.Caption = "График (баланс)";
            this.tabNavigationPageGraph.Controls.Add(this._xtraGraphControl1);
            this.tabNavigationPageGraph.ImageUri.Uri = "Chart;Size16x16";
            this.tabNavigationPageGraph.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageGraph.Name = "tabNavigationPageGraph";
            this.tabNavigationPageGraph.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageGraph.Size = new System.Drawing.Size(720, 527);
            // 
            // _xtraGraphControl1
            // 
            this._xtraGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._xtraGraphControl1.Location = new System.Drawing.Point(0, 0);
            this._xtraGraphControl1.Name = "_xtraGraphControl1";
            this._xtraGraphControl1.Size = new System.Drawing.Size(513, 379);
            this._xtraGraphControl1.TabIndex = 0;            
            // 
            // tabNavigationPageAbout
            // 
            this.tabNavigationPageAbout.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tabNavigationPageAbout.Appearance.Options.UseBackColor = true;
            this.tabNavigationPageAbout.Caption = "О приложении";
            this.tabNavigationPageAbout.Controls.Add(this._aboutPanel);
            this.tabNavigationPageAbout.ImageUri.Uri = "Paste;Size16x16";
            this.tabNavigationPageAbout.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageAbout.Name = "tabNavigationPageAbout";
            this.tabNavigationPageAbout.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageAbout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabNavigationPageAbout.Size = new System.Drawing.Size(702, 479);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Это информационный пост";
            this.notifyIcon.BalloonTipTitle = "Вошли в систему";
            this.notifyIcon.ContextMenuStrip = this._contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Инициализировано";
            this.notifyIcon.Visible = true;
            // 
            // _contextMenu
            // 
            this._contextMenu.Name = "_contextMenu";
            this._contextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // _aboutPanel
            // 
            this._aboutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._aboutPanel.Location = new System.Drawing.Point(0, 0);
            this._aboutPanel.Name = "_aboutPanel";
            this._aboutPanel.Size = new System.Drawing.Size(702, 479);
            this._aboutPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 560);
            this.Controls.Add(this.tabPane1);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BroBotForm";
            this.Text = "Bro bot";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPageConfig.ResumeLayout(false);
            this.tabNavigationPageView.ResumeLayout(false);
            this.tabNavigationPageLogs.ResumeLayout(false);
            this.tabNavigationPageManual.ResumeLayout(false);
            this.tabNavigationPageAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sbBern;
        private DevExpress.XtraEditors.SimpleButton sbHide;
        private DevExpress.XtraEditors.SimpleButton sbExit;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageConfig;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageView;
        private Controls.ViewBalanceUserControl viewBalanceUserControl1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageLogs;
        private Controls.TestDataUserControl testDataUserControl1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageGraph;
        private DevExpress.XtraEditors.SimpleButton sbClear;
        private Controls.ConfigXtraUserControl configXtraUserControl1;
        private Controls.XtraGraphControl _xtraGraphControl1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip _contextMenu;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageManual;
        private Controls.ManualExcangeControl manualExcangeControl1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageAbout;
        private Controls.AboutControl _aboutPanel;
    }
}