using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StaffTimes.SubControls
{
    public partial class SummaryGrid : UserControl
    {
        public SummaryGrid()
        {
            InitializeComponent();
        }

        public void SetDataSource(GeneralFormFinder finder, DataTable dataTable)
        {
            //"UserId", "Date", "Duration"
            var dataRows = dataTable.Rows.Cast<DataRow>();

            dataGridView1.Columns.Clear();
            DataTable dtResult = new DataTable("Summaries");
            // берем даты с файндера (пусть он сам нам коллекцию нафигачит без выходных)
            // создаем коллекцию колонок по этим датам
            var format = "dd MMM";
            var colUserName = "user";
            dtResult.Columns.Add(colUserName);
            foreach (var colName in finder.ColumnFromDatesGenarator())
            {
                dtResult.Columns.Add(colName.ToString(format));
                //dataGridView1.Columns.Add(colName.ToString(format), colName.ToString(format));
                //формируем прямо тут колонки в грид и не даем им создаваться автоматом. 
            }

            // по ключу создаем строку для пользователя (если юзеров несколько, добавляем колонку с именем пользователя)
            var grouppedByUser = dataRows.OrderBy(t => Convert.ToDateTime(t["Date"]).Ticks).GroupBy(t => (int)t["UserId"]).ToList();

            var keys = grouppedByUser.Select(gpU => gpU.Key);
            //bool singleMode = !(grouppedByUser.Count > 1);
            var users = new Dictionary<int, string>();
            foreach (var user in finder.DbAdapter.Users.Where(u => keys.Contains(u.Id)))
            {
                users.Add(user.Id, user.UserName);
            }

            foreach (IGrouping<int, DataRow> grouping in grouppedByUser)
            {
                var userName = users[grouping.Key];
                var row = dtResult.NewRow();
                dtResult.Rows.Add(row);
                row[colUserName] = userName;
                // в созданную строку добавляем данные в колонки
                var grouppedByDate = grouping.GroupBy(t => Convert.ToDateTime(t["Date"]));
                foreach (var subGrouping in grouppedByDate)
                {
                    var colName = subGrouping.Key.ToString(format);
                    /* тут херабора с добавлением колонки в случае, если её нет уже в наборе колонок
                     * 
                    if (!dtResult.Columns.Contains(colName))
                    {
                        dtResult.Columns.Add()
                    }*/
                    if (dtResult.Columns.Contains(colName))
                    {
                        row[colName] = subGrouping.Sum(sg => (int) sg["Duration"]);
                    }
                }
                
                // для этого проходим по всем данным из значений в группировке и делаем row["dateFromColumn"] = summ(Duration)
                // где summ(Duration) это возврат Linq по нашей дате
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dtResult;
            if (users.Count == 1 && dataGridView1.Columns.Contains(colUserName) && dataGridView1.Columns[colUserName] != null)
            {
                dataGridView1.Columns[colUserName].Visible = false;
            }
        }
    }
}
