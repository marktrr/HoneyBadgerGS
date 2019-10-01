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
    public class WishlistsController : ControllerBase
    {
        private readonly HoneyBadgerDBContext _context;

        public WishlistsController(HoneyBadgerDBContext context)
        {
            _context = context;
        }

        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist()
        {
            return await _context.Wishlist.ToListAsync();
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
            var wishlist = await _context.Wishlist.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }

        // PUT: api/Wishlists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int id, Wishlist wishlist)
        {
            if (id != wishlist.WishlistId)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlists
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            _context.Wishlist.Add(wishlist);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WishlistExists(wishlist.WishlistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWishlist", new { id = wishlist.WishlistId }, wishlist);
        }

        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wishlist>> DeleteWishlist(int id)
        {
            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlist.Remove(wishlist);
            await _context.SaveChangesAsync();

            return wishlist;
        }

        private bool WishlistExists(int id)
        {
            return _context.Wishlist.Any(e => e.WishlistId == id);
        }
    }
}
