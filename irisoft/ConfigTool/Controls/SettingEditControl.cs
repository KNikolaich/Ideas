using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuration.Helpers;

namespace Configuration.Controls
{
    public partial class SettingEditControl : UserControl
    {
        private Assistant _assistant;

        public SettingEditControl()
        {
            InitializeComponent();
        }

        public void SetAssistant(Assistant assistant)
        {
            dataGridFolders.DataSource = assistant.SharedFolders;
            gridHiddenControls.SetDataTable(assistant.HiddenTags, "", "Value");
            gridHiddenControls.SetLabelTexts("Список скрываемых полей", "");
            _assistant = assistant;
            gridHiddenControls.SetInfoToolTipText("Для применения настроек необходимо перезагрузить приложение.");
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridFolders.Columns.IndexOf(_colBtnOpenFileDlg))
            {
                var row = dataGridFolders.Rows[e.RowIndex];
                var drw = row.DataBoundItem as DataRowView;
                using (var browserDialog = new FolderBrowserDialog())
                {
                    string folderName;
                    folderName = drw["FolderName"].ToString();
                    browserDialog.ShowNewFolderButton = true;
                    browserDialog.SelectedPath = folderName;
                    if (browserDialog.ShowDialog() == DialogResult.OK)
                    {
                        drw["FolderName"] = browserDialog.SelectedPath;
                        dataGridFolders.Refresh();
                    }
                }
            }
        }

        private void _tsmiDelete_Click(object sender, EventArgs e)
        {

            string sMsg = "";

            var dt = dataGridFolders.DataSource as DataTable;
            if (dataGridFolders.CurrentRow == null || dataGridFolders.CurrentRow.IsNewRow)
            {
                sMsg = "Необходимо выбрать строку";
                MessageBox.Show(sMsg, "Удаление строк.");
            }
            else
            {
                var rowCurr = dt.Rows[dataGridFolders.CurrentRow.Index];
                sMsg += $"Удалить строку? {rowCurr["FolderName"]}";
                if (MessageBox.Show(sMsg, "Удаление строк.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dt.Rows[dataGridFolders.CurrentRow.Index].Delete();
                }
            }
        }

        private void _tsmiAdd_Click(object sender, EventArgs e)
        {
            using (var browserDialog = new FolderBrowserDialog())
            {
                var ds = dataGridFolders.DataSource as DataTable;
                DataRow dr = ds.NewRow();
                ds.Rows.Add(dr);
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    dr["FolderName"] = browserDialog.SelectedPath;
                    dataGridFolders.Refresh();
                }
            }
        }

        private void _tsmiValidate_Click(object sender, EventArgs e)
        {
            _assistant.ValidateFolders();
        }
    }
}