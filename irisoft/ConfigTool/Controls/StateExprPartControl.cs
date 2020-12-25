using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Controls.Editors;
using Configuration.Controls.Editors.Selection_Wrappers;
using Configuration.Helpers;

namespace Configuration.Controls
{
    public partial class StateExprPartControl : ElementBaseControl
    {
        protected override void AddEditControl(XElement xElement)
        {
            var _comboBox1 = new CheckBoxComboBox();
            InitComboBox(_comboBox1, xElement.Value);
            _comboBox1.Location = new Point(32, 4);
            _comboBox1.Font = new Font(Assistant.FontName, Assistant.FontSize, FontStyle.Regular, GraphicsUnit.Point,
                204);
            _comboBox1.Name = "_comboBox1";
            _comboBox1.Size = new Size(121, 21);
            _comboBox1.TabIndex = 1;
            _comboBox1.Dock = DockStyle.Fill;
            Padding = new Padding(0, 3, 5, 0);
            Controls.Add(_comboBox1);

            _comboBox1.DataBindings.Add("Text", xElement, "Value");
        }

        private void InitComboBox(CheckBoxComboBox cmbIListDataSource, string value)
        {
            Type type = typeof(StateExpPartEnum);
            List<CheckComboBoxItem> list = new List<CheckComboBoxItem>();
            var values = value.Trim(',');
            foreach (Enum enumValue in type.GetEnumValues())
            {
                bool chacked = false;
                var name = enumValue.ToString();
                if (values.Contains(name))
                {
                    chacked = true;
                    values.Remove(values.IndexOf(name));
                }
                list.Add(new CheckComboBoxItem(chacked, name, enumValue.GetDescription()));
            }


            var StatusSelections = new ListSelectionWrapper<CheckComboBoxItem>(list, "Name");

            cmbIListDataSource.DataSource = StatusSelections;
            cmbIListDataSource.DisplayMemberSingleItem = "Name";
            cmbIListDataSource.DisplayMember = "NameConcatenated";
            cmbIListDataSource.ValueMember = "Selected";
            cmbIListDataSource.ItemHeight = 18;
            cmbIListDataSource.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (ObjectSelectionWrapper<CheckComboBoxItem> objectSelectionWrapper in StatusSelections)
            {
                if (objectSelectionWrapper.Item.Selected)
                {
                    objectSelectionWrapper.Selected = true;
                }
            }

            //cmbIListDataSource.CheckBoxItems[3].DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            cmbIListDataSource.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }
    }
}