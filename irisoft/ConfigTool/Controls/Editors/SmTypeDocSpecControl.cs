using System;
using System.Collections.Generic;
using System.Data;using System.Linq;
using System.Text;
using System.Xml.Linq;
using Configuration.Exceptions;
using Configuration.Helpers;
using Configuration.Models;

namespace Configuration.Controls.Editors
{
    internal class SmTypeDocSpecControl : GridWithLabelControl
    {
        private string _queueCol = "int";
        private string _textCol = "string";
        private string _comment1Col = "comment";

        private XElement _xElement;
        private string _comment2Col = "CommentForQueue";
        private string _comment3Col = "CommentForValue";

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            DataTable dt = new DataTable(xElement.Name.LocalName);
            dt.Columns.Add(_queueCol, typeof(int));
            dt.Columns.Add(_textCol);
            dt.Columns.Add(_comment1Col);
            dt.Columns.Add(_comment2Col);
            dt.Columns.Add(_comment3Col);
            foreach (var element in xElement.Elements("entry"))
            {
                var row = dt.NewRow();
                row[_comment1Col] = GetCommentText(element).Replace(Environment.NewLine, "");
                var xElementInt = element.Element("int");
                row[_queueCol] = Convert.ToInt32(xElementInt?.Value);
                var xElementString = element.Element("string");
                row[_textCol] = xElementString?.Value;
                row[_comment2Col] = GetCommentText(xElementInt).Replace(Environment.NewLine, "");
                row[_comment3Col] = GetCommentText(xElementString).Replace(Environment.NewLine, "");
                dt.Rows.Add(row);
            }

            //_columnText.W
            SetDataTable(dt, _queueCol, _textCol, _comment1Col);
            base.SetElement(xElement, locationEditorX);
            _xElement = xElement;

            _dataGridView.Columns[_comment2Col].Visible = false;
            _dataGridView.Columns[_comment3Col].Visible = false;

            this.Padding = new System.Windows.Forms.Padding(0, 5, 5,5);
        }

        protected override void BeforeHasDifferents(object sender, EventArgs e)
        {
            var dataTable = _dataGridView.DataSource as DataTable;
            var entryList = new List<Entry>();
            // Проверяем состав и комментарии
            foreach (DataRow row in dataTable.Rows)
            {
                Entry entry = new Entry();
                entry.StrValue = row[_textCol].ToString();
                object vQueue = row[_queueCol];
                entry.Queue = vQueue == DBNull.Value ? -1 : Convert.ToInt32(vQueue);
                entry.Comment = row[_comment1Col].ToString().Replace(Environment.NewLine, "");
                entry.CommentForQueue = row[_comment2Col].ToString();
                entry.CommentForValue = row[_comment3Col].ToString();
                entryList.Add(entry);
            }
            entryList.Sort();

            var strMsgException = new StringBuilder();
            foreach (var entry in entryList)
            {
                var strEx = entry.InvalidMessage();
                if(!string.IsNullOrEmpty(strEx))
                    strMsgException.AppendLine(strEx);
            }

            if (strMsgException.Length != 0)
            {
                strMsgException.Insert(0, "Необходимо поправить данные в теге <SmTypeDocSpec>" + Environment.NewLine);
                throw new UndeclaredValueException(strMsgException.ToString());
            }

            ValidateDataTable(_xElement.Name.LocalName, _queueCol);
            
            _xElement.RemoveAll();
            foreach (var entry in entryList)
            {
                var addition = _xElement.AddSubElement("entry", null, entry.Comment);
                addition.AddSubElement("int", entry.Queue, entry.CommentForQueue);
                addition.AddSubElement("string", entry.StrValue, entry.CommentForValue);
            }
        }
    }
}
