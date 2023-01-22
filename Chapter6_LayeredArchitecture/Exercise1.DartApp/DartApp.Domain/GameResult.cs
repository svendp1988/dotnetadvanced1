using DartApp.Domain.Contracts;
using System;

namespace DartApp.Domain
{
    internal class GameResult : IGameResult
    {
        private GameResult()
        {
        }

        public GameResult(Guid playerId, int numberOf180, double averageThrow, int bestThrow)
        {
            CheckInput(numberOf180, averageThrow, bestThrow);
            Id = playerId;
            PlayerId = playerId;
            NumberOf180 = numberOf180;
            AverageThrow = averageThrow;
            BestThrow = bestThrow;
        }

        private static void CheckInput(int numberOf180, double averageThrow, int bestThrow)
        {
            if (numberOf180 < 0 || averageThrow < 0 || bestThrow < 0 || averageThrow > bestThrow ||
                (numberOf180 > 0 && bestThrow < 180) || bestThrow > 180)
            {
                throw new ArgumentException();
            }
        }

        public Guid Id { get; private set; }
        public Guid PlayerId { get; private set; }
        public int NumberOf180 { get; private set; }
        public double AverageThrow { get; private set; }
        public int BestThrow { get; private set; }

        public override string ToString()
        {
            return $"Average: {AverageThrow:F2}; 180s: {NumberOf180}; Best: {BestThrow}";
        }
    }
}
