using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public interface IGamesDal
    {
         IEnumerable<Game> GetAll();
         int Add(Game game);
         int Update(Game game);
         Game GetData(int id);
         int Delete(int id);
         
    }
}