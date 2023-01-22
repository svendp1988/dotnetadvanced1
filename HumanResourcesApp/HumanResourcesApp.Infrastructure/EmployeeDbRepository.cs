using HumanResourcesApp.AppLogic.Contracts;
using HumanResourcesApp.Domain;

namespace HumanResourcesApp.Infrastructure;

public class EmployeeDbRepository : IEmployeeRepository
{
    private readonly HumanResourcesContext _context;

    public EmployeeDbRepository(HumanResourcesContext context)
    {
        _context = context;
    }

    public IReadOnlyList<Employee> FindEmployeesOfTeam(int teamId, EmployeeType type)
    {
        return _context.Employees.Where(e => e.TeamId == teamId && e.Type == type).ToList();
    }
}