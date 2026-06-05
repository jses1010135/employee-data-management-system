using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Data.Sqlite;

namespace employee_data_management_system.DAL
{
    
    internal class BaseDAL
    {
        // 1. 主連線： sa123
        private readonly string primaryConnStr = "Server=localhost\\SQLEXPRESS;Database=Northwind;User Id=sa;Password=sa123;TrustServerCertificate=true;";

        // 2. 備用連線：本機 bin 資料夾 
        //private readonly string fallbackConnStr = "Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Northwnd.mdf;Integrated Security=True;";

        private static bool? _useSQLite = null;
        private readonly string sqliteConnStr = "Data Source=Northwind.db";

        public IDbConnection GetConnection()
        {
            // 1. 如果之前已經確定要使用 SQLite
            if (_useSQLite == true)
            {
                return new SqliteConnection(sqliteConnStr);
            }
            // 2. 如果之前已經測試過 SQL Server 是活的，就直接用，不用再重複敲門
            else if (_useSQLite == false)
            {
                return new SqlConnection(primaryConnStr);
            }

            // 3. 程式剛啟動，初次執行：嘗試連線正式的 SQL Server
            try
            {
                using (SqlConnection testConn = new SqlConnection(primaryConnStr))
                {
                    testConn.Open(); // 嘗試敲門！
                } // 離開 using 區塊會自動安全關聯 (Close)

                // 門有開代表正常，記錄下來下次就不必重複測了
                _useSQLite = false;

                return new SqlConnection(primaryConnStr);
            }
            catch (Exception) // 將 SqlException 放寬為 Exception，確保各種無法連線的狀況都能成功降級到 SQLite
            {
                _useSQLite = true;
                return new SqliteConnection(sqliteConnStr);
            }
        }
    }
}
