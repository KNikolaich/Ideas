using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    public partial class BoolEditControl : ElementBaseControl
    {
        public BoolEditControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Если снаружи интересно что галочка была поставлена или снята - можно подписаться
        /// </summary>
        public EventHandler CheckedChanged;

        private CheckBox checkBox;
        private XElement _xElement;

        public bool CheckedState
        {
            get { return checkBox!= null ? checkBox.Checked : false; }
            set
            {
                UnbindElement();
                _xElement.Value = value.ToString();
                checkBox.Checked = value;
                BindElement();
            }
        }

        protected override void AddEditControl(XElement xElement)
        {
            checkBox = new CheckBox
            {
                Location = new Point(32, 4),
                Font = new Font(Assistant.FontName, Assistant.FontSize, FontStyle.Regular, GraphicsUnit.Point,
                    204),
                Name = "checkBox1",
                Size = new Size(121, 21),
                TabIndex = 1,
                Dock = DockStyle.Fill
            };
            //InitComboBox(checkBox, xElement.Value);

            Controls.Add(checkBox);
            _xElement = xElement;
            BindElement();
        }

        private void UnbindElement()
        {
            checkBox.DataBindings.Clear();
            checkBox.CheckedChanged -= CheckBox_CheckedChanged;
        }

        private void BindElement()
        {
            checkBox.DataBindings.Add("Checked", _xElement, "Value");
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
        }

        private void CheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckedChanged != null)
            {
                CheckedChanged(sender, e); 
            }
        }
    }
}