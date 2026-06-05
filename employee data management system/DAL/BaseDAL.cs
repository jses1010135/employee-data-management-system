using Microsoft.Data.SqlClient;

namespace employee_data_management_system.DAL
{
    
    internal class BaseDAL
    {
        // 1. 主連線： sa123
        private readonly string primaryConnStr = "Server=localhost\\SQLEXPRESS;Database=Northwind;User Id=sa;Password=sa123;TrustServerCertificate=true;";

        // 2. 備用連線：本機 bin 資料夾 
        private readonly string fallbackConnStr = "Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Northwnd.mdf;Integrated Security=True;";

        private static string _activeConnStr = null;

        protected SqlConnection GetConnection()
        {

            // 只有第一次呼叫 (或是還不知道誰活著) 的時候，才做測試     
            if (_activeConnStr == null)
            {
                try
                {
                    // 嘗試去敲主資料庫的門
                    using (SqlConnection testConn = new SqlConnection(primaryConnStr))
                    {
                        testConn.Open();
                    }

                    // ??? 如果程式順利走到這裡（沒有當機跳走），代表主連線是通的！
                    // ??? 請在這裡將 _activeConnStr 指定為 primaryConnStr
                    _activeConnStr = primaryConnStr;

                }
                catch
                {
                    // ??? 如果發生錯誤來到這裡，代表主連線掛了！
                    // ??? 請在這裡將 _activeConnStr 指定為 fallbackConnStr
                    _activeConnStr = fallbackConnStr;

                }
            }

            // 回傳最終決定好的那條連線
            return new SqlConnection(_activeConnStr);
        }
    }
}
