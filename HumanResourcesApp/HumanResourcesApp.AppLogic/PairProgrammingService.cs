using HumanResourcesApp.AppLogic.Contracts;
using HumanResourcesApp.Domain;

namespace HumanResourcesApp.AppLogic
{
    internal class PairProgrammingService : IPairProgrammingService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Random _random;

        public PairProgrammingService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _random = new Random();
        }

        public IList<ProgrammingPair> GeneratePairsForTeam(int teamId)
        {
            IList<ProgrammingPair> pairs = new List<ProgrammingPair>();

            IReadOnlyList<Employee> developers = _employeeRepository.FindEmployeesOfTeam(teamId, EmployeeType.Developer);

            var developerPool = new List<Employee>(developers); //must make a copy because we will remove employees that are selected (cannot remove items from original list)
            while (developerPool.Count >= 2)
            {
                //select driver
                int index = _random.Next(developerPool.Count);
                Employee driver = developerPool[index];
                developerPool.RemoveAt(index);

                //select navigator
                index = _random.Next(developerPool.Count);
                Employee navigator = developerPool[index];
                developerPool.RemoveAt(index);

                pairs.Add(new ProgrammingPair(driver, navigator));
            }

            return pairs;
        }
    }
}
