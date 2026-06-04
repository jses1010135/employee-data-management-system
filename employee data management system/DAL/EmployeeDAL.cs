using employee_data_management_system.models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace employee_data_management_system.DAL
{
    internal class EmployeeDAL : BaseDAL
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            string query = "SELECT EmployeeID, FirstName, LastName, Photo FROM Employees";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee();
                            emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            emp.FirstName = reader["FirstName"].ToString();
                            emp.LastName = reader["LastName"].ToString();

                            // 處理照片可能為 NULL 的情況
                            if (reader["Photo"] != DBNull.Value)
                            {
                                emp.Photo = (byte[])reader["Photo"];
                            }

                            employees.Add(emp);
                        }
                    }
                }
            }
            return employees;

        }
        public bool UpdateEmployee(Employee emp)
        {
            // 使用 @ 符號定義參數
            string query = "UPDATE Employees SET Photo = @Photo, FirstName = @FirstName, LastName = @LastName WHERE EmployeeID = @EmployeeID";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 綁定員工 ID
                    cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                    cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", emp.LastName);

                    // 綁定照片資料，並處理照片可能為 null 的情況
                    // --- 照片參數防呆處理 ---
                    // 明確宣告這是一個 Image (二進位) 欄位，不要讓 C# 亂猜
                    SqlParameter photoParam = new SqlParameter("@Photo", SqlDbType.Image);

                    // 判斷：如果有照片就給照片，沒有照片就給資料庫專用的空值 (DBNull.Value)
                    if (emp.Photo != null)
                    {
                        photoParam.Value = emp.Photo;
                    }
                    else
                    {
                        photoParam.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(photoParam);
                    // ------------------------

                    conn.Open();
                    // ExecuteNonQuery 會回傳受影響的資料列數，大於 0 代表更新成功
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool InsertEmployee(Employee emp)
        {
            // 使用 @ 符號定義參數
            string query = "INSERT INTO Employees (FirstName, LastName, Photo) VALUES (@FirstName, @LastName, @Photo)";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 綁定員工 ID
                    cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", emp.LastName);

                    // 綁定照片資料，並處理照片可能為 null 的情況
                    // --- 照片參數防呆處理 ---
                    // 明確宣告這是一個 Image (二進位) 欄位，不要讓 C# 亂猜
                    SqlParameter photoParam = new SqlParameter("@Photo", SqlDbType.Image);

                    // 判斷：如果有照片就給照片，沒有照片就給資料庫專用的空值 (DBNull.Value)
                    if (emp.Photo != null)
                    {
                        photoParam.Value = emp.Photo;
                    }
                    else
                    {
                        photoParam.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(photoParam);
                    // ------------------------

                    conn.Open();
                    // ExecuteNonQuery 會回傳受影響的資料列數，大於 0 代表更新成功
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

        }
        public List<Territory> GetEmployeeTerritories(Employee emp)
        {
            // 準備一個空的清單來裝資料
            List<Territory> territories = new List<Territory>();

            
            string query = @"
        SELECT Territories.TerritoryID, Territories.TerritoryDescription 
        FROM EmployeeTerritories 
        JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID 
        WHERE EmployeeTerritories.EmployeeID = @EmployeeID";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 綁定員工 ID
                    cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);

                    conn.Open();

                    // 執行查詢並取得資料讀取器
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                       
                        while (reader.Read())
                        {
                            Territory territory = new Territory();
                            territory.TerritoryId = reader["TerritoryId"].ToString();
                            territory.TerritoryDescription = reader["TerritoryDescription"].ToString();
                            territories.Add(territory);
                        }
                    }
                }
            }

            // 回傳裝滿資料的清單
            return territories;
        }
        public List<Territory> GetAllTerritories()
        {
            List<Territory> territories = new List<Territory>();
            string query = "SELECT TerritoryID, TerritoryDescription FROM Territories";
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Territory territory = new Territory();
                            territory.TerritoryId = reader["TerritoryId"].ToString();
                            territory.TerritoryDescription = reader["TerritoryDescription"].ToString();
                            territories.Add(territory);
                        }
                    }
                }
            }
            return territories;
        }
        
        public bool InsertEmployeeTerritory(int employeeId, string territoryId)
        {
            string query = @"
        INSERT INTO EmployeeTerritories (EmployeeID, TerritoryID) 
        VALUES (@EmployeeID, @TerritoryID)";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@TerritoryID", territoryId);

                    conn.Open();

                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // 如果受影響的資料列大於 0，代表新增成功
                     return rowsAffected > 0;
                }
            }

        }
        public bool CheckTerritoryExists(int employeeId, string territoryId)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM EmployeeTerritories 
        WHERE EmployeeID = @EmployeeID AND TerritoryID = @TerritoryID";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@TerritoryID", territoryId);

                    conn.Open();

                    // ExecuteScalar 會回傳查詢結果的第一列第一行，我們把它強制轉型成整數
                    int count = (int)cmd.ExecuteScalar();

                    // 如果 count 大於 0，代表資料庫裡已經有這筆紀錄了 (回傳 true)
                    return count > 0;
                }
            }
        }
    }
}
