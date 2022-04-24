using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DbWorkerAndML.Model
{
    internal class Constants
    {
        // Проверка подлинности Windows
        public static string SqlConnectionIntegratedSecurity
        {
            get
            {
                var sb = new SqlConnectionStringBuilder
                {
                    DataSource = "(localdb)\\MSSQLLocalDB",
                    // Подключение будет с проверкой подлинности пользователя Windows
                    IntegratedSecurity = true,
                    // Название целевой базы данных.
                    InitialCatalog = "Hystory_Binance_test"
                };

                return sb.ConnectionString;
            }
        }


        // Проверка подлинности SQL сервером
        public static string SqlConnectionSQLServer
        {
            get
            {
                var sb = new SqlConnectionStringBuilder
                {
                    DataSource = "Путь к серверу SQL",
                    IntegratedSecurity = false,
                    InitialCatalog = "DBMSSQL",
                    UserID = "Имя пользователя",
                    Password = "Пароль"
                };

                return sb.ConnectionString;
            }
        }
    }
}
