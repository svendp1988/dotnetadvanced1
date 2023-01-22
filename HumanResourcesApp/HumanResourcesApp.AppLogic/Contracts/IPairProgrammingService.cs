using HumanResourcesApp.Domain;

namespace HumanResourcesApp.AppLogic.Contracts
{
    public interface IPairProgrammingService
    {
        IList<ProgrammingPair> GeneratePairsForTeam(int teamId);
    }
}