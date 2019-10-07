using System.Collections.Generic;
using System.Linq;
using HoneyBadgers_3._0.Models;

namespace HoneyBadgers_3._0.DataLayers
{
    public class GamesDAL
    {
        HoneyBadgerDBContext _context = new HoneyBadgerDBContext();

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Game.ToList();
        }
        
        //TODO: ADD rest of functions based on https://dzone.com/articles/aspnet-core-crud-with-reactjs-and-entity-framework
            
    }
}