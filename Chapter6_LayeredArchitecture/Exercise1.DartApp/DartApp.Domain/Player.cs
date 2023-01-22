using DartApp.AppLogic;
using DartApp.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DartApp.Domain
{
    public class Player : IPlayer
    {
        private List<IGameResult> _gameResults;

        private Player()
        {
            _gameResults = new List<IGameResult>();
        }

        public Player(string name)
        {
            CheckInput(name);
            Name = name;
            Id = Guid.NewGuid();
            _gameResults = new List<IGameResult>();
        }

        private void CheckInput(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
        }

        public Guid Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public IReadOnlyCollection<IGameResult> GameResults => _gameResults;

        public void AddGameResult(IGameResult gameResult)
        {
            _gameResults.Add(gameResult);
        }

        public IPlayerStats GetPlayerStats()
        {
            if (_gameResults.Count == 0)
            {
                return new PlayerStats(0, 0, 0, 0);
            }

            var totalGames = Convert.ToDouble(_gameResults.Count);
            var averageThrow = _gameResults.Select(result => result.AverageThrow).Sum() / totalGames;
            var total180 = _gameResults.Select(result => result.NumberOf180).Sum();
            var bestThrowOpt = _gameResults.MaxBy(result => result.BestThrow);
            var bestThrow = 0;
            if (bestThrowOpt != null)
            {
                bestThrow = bestThrowOpt.BestThrow;
            }
            var averageBestThrow = _gameResults.Select(result => result.BestThrow).Sum() / totalGames;

            return new PlayerStats(total180, averageThrow, bestThrow, averageBestThrow);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
