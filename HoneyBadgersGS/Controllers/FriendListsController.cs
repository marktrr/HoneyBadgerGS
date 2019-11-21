using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendListsController : ControllerBase
    {
        private readonly HoneyBadgerContext _context;

        public FriendListsController(HoneyBadgerContext context)
        {
            _context = context;
        }

        // GET: api/FriendLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendList>>> GetFriendList()
        {
            return await _context.FriendList.ToListAsync();
        }

        // GET: api/FriendLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendList>> GetFriendList(int id)
        {
            var friendList = await _context.FriendList.FindAsync(id);

            if (friendList == null)
            {
                return NotFound();
            }

            return friendList;
        }

        // PUT: api/FriendLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriendList(int id, FriendList friendList)
        {
            if (id != friendList.FriendListId)
            {
                return BadRequest();
            }

            _context.Entry(friendList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendListExists(id))
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

        // POST: api/FriendLists
        [HttpPost]
        public async Task<ActionResult<FriendList>> PostFriendList(FriendList friendList)
        {
            _context.FriendList.Add(friendList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FriendListExists(friendList.FriendListId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFriendList", new { id = friendList.FriendListId }, friendList);
        }

        // DELETE: api/FriendLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendList>> DeleteFriendList(int id)
        {
            var friendList = await _context.FriendList.FindAsync(id);
            if (friendList == null)
            {
                return NotFound();
            }

            _context.FriendList.Remove(friendList);
            await _context.SaveChangesAsync();

            return friendList;
        }

        private bool FriendListExists(int id)
        {
            return _context.FriendList.Any(e => e.FriendListId == id);
        }
    }
}
