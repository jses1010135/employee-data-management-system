using Microsoft.Data.SqlClient;

namespace employee_data_management_system.DAL
{
    internal class BaseDAL
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=Northwind;User Id=sa;Password=sa123;TrustServerCertificate=true;";
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
