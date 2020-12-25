using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    public partial class SmChecksumAlgControl : ElementBaseControl
    {
        public SmChecksumAlgControl()
        {
            InitializeComponent();
        }

        protected override void AddEditControl(XElement xElement)
        {
            SuspendLayout();

            var comboBoxEditor = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(32, 4),
                Font = new Font(Helpers.Assistant.FontName, Helpers.Assistant.FontSize, FontStyle.Regular, GraphicsUnit.Point,
                    204),
                Dock = DockStyle.Fill,
                Name = "comboBoxEditor",
                Size = new Size(121, 21),
                TabIndex = 0,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            _textBoxElement = comboBoxEditor;
            comboBoxEditor.Items.AddRange(new object[] {
                "CRC32",
                "MD5"});
            ResumeLayout(false);
            Padding = new Padding(0, 3, 5, 0);

            Controls.Add(comboBoxEditor);
            comboBoxEditor.DataBindings.Add("Text", xElement, "Value");
            comboBoxEditor.SelectedIndex = 0;
            AddChackBoxOptional();

            var cbOptionalChecked = !string.IsNullOrEmpty(xElement.Value);
            if(_cbOptional != null)
                _cbOptional.Checked = cbOptionalChecked;

            Assistant.GetInstance().BeforeHasDifferents += BeforeHasDifferents;
        }

        protected override void BeforeHasDifferents(object sender, EventArgs eventArgs)
        {
            base.BeforeHasDifferents(sender, eventArgs);
            if (_textBoxElement != null && _cbOptional != null && _cbOptional.Checked)
            {
                var xElement = _parent.Element("checksumAlg");
                if (string.IsNullOrEmpty(xElement.Value))
                {
                    xElement.Value = _textBoxElement.Text;
                }
            }
        }
    }
}
