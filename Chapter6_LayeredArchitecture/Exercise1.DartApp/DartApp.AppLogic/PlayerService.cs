using DartApp.AppLogic.Contracts;
using DartApp.Domain;
using DartApp.Domain.Contracts;
using System.Collections.Generic;

namespace DartApp.AppLogic
{
    internal class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public void AddGameResultForPlayer(IPlayer player, int number180, double average, int bestThrow)
        {
            IGameResult result = new GameResult(player.Id, number180, average, bestThrow);
            player.AddGameResult(result);
            _repository.SaveChanges(player);
        }

        public IPlayer AddPlayer(string playerName)
        {
            var player = new Player(playerName);
            _repository.Add(player);
            return player;
        }

        public IReadOnlyList<IPlayer> GetAllPlayers()
        {
            return _repository.GetAll();
        }

        public IPlayerStats GetStatsForPlayer(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
