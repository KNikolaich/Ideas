using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public partial class StaffTimesContainer
    {

        public DataTable GetDataTable(List<string> fields, string tableName)
        {
            string selectF = fields.Aggregate("", (current, field) => current + (", " + field)).Trim(',');

            var table = new DataTable(tableName);
            var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = $"Select {selectF} from {tableName}";
            try
            {
                cmd.Connection.Open();
                table.Load(cmd.ExecuteReader());
            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;
        }

        public void SaveDataTable(DataTable myDataTable)
        {
            using (SqlConnection connection = new SqlConnection(Database.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        foreach (DataColumn c in myDataTable.Columns)
                            bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                        bulkCopy.DestinationTableName = myDataTable.TableName;

                        bulkCopy.WriteToServer(myDataTable);

                    }

                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public User CreateUser(string name, string login, string passwd, StaffRole role)
        {
            var user = new User
            {
                Login = login,
                UserName = name,
                Password = passwd,//.GetHashCode().ToString(),
                Role = role,

            };
            User.Add(user);
            SaveChanges();
            return user;
        }

        public User ChangeUserPassword(int id, string newPasswd)
        {
            var user = User.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Password = newPasswd;//.GetHashCode().ToString();
            }
            SaveChanges();
            return user;
        }

        /// <summary>
        /// Взять пользователя по паре логин/пароль
        /// </summary>
        /// <param name="login"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public User GetUser(string login, string passwd)
        {
            return User.FirstOrDefault(user => user.Login == login && user.Password == passwd);
        }
    }
}
