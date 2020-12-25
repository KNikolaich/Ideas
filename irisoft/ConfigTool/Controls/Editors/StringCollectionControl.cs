using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Configuration.Exceptions;
using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    public partial class StringCollectionControl : ElementBaseControl
    {
        string columnText = "string";
        string columnComments = "comment";
        private Assistant _assistant;
        private XElement _xElement;
        private XElement _parrentXElement;
        private XElement _otherFA;


        public StringCollectionControl()
        {
            InitializeComponent();
        }

        public override void SetElement(XElement xElement, int locationEditorX = 140)
        {
            _gridControl.VisibleTop = false;
//            columnStringValue.DataPropertyName = columnText;
//            columnComment.DataPropertyName = columnComments;
            _xElement = xElement;
            DataTable dt = new DataTable(xElement.Name.LocalName);

            dt.Columns.Add(columnText);
            dt.Columns.Add(columnComments);
            foreach (var subEl in xElement.Elements("string"))
            {
                var row = dt.NewRow();
                row[columnText] = subEl.Value;
                if (subEl.PreviousNode?.NodeType == XmlNodeType.Comment)
                    row[columnComments] = ((XComment)subEl.PreviousNode).Value;
                dt.Rows.Add(row);
            }

            _gridControl.SetDataTable(dt, null, columnText, columnComments);
            _gridControl.SetAutosizeColumn(columnText, DataGridViewAutoSizeColumnMode.ColumnHeader);
            _textBoxTop.Text = xElement.Name.LocalName;

            _assistant = Assistant.GetInstance();
            _assistant.BeforeHasDifferents += BeforeHasDifferents;
            _textBoxComment.Width = 400;
            _textBoxComment.Text = AddToolTipText(xElement, _textBoxComment);

            _textBoxComment.Padding = new Padding(0, 3, 0, 0);
            _gridControl.Padding = new Padding(0, 3, 0, 0);
            Padding = new Padding(5,5,5,0);
        }

        protected override void AddEditControl(XElement xElement)
        {
        }

        protected override void BeforeHasDifferents(object sender, EventArgs e)
        {
//            var stringElements = _xElement.Elements("string");
            var dataTable = _gridControl.DataTable;

            _gridControl.ValidateDataTable(_xElement.Name.LocalName, columnText);

            _xElement.RemoveAll();
            // формируем заново всю таблицу
            foreach (DataRow row in dataTable.Rows)
            {
                var text = row[columnText].ToString();
                var comments = row[columnComments].ToString();
                _xElement.AddSubElement("string", text.Trim(), comments);
            }

            if (_parrentXElement != null)
            {
               
                if (dataTable.Rows.Count == 0)
                {
                    var otherXElement = _parrentXElement.Element("filterAttribsInObdOther");
                    otherXElement?.Remove();
                }
                else
                {
                    if (_parrentXElement.Element("filterAttribsInObdOther") != _otherFA)
                    {
                        _parrentXElement.Add(_otherFA);
                    }
                }
            }
        }



        public void SetFilterAttribs(XElement parrentXElement)
        {
            _parrentXElement = parrentXElement;
            _otherFA = parrentXElement.Element("filterAttribsInObdOther");

            if (_otherFA == null)
            {
                _otherFA = CreateFakeFA();
            }
            SetElement(_otherFA);

            var commentForFa = @"Перечень имен атрибутов внутри составного атрибута Windchill 'Прочее', заданый в настройке /Config/attrObdOther;
содержит значения только для различных типов частей, всегда пуст для документов и связей part usage.";
           AddToolTipText(_textBoxTop, commentForFa);
            _textBoxComment.Width = 0;
            _textBoxComment.Text = "";
        }

        public void SetAutosizeByHeader()
        {
            _gridControl.SetAutosizeColumn(columnText, DataGridViewAutoSizeColumnMode.ColumnHeader);
        }

        /// <summary>
        /// Делаем фейковый аналог, на случай, если надо будет заполнять
        /// </summary>
        /// <returns></returns>
        private XElement CreateFakeFA()
        {
            return new XElement("filterAttribsInObdOther");
        }
    }
}
