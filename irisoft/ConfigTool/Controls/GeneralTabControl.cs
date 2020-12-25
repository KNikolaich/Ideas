using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Exceptions;
using Configuration.Helpers;

namespace Configuration.Controls
{
    public partial class GeneralTabControl : ElementBaseControl
    {
        private Dictionary<string, XElement> _abonentDict = new Dictionary<string, XElement>();

        public GeneralTabControl()
        {
            InitializeComponent();
        }

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            SuspendLayout();

            var maxSizeHeight = 100;
            foreach (var subXElement in xElement.Elements())
            {
                var commentForAbonent = subXElement.FirstNode.ToString();
                _abonentDict.Add(commentForAbonent, subXElement);
                var abonentId = subXElement.Element("id");
                if (abonentId != null)
                    abonentId.Changed += AbonentId_Changed;
                var sizeHeight = AddTabPage(subXElement);
                maxSizeHeight = sizeHeight > maxSizeHeight ? sizeHeight : maxSizeHeight;
            }

            Assistant.GetInstance().BeforeHasDifferents += BeforeHasDifferents;  
            ResumeLayout(false);
        }

        private void AbonentId_Changed(object sender, XObjectChangeEventArgs e)
        {
            ValidateAbonentsId(true);
        }

        protected override void BeforeHasDifferents(object sender, EventArgs eventArgs)
        {
            ValidateAbonentsId();
        }

        private void ValidateAbonentsId(bool onlyWarning = false)
        {
            UnuniqueValueException.Validate(_abonentDict.Values.Select(xel => xel.Element("id")?.Value), "Abonents/Abonent/id", onlyWarning);
        }

        private int AddTabPage(XElement subXElement)
        {
            string tabPageText = subXElement.Name.ToString();

            var abonentControl = new AbonentControl {Name = tabPageText + "control"};
            abonentControl.SetElement(subXElement); 

            var tabPage = AddTabControl(abonentControl, tabPageText);

            tabPage.ToolTipText = AddToolTipText(subXElement, tabPage);
            var textAbonenta = tabPage.ToolTipText
                .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(ttt => ttt.Contains("Настройки абонента"));
            if (!string.IsNullOrEmpty(textAbonenta))
            {
                tabPage.Text = textAbonenta.Replace("Настройки абонента", "").Trim(' ', '.');
            }

            //base.SetElement(xElement, locationEditorX);
            return abonentControl.Size.Height;
        }

        private TabPage AddTabControl(UserControl baseControl, string tabPageText)
        {
            var _tabPage = new TabPage();
            baseControl.Dock = DockStyle.Fill;
            //Controls.Add(baseControl);
            _tabPage.SuspendLayout();
            _tabPage.Controls.Add(baseControl);
            _tabPage.Font = new Font(Assistant.FontName, Assistant.FontSize, FontStyle.Regular, GraphicsUnit.Point,
                204);
            _tabPage.Location = new Point(4, 22);
            _tabPage.Name = "_tabPage" + tabPageText;
            _tabPage.Padding = new Padding(3);
            _tabPage.Size = baseControl.Size;
            _tabPage.TabIndex = _tabAbonsControl.Controls.Count +1;

            _tabPage.Text = tabPageText;
            _tabPage.UseVisualStyleBackColor = true;
            _tabPage.ResumeLayout(false);
            _tabAbonsControl.Controls.Add(_tabPage);
            return _tabPage;
        }

        public void InsertCommonFieldsTab(UserControl commonFieldsControl)
        {
            _tabAbonsControl.SuspendLayout();
            var commonFieldsTab = AddTabControl(commonFieldsControl, "Общие поля");
            commonFieldsTab.TabIndex = 0;
            _tabAbonsControl.ResumeLayout();
        }
    }
}