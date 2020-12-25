using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Exceptions;
using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    public partial class ContainerConfigsGroupControl : ElementBaseControl
    {
        private readonly List<XElement> _elements = new List<XElement>();

        public ContainerConfigsGroupControl()
        {
            InitializeComponent();
        }

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            _currentElement = xElement;
            var subXElements = xElement.Elements();
            SuspendLayout();

            foreach (var subXElement in subXElements)
            {
                AddSubElement(subXElement, false);
            }

            AddEditControl(xElement);
            ResumeLayout(false);
            PerformLayout();
            RefreshControlSize();

            Size = new Size(Size.Width, Size.Height + 8);
            Assistant.GetInstance().BeforeHasDifferents +=BeforeHasDifferents;  
        }

        protected override void BeforeHasDifferents(object sender, EventArgs eventArgs)
        {
            ContainerNameChanged(false);
        }

        private void AddSubElement(XElement subXElement, bool needResize = true)
        {
            var subElemControl = ControlCreator.GetSubElemControl(subXElement, Controls.Count.ToString()) as ContainerConfigControl;
            if (subElemControl != null)
            {
                subElemControl.Dock = DockStyle.Bottom;

                subElemControl.DeleteEventHandler += ContainerConfigControlDelete;

                _groupBox.Controls.Add(subElemControl);
                subElemControl.Height = needResize ? 165 : 125;
                var containerName = subXElement.Element("containerName");
                if (containerName != null)
                    containerName.Changed += ContainerNameOnChanged;
                _elements.Add(subXElement);
            }
            if (needResize)
            {
                RefreshControlSize();
            }
        }

        private void ContainerNameChanged(bool onlyWarning)
        {
            UnuniqueValueException.Validate(
                _elements.Select(ccEl => ccEl.Element("containerName")?.Value),
                "ContainerConfigs/ContainerConfig/containerName", onlyWarning);
        }

        private void RefreshControlSize(int subElementH =0)
        {
            foreach (Control control in _groupBox.Controls)
            {
                if(control is ContainerConfigControl)
                    subElementH += control.Height;
            }
            Size = new Size(Size.Width, 34 + subElementH);
        }

        protected override void AddEditControl(XElement xElement)
        {
            _groupBox.Text = "";
            var comments = AddToolTipText(xElement, labelCc);
            AddToolTipText(_bAdd, "Добавить новую ветку ContainerConfig");
            _tbComment.Text = comments;
        }

        private void _bAdd_Click(object sender, EventArgs e)
        {

            var xContainerConfig = _currentElement.AddSubElement("ContainerConfig", new XElement("containerName"), null);
            var xSpecProgTypeConfig = new XElement("SpecProgTypeConfig", 
                new XElement("specProgramType", -1), 
                new XElement("sendTMforNewSpec", false), 
                new XElement("sendTMforChangedSpec", false));
            var xSpecProgTypeConfigs = new XElement("specProgTypeConfigs", xSpecProgTypeConfig);
            xContainerConfig.Add(xSpecProgTypeConfigs);
            AddSubElement(xContainerConfig);
        }

        private void ContainerConfigControlDelete(object sender, EventArgs e)
        {
            var containerConfigControl = sender as ContainerConfigControl;
            if (containerConfigControl != null)
            {
                _elements.Remove(containerConfigControl.CurrentConteiner);

                var containerName = containerConfigControl.CurrentConteiner.Element("containerName");
                if (containerName != null)
                    containerName.Changed -= ContainerNameOnChanged;
                containerConfigControl.DeleteEventHandler -= ContainerConfigControlDelete;
                SuspendLayout();
                _groupBox.SuspendLayout();
                _groupBox.Controls.Remove(containerConfigControl);
                _groupBox.ResumeLayout(false);
                RefreshControlSize();
                ResumeLayout(false);
                PerformLayout();
                containerConfigControl.Dispose();
            }
        }

        private void ContainerNameOnChanged(object o, XObjectChangeEventArgs xObjectChangeEventArgs)
        {
            ContainerNameChanged(true);
        }
    }
}
