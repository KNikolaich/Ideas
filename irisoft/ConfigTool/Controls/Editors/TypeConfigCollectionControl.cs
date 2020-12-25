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
    public partial class TypeConfigCollectionControl : ElementBaseControl
    {
        private readonly List<XElement> _typeConfigsList = new List<XElement>();

        public TypeConfigCollectionControl()
        {
            InitializeComponent();
        }

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            _currentElement = xElement;
            var comment = AddToolTipText(xElement, _labelComment);
            _labelComment.Text = comment;
            var subXElements = xElement.Elements();

            AddControllsByElements(subXElements);
            AddToolTipText(_bAdd, "Добавить новую ветки TypeConfig");
            Assistant.GetInstance().BeforeHasDifferents += BeforeHasDifferents;

        }

        protected override void BeforeHasDifferents(object sender, EventArgs eventArgs)
        {
            ValidateSofttype();
        }

        private void ValidateSofttype(bool onlyWrning = false)
        {
            UnuniqueValueException.Validate(_typeConfigsList.Select(tc => tc.Element("softtype")?.Value), "TypeConfigs/TypeConfig/softtype", onlyWrning);
        }

        internal void AddControllsByElements(IEnumerable<XElement> subXElements)
        {
            SuspendLayout();
            foreach (var subXElement in subXElements)
            {
                _typeConfigsList.Add(subXElement);
                AddSubControl(subXElement, false);
            }

            //Size = new Size(Size.Width, Size.Height + 22);
            ResumeLayout(false);
            PerformLayout();
            RefreshControlSize();
            Size = new Size(Size.Width, Size.Height-20);
        }

        public TypeConfigControl AddSubControl(XElement subXElement, bool needResize = true)
        {
            var typeConfigControl = new TypeConfigControl
            {
                Dock = DockStyle.Bottom,
                Location = new Point(0, 40),
                Name = "_typeConfigControl" + Controls.Count,
                Size = new Size(748, 104),
                TabIndex = 1
            };
            
            var softType = subXElement.Element("softtype");
            if (softType != null)
                softType.Changed += softTypeOnChanged;
            typeConfigControl.SetTypeConfig(subXElement);
            typeConfigControl.DeleteEventHandler += TypeConfigControlDelete;
            _groupBox.Controls.Add(typeConfigControl);
            if(needResize)
                RefreshControlSize();
            return typeConfigControl;
        }


        private void softTypeOnChanged(object sender, XObjectChangeEventArgs e)
        {
            ValidateSofttype(true);
        }

        private void RefreshControlSize()
        {
            var subElementH = 76;
            foreach (Control control in _groupBox.Controls)
            {
                if(control is TypeConfigControl)
                    subElementH += control.Height;
            }
            Size = new Size(Size.Width, subElementH);
        }

        private void TypeConfigControlDelete(object sender, EventArgs e)
        {
            var typeConfigControl = sender as TypeConfigControl;
            if (typeConfigControl != null)
            {
                var softType = typeConfigControl.TypeConfigElement.Element("softtype");
                if (softType != null)
                    softType.Changed -= softTypeOnChanged;

                typeConfigControl.DeleteEventHandler -= TypeConfigControlDelete;
                SuspendLayout();
                _groupBox.SuspendLayout();
                _groupBox.Controls.Remove(typeConfigControl);
                _groupBox.ResumeLayout(false);
                RefreshControlSize();
                ResumeLayout(false);
                PerformLayout();
                typeConfigControl.Dispose();

            }
        }

        private void _bAdd_Click(object sender, EventArgs e)
        {
            var newxTypeConfig = _currentElement.AddSubElement("TypeConfig", new XElement("softtype"), "");
            AddSubControl(newxTypeConfig);
            MessageBox.Show("Новый 'TypeConfig' добавлен в конец списка.", "Добавление TypeConfig",
                MessageBoxButtons.OK);
        }
    }
}
