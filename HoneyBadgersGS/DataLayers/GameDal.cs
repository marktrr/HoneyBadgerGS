using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.DataLayers
{
    public class GameDal : IGameDal
    {
        private HoneyBadgerDBContext _db;

        public GameDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Game> GetAll()
        {
            return _db.Game.ToList();
        }
        public int Add(Game game)
        {
            _db.Game.Add(game);
            _db.SaveChangesAsync();
            return 1;
        }

        public int Update(Game game)
        {
            _db.Entry(game).State = EntityState.Modified;
            _db.SaveChangesAsync();
            return 1;
        }

        public Game GetData(int id)
        {
            Game game = _db.Game.Find(id);
            return game;
        }

        public int Delete(int id)
        {
            Game game = _db.Game.Find(id);
            _db.Game.Remove(game);
            _db.SaveChangesAsync();
            return 1;
        }
        //TODO: ADD rest of functions based on https://dzone.com/articles/aspnet-core-crud-with-reactjs-and-entity-framework
    }
}