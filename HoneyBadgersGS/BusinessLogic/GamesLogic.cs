using System.Collections.Generic;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class GamesLogic : IGamesLogic
    {
        private readonly IGamesDal _gamesDal;

        public GamesLogic(IGamesDal gamesDal)
        {
            _gamesDal = gamesDal;
        }
        
        public IEnumerable<Game> GetAll()
        {
            return _gamesDal.GetAll();
        }

        public int Add(Game game)
        {
            return _gamesDal.Add(game);
        }

        public int Update(Game game)
        {
            return _gamesDal.Update(game);
        }

        public Game Details(int id)
        {
            return _gamesDal.GetData(id);
        }
        public int Delete(int id)
        {
            return _gamesDal.Delete(id);
        }
    }
}