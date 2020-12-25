using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Exceptions;
using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    public partial class GridWithLabelControl : ElementBaseControl
    {
        public GridWithLabelControl()
        {
            InitializeComponent();
        }

        public bool VisibleTop
        {
            get { return panelTop.Visible; }
            set { panelTop.Visible = value; }
        }

        [Browsable(false)]
        public DataTable DataTable
        {
            get { return _dataGridView.DataSource as DataTable; }
            set { SetDataTable(value, value.Columns.Cast<DataColumn>().Select(dc=>dc.ColumnName).ToArray()); }
        }

        /// <summary>
        /// Устанавливаем текст всплывающей подсказки для информационной кнопки
        /// </summary>
        /// <param name="toolTipText"></param>
        public void SetInfoToolTipText(string toolTipText)
        {
            _tsbQuestion.Visible = true;
            _tsbQuestion.ToolTipText = toolTipText;
        }

        internal virtual void SetDataTable(DataTable dt, params string[] otherColumns)
        {
            _bDeleteRow.ToolTipText = "Удалить строку";
            _bDeleteRow.AutoToolTip = false;

            string queueCol = otherColumns[0];
            string valueCol = otherColumns.Length > 1 ? otherColumns[1]: null;
            if (!string.IsNullOrEmpty(queueCol))
            {
                _columnQueue.HeaderText = queueCol;
                _columnQueue.DataPropertyName = queueCol;
                _columnQueue.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else
            {
                if(_dataGridView.Columns.Contains(_columnQueue))
                    _dataGridView.Columns.Remove(_columnQueue);
            }

            if (!string.IsNullOrEmpty(valueCol))
            {
                _columnText.DataPropertyName = valueCol;
                _columnText.HeaderText = valueCol;
                _columnText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                if(_dataGridView.Columns.Contains(_columnText))
                    _dataGridView.Columns.Remove(_columnText);
            }       
            
            if (otherColumns.Length < 3)
            {
                _columnComment.Visible = false;
            }
            else if (otherColumns.Length >=3)
            {
                _columnComment.DataPropertyName = otherColumns[2];
                _columnComment.HeaderText = otherColumns[2];
            }
            if (otherColumns.Length > 4)
            {
                for (var index = 1; index < otherColumns.Length; index++)
                {
                    var otherColumn = otherColumns[index];
                    var columnOther =
                        new DataGridViewTextBoxColumn
                        {
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                            HeaderText = otherColumn,
                            Name = $"columnOther{index}",
                            DataPropertyName = otherColumn
                        };
                    _dataGridView.Columns.Add(columnOther);
                }
            }
            
            _dataGridView.DataSource = dt;
            _dataGridView.Name = dt.TableName;
            _dataGridView.RowEnter += DataGridView_RowEnter;
            _dataGridView.RowValidating += _dataGridView_RowValidating;
        }

        protected void _dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //_dataGridView.Columns[_columnQueue.Name] != null
            string dataPropertyName;
            if (_columnQueue.Visible && _dataGridView.Columns[_columnQueue.Name] != null)
            {
                dataPropertyName = _columnQueue.DataPropertyName;
            }
            else
            {
                dataPropertyName = _columnText.DataPropertyName;
            }
            e.Cancel = !ValidateDataTable(_currentElement?.Name.LocalName ?? _dataGridView.Name, dataPropertyName, true);
        }

        public void SetAutosizeColumn(string columnName, DataGridViewAutoSizeColumnMode mode)
        {
            foreach (DataGridViewColumn dataColumn in _dataGridView.Columns)
            {
                if (dataColumn.DataPropertyName == columnName)
                {
                    dataColumn.AutoSizeMode = mode;
                }
            }
        }

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            _currentElement = xElement;
            SetLabelTexts(xElement.Name.LocalName, GetCommentText(xElement));
            Assistant.GetInstance().BeforeHasDifferents += BeforeHasDifferents;
        }

        internal void SetLabelTexts(string lFirstText, string lTwoText = "")
        {
            panelTop.Visible = true;
            if (!string.IsNullOrEmpty(lFirstText))
            {
                _labelXelement.Visible = true;
                _labelXelement.Text = lFirstText;

            }
            if (!string.IsNullOrEmpty(lTwoText))
            {
                _labelCommentXelement.Visible = true;
                _labelCommentXelement.Text = lTwoText;
            }
        }


        private void _dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            throw e.Exception;
        }

        protected override void BeforeHasDifferents(object sender, EventArgs e)
        {
            
        }

        /// вход в строку
        private void DataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
