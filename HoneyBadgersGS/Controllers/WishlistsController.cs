using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private IWishlistLogic _wishlistLogic;

        public WishlistsController(IWishlistLogic wishlistLogic)
        {
            _wishlistLogic = wishlistLogic;
        }

        [HttpGet]
        public IEnumerable<Wishlist> GetWishlists()
        {
            return _wishlistLogic.GetAll();
        }

        //Creates new cart instance
        [HttpPost("add/")]
        public int Add([FromBody] Wishlist wishlist)
        {
            return _wishlistLogic.Add(wishlist);
        }

        //Updates cart in record
        [HttpPut]
        public int Update(Wishlist wishlist)
        {
            return _wishlistLogic.Update(wishlist);
        }

        //Get Single Cart Details
        [HttpGet("{id}")]
        public Wishlist Details(int id)
        {
            return _wishlistLogic.Details(id);
        }

        //Delete Cart from records
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _wishlistLogic.Delete(id);
        }
    }
}
