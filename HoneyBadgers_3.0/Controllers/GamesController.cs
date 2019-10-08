using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers_3._0.DataLayers;
using HoneyBadgers_3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgerGameStore.Controllers
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

        // GET: api/Games
        [HttpGet]
        [Route("api/Games")]
        public IEnumerable<Game> GetAllGames()
        {
            return obj.GetAllGames();
        }
        
        //TODO: Convert everything below this comment and remove DB context.
        
        //Add Single Game to Record
        // GET: api/Games/5
        [HttpGet]
        [Route("api/Games/{id}")]
        public int Add(Game game)
        {
            return obj.AddGame(game);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
