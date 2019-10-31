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
        [HttpGet("getwishlist")]
        [Route("api/Wishlist")]
        public IEnumerable<Wishlist> GetWishlists()
        {
            return _wishlistLogic.GetAll();
        }

        //Creates new cart instance
        [HttpPost]
        [Route("api/Wishlist/Add")]
        public int Add(Wishlist wishlist)
        {
            return _wishlistLogic.Add(wishlist);
        }

        //Updates cart in record
        [HttpPut]
        [Route("api/Wishlist/Update")]
        public int Update(Wishlist wishlist)
        {
            return _wishlistLogic.Update(wishlist);
        }

        //Get Single Cart Details
        [HttpGet("getcart/{id}")]
        [Route("api/Wishlist/Details/{id}")]
        public Wishlist Details(int id)
        {
            return _wishlistLogic.Details(id);
        }

        //Delete Cart from records
        [HttpDelete]
        [Route("api/Wishlist/Delete")]
        public int Delete(int id)
        {
            return _wishlistLogic.Delete(id);
        }
    }
}
