using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Exceptions;
using Configuration.Helpers;
using Configuration.Models;

namespace Configuration.Controls.Editors
{
    internal class ContainerConfigGridControl : GridWithLabelControl
    {

        private string _queueCol = "specProgramType";
        private string _sendTMforChangedSpecCol = "sendTMforChangedSpec";
        private string _sendForNewSpecCol = "sendTMforNewSpec";

        private string _comment1Col = "Comment";
        private string _comment2Col = "CommentForValue1";
        private string _comment3Col = "CommentForValue2";
        private XElement _elementspecProgTypeConfigs;

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            _currentElement = xElement;
            _labelXelement.Visible = false;
            _elementspecProgTypeConfigs = xElement.Elements("specProgTypeConfigs").First();

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[]
            {
                new DataColumn(_queueCol, typeof(int)),
                new DataColumn(_sendTMforChangedSpecCol, typeof(bool)),
                new DataColumn(_sendForNewSpecCol, typeof(bool)),
                new DataColumn(_comment1Col),
                new DataColumn(_comment2Col),
                new DataColumn(_comment3Col),
            });

            foreach (var ptConfigElement in _elementspecProgTypeConfigs.Elements("SpecProgTypeConfig"))
            {
                var row = dt.NewRow();
                var specProgType = ptConfigElement.Elements(_queueCol).FirstOrDefault();
                var changeSpec = ptConfigElement.Elements(_sendTMforChangedSpecCol).FirstOrDefault();
                var newSpec = ptConfigElement.Elements(_sendForNewSpecCol).FirstOrDefault();

                row[_queueCol] = specProgType?.Value;
                row[_comment1Col] = GetCommentText(specProgType).Replace(Environment.NewLine, "");
                row[_sendTMforChangedSpecCol] = changeSpec?.Value;
                row[_comment2Col] = GetCommentText(newSpec).Replace(Environment.NewLine, "");
                row[_sendForNewSpecCol] = newSpec?.Value;
                row[_comment3Col] = GetCommentText(changeSpec).Replace(Environment.NewLine, "");
                dt.Rows.Add(row);

            }

            SetDataTable(dt, _queueCol, null, _sendForNewSpecCol, _sendTMforChangedSpecCol);
            base.SetElement(_elementspecProgTypeConfigs, locationEditorX);

            _dataGridView.Columns[_comment2Col].Visible = false;
            _dataGridView.Columns[_comment3Col].Visible = false;

        }


        internal override void SetDataTable(DataTable dt, params string[] otherColumns)
        {
            string queueCol = otherColumns[0];
//            string valueCol = otherColumns[1];
            _columnQueue.HeaderText = queueCol;
            _columnQueue.DataPropertyName = queueCol;
            _columnText.Visible = false;
            _columnComment.Visible = false;
            _columnComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (var index = 2; index < otherColumns.Length; index++)
            {
                var otherColumn = otherColumns[index];
                var dataGridViewAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.ColumnHeader; // последняя колонка по всей ширине
                var columnOther =
                    new DataGridViewCheckBoxColumn
                    {
                        AutoSizeMode = dataGridViewAutoSizeColumnMode,
                        HeaderText = otherColumn,
                        Name = $"columnOther{index}",
                        DataPropertyName = otherColumn
                    };
                _dataGridView.Columns.Add(columnOther);
            }

            _dataGridView.DataSource = dt;
            var commectCol = _dataGridView.Columns[_comment1Col];
            if(commectCol!=null)
                commectCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            _dataGridView.RowValidating += _dataGridView_RowValidating;
        }

        protected override void BeforeHasDifferents(object sender, EventArgs e)
        {
            var dataTable = _dataGridView.DataSource as DataTable;
            var entryList = new List<SpecProgTypeConfig>();
            // Проверяем состав и комментарии
            foreach (DataRow row in dataTable.Rows)
            {
                var entry = new SpecProgTypeConfig();
                var sendTMforChangedSpec = row[_sendTMforChangedSpecCol];
                entry.SendTMforChangedSpec = sendTMforChangedSpec != DBNull.Value && Convert.ToBoolean(sendTMforChangedSpec);
                var queue = row[_queueCol];
                entry.SpecProgramType = queue == DBNull.Value ? -1 : Convert.ToInt32(queue);
                var sendForNewSpecCol = row[_sendForNewSpecCol];
                entry.SendTMforNewSpec = sendForNewSpecCol != DBNull.Value && Convert.ToBoolean(sendForNewSpecCol);

                if(row[_comment1Col] != DBNull.Value)
                    entry.SpecProgramTypeComment = row[_comment1Col].ToString();
                if (row[_comment2Col] != DBNull.Value)
                    entry.SendTMforNewSpecComment = row[_comment2Col].ToString();
                if (row[_comment3Col] != DBNull.Value)
                    entry.SendTMforChangedSpecComment = row[_comment3Col].ToString();
                entryList.Add(entry);
            }
            entryList.Sort();
            var strMsgException = new StringBuilder();
            foreach (var entry in entryList)
            {
                var strEx = entry.InvalidMessage();
                if (!string.IsNullOrEmpty(strEx))
                    strMsgException.AppendLine(strEx);
            }
            if (strMsgException.Length != 0)
            {
                strMsgException.Insert(0, "Необходимо поправить данные в теге <SpecProgTypeConfig>" + Environment.NewLine);
                throw new UndeclaredValueException(strMsgException.ToString());
            }
            ValidateDataTable(_currentElement.Name.LocalName, _columnQueue.DataPropertyName);
            _elementspecProgTypeConfigs.RemoveAll();
            foreach (var entry in entryList)
            {
                var addition = _elementspecProgTypeConfigs.AddSubElement("SpecProgTypeConfig", null, null);
                addition.AddSubElement(_queueCol, entry.SpecProgramType, entry.SpecProgramTypeComment);
                addition.AddSubElement(_sendForNewSpecCol, entry.SendTMforNewSpec, entry.SendTMforNewSpecComment);
                addition.AddSubElement(_sendTMforChangedSpecCol, entry.SendTMforChangedSpec, entry.SendTMforChangedSpecComment);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ContainerConfigGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ContainerConfigGridControl";
            this.Size = new System.Drawing.Size(821, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
