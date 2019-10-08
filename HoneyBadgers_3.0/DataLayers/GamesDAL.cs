using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers_3._0.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers_3._0.DataLayers
{
    public class GamesDAL
    {
        readonly HoneyBadgerDBContext db = new HoneyBadgerDBContext();

        public IEnumerable<Game> GetAllGames()
        {
            try
            {
                return db.Game.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int AddGame(Game game)
        {
            try
            {
                db.Game.Add(game);
                db.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int UpdateGame(Game game)
        {
            try
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Game GetGameData(int id)
        {
            try
            {
                Game game = db.Game.Find(id);
                return game;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int DeleteGame(int id)
        {
            try
            {
                Game _game = db.Game.Find(id);
                db.Game.Remove(_game);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //TODO: ADD rest of functions based on https://dzone.com/articles/aspnet-core-crud-with-reactjs-and-entity-framework
    }
}