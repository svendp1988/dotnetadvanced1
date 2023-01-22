using DartApp.Domain.Contracts;

namespace DartApp.AppLogic
{
    internal class PlayerStats : IPlayerStats
    {
        public PlayerStats(int total180, double averageThrow, int bestThrow, double averageBestThrow)
        {
            AverageThrow = averageThrow;
            Total180 = total180;
            BestThrow = bestThrow;
            AverageBestThrow = averageBestThrow;
        }

        public double AverageThrow { get; set; }
        public int Total180 { get; set; }
        public int BestThrow { get; set; }
        public double AverageBestThrow { get; set; }

        public override string ToString()
        {
            return
                $"Average: {AverageThrow:F2}; 180s: {Total180}; Best throw: {BestThrow} (Average best throw: {AverageBestThrow:F2})";
        }
    }
}
