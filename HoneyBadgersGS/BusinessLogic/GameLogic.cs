using System.Collections.Generic;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class GameLogic : IGameLogic
    {
        private IGameDal _gameDal;

        public GameLogic(IGameDal gamesDal)
        {
            _gameDal = gamesDal;
        }
        
        public IEnumerable<Game> GetAll()
        {
            return _gameDal.GetAll();
        }

        public int Add(Game game)
        {
            return _gameDal.Add(game);
        }

        public int Update(Game game)
        {
            return _gameDal.Update(game);
        }

        public Game Details(int id)
        {
            return _gameDal.GetData(id);
        }
        public int Delete(int id)
        {
            return _gameDal.Delete(id);
        }
    }
}