using System.Collections.Generic;
using HoneyBadgers_3._0.DataLayers;
using HoneyBadgers_3._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers_3._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private HoneyBadgerDBContext _context; //to be removed
        private GamesDAL obj = new GamesDAL();
        public GamesController(HoneyBadgerDBContext context)
        {
            //to be removed
            _context = context;
        }

        [HttpGet]
        [Route("api/Games")]
        public IEnumerable<Game> GetAllGames()
        {
            return obj.GetAllGames();
        }
        
        //TODO: Convert everything below this comment and remove DB context.
        
        //Add Single Game to Record
        [HttpGet]
        [Route("api/Games/Add")]
        public int Add(Game game)
        {
            return obj.AddGame(game);
        }

        //Updates Games in record
        [HttpPut]
        [Route("api/Games/Update")]
        public int Update(Game game)
        {
            return obj.UpdateGame(game);
        }
        [HttpGet]
        [Route("api/Games/Details/{id}")]
        public Game Details(int id)
        {
            return obj.GetGameData(id);
        }
        [HttpDelete]
        [Route("api/Games/Delete")]
        public int Delete(int id)
        {
            return obj.DeleteGame(id);
        }
    }
}
