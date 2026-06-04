using employee_data_management_system.DAL;
using employee_data_management_system.models;
namespace employee_data_management_system.BLL
{
    internal class EmployeeBLL
    {
        private EmployeeDAL employeeDAL;
        public EmployeeBLL()
        {
            employeeDAL = new EmployeeDAL();
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.GetAllEmployees();
        }
        public Image GetEmployeePhoto(byte[] photoBytes)
        {
            if (photoBytes == null || photoBytes.Length == 0)
                return null;

            try
            {
                // 嘗試處理 Northwind 舊格式 (跳過前 78 bytes)
                if (photoBytes.Length > 78)
                {
                    MemoryStream ms = new MemoryStream(photoBytes, 78, photoBytes.Length - 78);
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                // 如果失敗，略過並在下方嘗試另一種方法
            }

            try
            {
                // 嘗試正常格式 (直接轉換，適用於未來新上傳的照片)
                MemoryStream ms = new MemoryStream(photoBytes);
                return Image.FromStream(ms);
            }
            catch
            {
                // 確保程式不會崩潰
            }

            // ★ 關鍵：確保在所有情況下都有回傳值，解決 CS0161 錯誤
            return null;
        }
        // 記得確認最上方有 using System.IO;

        public byte[] ConvertFileToByteArray(string filePath)
        {
            // 如果沒有傳入路徑，則回傳 null
            if (string.IsNullOrEmpty(filePath))
                return null;

            // File.ReadAllBytes 是一個非常方便的內建方法
            // 它會讀取指定路徑的檔案，並直接回傳成 byte[] 陣列
            return File.ReadAllBytes(filePath);
        }
        public bool UpdateEmployee(Employee emp)
        {
            // 直接呼叫 DAL 層的更新方法
            return employeeDAL.UpdateEmployee(emp);
        }
        public bool InsertEmployee(Employee emp)
        {
            return employeeDAL.InsertEmployee(emp);
        }
        
        public List<Territory> GetEmployeeTerritories(Employee emp)
        {
            return employeeDAL.GetEmployeeTerritories(emp);
        }
      
        public List<Territory> GetAllTerritories()
        {
            return employeeDAL.GetAllTerritories(); 
        }
        
        public bool InsertEmployeeTerritory(int employeeId, string territoryId)
        {
            return employeeDAL.InsertEmployeeTerritory(employeeId, territoryId);
        }
        public bool CheckTerritoryExists(int employeeId, string territoryId)
        {
            return employeeDAL.CheckTerritoryExists(employeeId, territoryId);
        }
    }
}
