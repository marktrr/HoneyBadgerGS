using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface IGameLogic
    {
        IEnumerable<Game> GetAll();
        int Add(Game game);
        int Update(Game game);
        Game Details(int id);
        int Delete(int id);
    }
}