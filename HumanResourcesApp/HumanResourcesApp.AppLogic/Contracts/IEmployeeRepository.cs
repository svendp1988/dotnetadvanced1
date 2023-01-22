using HumanResourcesApp.Domain;

namespace HumanResourcesApp.AppLogic.Contracts
{
    public interface IEmployeeRepository
    {
        IReadOnlyList<Employee> FindEmployeesOfTeam(int teamId, EmployeeType type);
    }
}