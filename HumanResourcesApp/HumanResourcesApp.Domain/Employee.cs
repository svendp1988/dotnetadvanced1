namespace HumanResourcesApp.Domain
{
    public class Employee
    {
        public string EmployeeNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public EmployeeType Type { get; set; }
        public int TeamId { get; set; }
    }
}
