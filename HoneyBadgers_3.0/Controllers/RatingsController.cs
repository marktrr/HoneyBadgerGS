using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers_3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers_3._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly HoneyBadgerDBContext _context;

        public RatingsController(HoneyBadgerDBContext context)
        {
            _context = context;
        }

        // GET: api/Ratings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRating()
        {
            return await _context.Rating.ToListAsync();
        }

        // GET: api/Ratings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
            var rating = await _context.Rating.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            return rating;
        }

        // PUT: api/Ratings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRating(int id, Rating rating)
        {
            if (id != rating.RatingId)
            {
                return BadRequest();
            }

            _context.Entry(rating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // POST: api/Ratings
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(Rating rating)
        {
            _context.Rating.Add(rating);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RatingExists(rating.RatingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRating", new { id = rating.RatingId }, rating);
        }

        // DELETE: api/Ratings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rating>> DeleteRating(int id)
        {
            var rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            _context.Rating.Remove(rating);
            await _context.SaveChangesAsync();

            return rating;
        }

        private bool RatingExists(int id)
        {
            return _context.Rating.Any(e => e.RatingId == id);
        }
    }
}
