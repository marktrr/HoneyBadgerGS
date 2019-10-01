using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers_3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgerGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly HoneyBadgerDBContext _context;

        public ReviewsController(HoneyBadgerDBContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReview()
        {
            return await _context.Review.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Review.Add(review);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReviewExists(review.ReviewId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ReviewId == id);
        }
    }
}
