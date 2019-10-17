using System.Collections.Generic;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGamesLogic _gamesLogic;

        public GamesController(IGamesLogic gamesLogic)
        {
            _gamesLogic = gamesLogic;
        }

        [HttpGet]
        [Route("api/Games")]
        public IEnumerable<Game> GetAllGames()
        {
            return _gamesLogic.GetAll();
        }
        
        //TODO: Convert everything below this comment and remove DB context.
        
        //Add Single Game to Record
        [HttpGet]
        [Route("api/Games/Add")]
        public int Add(Game game)
        {
            return _gamesLogic.Add(game);
        }

        //Updates Games in record
        [HttpPut]
        [Route("api/Games/Update")]
        public int Update(Game game)
        {
            return _gamesLogic.Update(game);
        }
        [HttpGet]
        [Route("api/Games/Details/{id}")]
        public Game Details(int id)
        {
            return _gamesLogic.Details(id);
        }
        [HttpDelete]
        [Route("api/Games/Delete")]
        public int Delete(int id)
        {
            return _gamesLogic.Delete(id);
        }
    }
}
