using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers_3._0.DataLayers;
using HoneyBadgers_3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("api/Games/{id}")]
        public int Add(Game game)
        {
            return obj.AddGame(game);
        }

        //Updates Games in record
        [HttpPut]
        [Route("api/Games/{id}")]
        public int Edit(Game game)
        {
            return obj.UpdateGame(game);
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Game.Add(game);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameExists(game.GameId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAllGames", new { id = game.GameId }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }
    }
}