//            e.RowIndex
        }
        

        private void tssUp_ButtonClick(object sender, EventArgs e)
        {
            /*var currentRow = _dataGridView.CurrentRow;
            var currDrv = currentRow?.DataBoundItem as DataRowView;
            if (currDrv != null)
            {
                currDrv.DataView.Sort = _columnQueue.DataPropertyName;
                var currQueue = Convert.ToInt32(currDrv[_columnQueue.DataPropertyName]);
                if (currQueue <= 1)
                {
                    currDrv[_columnQueue.DataPropertyName] = -1;
                }
                else
                {
                    // собрать все данные строк, которые меньше, чем  currQueue
                    // взять из них максимум
                    // поменять местами их свойства Queue
                    // отсортировать строки 
                    // обновить данные
                    List<int> lessesRows = new List<int>();
                    foreach (DataRow row in currDrv.DataView.Table.Rows)
                    {
                        var que = Convert.ToInt32(row[_columnQueue.Index]);

                        if (que > 0 && que - currQueue < 0)
                        {
                            lessesRows.Add(que);
                        }
                    }
                    if (lessesRows.Count == 0 || lessesRows.Max() < currQueue - 1) // если не имеет конкуретнтой строки для перемещения
                    {
                        currDrv[_columnQueue.DataPropertyName] = currQueue - 1;
                    }
                    else // меняемся с предыдущей строкой местами
                    {
                        currDrv.DataView.FindRows($"{lessesRows.Max()}").First()[_columnQueue.DataPropertyName] = currQueue;

                        currDrv[_columnQueue.DataPropertyName] = currQueue - 1;
                    }
                }
                _dataGridView.Refresh();
            }*/
        }

        private void tssDown_ButtonClick(object sender, EventArgs e)
        {
            /*var currentRow = _dataGridView.CurrentRow;
            var currDrv = currentRow?.DataBoundItem as DataRowView;
            if (currDrv != null)
            {
                currDrv.DataView.Sort = _columnQueue.DataPropertyName;
                var currQueue = Convert.ToInt32(currDrv[_columnQueue.DataPropertyName]);
                List<int> biggestRows = new List<int>();
                foreach (DataRow row in currDrv.DataView.Table.Rows)
                {
                    var que = Convert.ToInt32(row[_columnQueue.Index]);

                    if (que < currQueue)
                    {
                        biggestRows.Add(que);
                    }
                }

                if (currQueue < 0) // была отключена строка
                {
                    // ищем строку 1, и ищем строку 2

                    // есили нашли 1 но не нашли 2
                    //       прибавляем строке 1 значение и выходим из метода всплытия
                    // иначе, нашли 1 и 2
                    //      прибавляем строке 1 значение, принимаем строка 1 = строка 2, а строка 2 ищем из значения первой +1
                    //      повторяем Проверку условия
                    int firstQ = 1;
                    int secondQ = 2;
                    var firstRow = currDrv.DataView.FindRows($"{firstQ}").FirstOrDefault();
                    var secondRow = currDrv.DataView.FindRows($"{secondQ}").FirstOrDefault();
                    while (firstRow != null)
                    {
                        if (secondRow == null)
                        {
                            var queueFirst = Convert.ToInt32(firstRow[_columnQueue.DataPropertyName]);
                            firstRow[_columnQueue.DataPropertyName] = queueFirst + 1;
                            firstRow = null;
                        }
                        else
                        {
                            secondQ++;
                            secondRow = currDrv.DataView.FindRows($"{secondQ}").FirstOrDefault();
                            firstRow[_columnQueue.DataPropertyName] = secondQ;
                        }
                    }
                    currDrv[_columnQueue.DataPropertyName] = 1; 
                }
                else if (currQueue > 0) // если не имеет конкуретнтой строки для перемещения
                {
                    if(biggestRows.Count > 0 && biggestRows.Min() > currQueue +1) // был какой то пропуск
                        currDrv[_columnQueue.DataPropertyName] = currQueue + 1;
                    else // меняемся с предыдущей строкой местами
                    {
                        currDrv.DataView.FindRows($"{biggestRows.Max()}").First()[_columnQueue.DataPropertyName] = currQueue;
                        currDrv[_columnQueue.DataPropertyName] = currQueue + 1;
                    }
                }

                _dataGridView.Refresh();
            }*/
        }

        private void _bDeleteRow_ButtonClick(object sender, EventArgs e)
        {
            if (_dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Не выбрана ни одна строка.", "Удаление строк", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (_dataGridView.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Строка со звездочкой ещё не создана. Для её очистки используйте Esc", "Удаление строк", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _dataGridView.CurrentRow.Selected = true;
                var selectedRow = _dataGridView.SelectedRows[0];
                var drv = selectedRow.DataBoundItem as DataRowView;
                if (drv == null)
                {
                    MessageBox.Show("Данные в строке не соответсвуют представлению DataRowView",
                        "Удаление строк", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    var stringRow = "";
                    foreach (DataGridViewColumn column in _dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            var value = drv[column.DataPropertyName];
                            if (value != DBNull.Value)
                            {
                                stringRow += $" {column.DataPropertyName} - {value} |";
                            }
                        }
                    }
                    if (MessageBox.Show(
                        $"Вы действительно хотите удалить строку:{Environment.NewLine}{stringRow.Trim('|')}",
                        "Удаление строк", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _dataGridView.Rows.RemoveAt(selectedRow.Index);
                    }
                    
                }
            }
        }

        /// <summary>
        /// Валидатор уникальности значений. 
        /// </summary>
        /// <param name="elementName">название элемента для отображения Exception</param>
        /// <param name="validateColumns">валидируемые колонки</param>
        /// <param name="onlyWarning">только лиш предупреждение (иначе Exception)</param>
        public virtual bool ValidateDataTable(string elementName, string validateColumns, bool onlyWarning = false)
        {
            var qniqueValues = DataTable.Rows.Cast<DataRow>().
                Where(row=> row[validateColumns] != DBNull.Value && !row[validateColumns].ToString().Equals("-1")).
                Select(row => row[validateColumns].ToString());
            return UnuniqueValueException.Validate(qniqueValues, elementName, onlyWarning);
        }
    }
}
