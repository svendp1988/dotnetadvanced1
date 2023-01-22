namespace HumanResourcesApp.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IList<Employee> Employees { get; set; } = new List<Employee>();
    }
}