namespace employee_data_management_system.models
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo {  get; set; }
        public string full_name { get { return $"{FirstName} {LastName}"; } }


    }
}
