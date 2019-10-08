using System.Collections.Generic;
using System.Linq;
using HoneyBadgers_3._0.Models;

namespace HoneyBadgers_3._0.DataLayers
{
    public class GamesDAL
    {
        HoneyBadgerDBContext db = new HoneyBadgerDBContext();

        public IEnumerable<Game> GetAllGames()
        {
            return db.Game.ToList();
        }

        public int AddGame(Game game)
        {
            db.Game.Add(game);
            db.SaveChanges();
            return 1;

        }
        //TODO: ADD rest of functions based on https://dzone.com/articles/aspnet-core-crud-with-reactjs-and-entity-framework
            
    }
}