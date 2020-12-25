using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using Configuration.Exceptions;
using Configuration.Helpers;
using Configuration.Models;
using Configuration.Properties;

namespace Configuration.Controls.Editors
{
    public partial class TypeConfigControl : ElementBaseControl
    {
        public EventHandler DeleteEventHandler;

        string columnText = "Name";
        string columnComments = "Comment";
        const string filterattribs = "filterAttribs";

        public TypeConfigControl()
        {
            InitializeComponent();
        }

        public XElement TypeConfigElement
        {
            get; private set;
        }

        public void SetTypeConfig(XElement xElement)
        {
            SuspendLayout();
            AddToolTipText(_bDelete, "Удаление ветки TypeConfig целиком");

            TypeConfigElement = xElement;
            AddToolTipText(xElement, _lTypeConfig);
            var softtypeEl = xElement.Element("softtype");
            if (softtypeEl != null)
            {
                AddToolTipText(softtypeEl, _tbFilterName);
                _tbFilterName.DataBindings.Add("Text", softtypeEl, "Value");
                _tbFilterName.Validated += _textBoxElement_Validated;
            }


            _tbFilterComments.Visible = false;
            _tbFilterComments.Enabled = false;


            CreateDataTable(xElement);

            _filterAttribsOther.SetFilterAttribs(xElement);
            _filterAttribsOther.SetAutosizeByHeader();
            //            _tbFilterAttribsInObdOther.Text = GetFilterAttribsInObdOther();
            var assistant = Assistant.GetInstance();
            assistant.BeforeHasDifferents += BeforeHasDifferents;
            _bDelete.Click += _bDelete_Click;

            ResumeLayout(false);
            PerformLayout();
        }

        private void CreateDataTable(XElement xElement)
        {
            
            var tdFilterAttribs = new DataTable(filterattribs);
            tdFilterAttribs.Columns.Add(columnText);
            tdFilterAttribs.Columns.Add(columnComments);

            var attribs = xElement.Element(filterattribs)?.Elements("Attribute");
            if(attribs !=null)
            {
                foreach (var attrib in attribs)
                {
                    var comment = GetCommentText(attrib).Replace(Environment.NewLine, "");
                    tdFilterAttribs.Rows.Add(attrib.Element(columnText)?.Value, comment);
                }
            }

            _gridFaControl.SetDataTable(tdFilterAttribs, null, columnText, columnComments);

            _gridFaControl.SetLabelTexts(filterattribs);
        }

        protected override void BeforeHasDifferents(object sender, EventArgs eventArgs)
        {
            /*if (_tbFilterName.Text.Length != _tbFilterName.Text.Trim().Length)
            {
                var xElement = TypeConfigElement.Element("softtype");
                if(xElement != null)
                    xElement.Value = _tbFilterName.Text.Trim();
            }*/

            // Читаем из DataTable
            if (_gridFaControl.DataTable !=null)
            {
                var xElement = TypeConfigElement.Element(filterattribs);
                if (xElement != null)
                {
                    xElement.RemoveAll();
                }
                else
                {
                    xElement = TypeConfigElement.AddSubElement(filterattribs, null, "");
                }
                // формируем заново всю таблицу
                foreach (DataRow row in _gridFaControl.DataTable.Rows)
                {
                    var text = row[columnText].ToString();
                    var comments = row[columnComments].ToString();
                    xElement.AddSubElement("Attribute", new XElement(columnText, text.Trim()), comments);
                }
            }
        }

        

        private void _bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите дуалить строку '{TypeConfigElement.Element("softtype")?.Value}'?", "Удаление строки",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TypeConfigElement.Remove();
                DeleteEventHandler?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
