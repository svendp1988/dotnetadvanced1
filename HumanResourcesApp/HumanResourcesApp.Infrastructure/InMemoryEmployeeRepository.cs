using HumanResourcesApp.AppLogic.Contracts;
using HumanResourcesApp.Domain;

namespace HumanResourcesApp.Infrastructure
{
    internal class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _dummyEmployees;

        public InMemoryEmployeeRepository()
        {
            _dummyEmployees = new List<Employee>();
            for (int i = 1; i <= 12; i++)
            {
                _dummyEmployees.Add(CreateDummyDeveloper(i));
            }
        }

        public IReadOnlyList<Employee> FindEmployeesOfTeam(int teamId, EmployeeType type)
        {
            return _dummyEmployees;
        }

        private Employee CreateDummyDeveloper(int identifier)
        {
            return new Employee
            {
                EmployeeNumber = identifier.ToString().PadLeft(5, '0'),
                FirstName = "John",
                LastName = $"Doe{identifier}",
                TeamId = 1,
                Type = EmployeeType.Developer
            };
        }
    }
}
