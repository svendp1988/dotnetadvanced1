using DartApp.AppLogic.Contracts;
using DartApp.Domain;
using DartApp.Domain.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.IO.Directory;

namespace DartApp.Infrastructure.Storage
{
    internal class PlayerFileRepository : IPlayerRepository
    {
        private readonly string _playerFileDirectory;

        public PlayerFileRepository(string playerFileDirectory)
        {
            _playerFileDirectory = playerFileDirectory;
            bool exists = Exists(_playerFileDirectory);

            if(!exists)
                CreateDirectory(_playerFileDirectory);       
        }

        public void Add(IPlayer player)
        {
            SavePlayer(player);
        }

        public IReadOnlyList<IPlayer> GetAll()
        {
            //TODO: read all player files in the directory, convert them to IPlayer objects and return them
            //Tip: use helper methods that are given (ReadPlayerloadFromFile)
            var files = GetFiles(_playerFileDirectory);
            
            return files.Select(ReadPlayerFromFile).ToList();
        }

        public void SaveChanges(IPlayer player)
        {
            SavePlayer(player);
        }


        private IPlayer ReadPlayerFromFile(string playerFilePath)
        {
            //TODO: read the json in a player file and deserialize the json into an IPlayer object
            //Tip: use helper methods that are given (ConvertJsonToPlayer)
            var text = File.ReadAllText(playerFilePath);
            
            return ConvertJsonToPlayer(text);
        }

        private void SavePlayer(IPlayer player)
        {
            //TODO: save the player in a json format in a file
            //Tip: use helper methods that are given (GetPLayerilePath, ConvertPlayerToJson)
            var path = GetPlayerFilePath(player.Id);
            var json = ConvertPlayerToJson(player);
            File.WriteAllText(path, json);
        }

        private string ConvertPlayerToJson(IPlayer player)
        {
            string json = JsonConvert.SerializeObject(player, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            
            return json;
        }

        private Player ConvertJsonToPlayer(string json)
        {
            return JsonConvert.DeserializeObject<Player>(json, new JsonSerializerSettings
            {
                ContractResolver = new JsonAllowPrivateSetterContractResolver(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

        private string GetPlayerFilePath(Guid playerId)
        {
            string fileName = $"Player_{playerId}.json";
            
            return Path.Combine(_playerFileDirectory, fileName);
        }
    }
}
