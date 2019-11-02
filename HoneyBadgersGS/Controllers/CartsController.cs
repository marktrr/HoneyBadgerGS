using System.Collections.Generic;
using HoneyBadgers._0.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private ICartLogic _cartLogic;

        public CartsController(ICartLogic cartLogic)
        {
            _cartLogic = cartLogic;
        }

        [HttpGet("getcart")]
        [Route("api/Cart")]
        public IEnumerable<Cart> GetCart()
        {
            return _cartLogic.GetAll();
        }

        //Creates new cart instance
        [HttpPost]
        [Route("api/Cart/Add")]
        public int Add(Cart cart)
        {
            return _cartLogic.Add(cart);
        }

        //Updates cart in record
        [HttpPut]
        [Route("api/Cart/Update")]
        public int Update(Cart cart)
        {
            return _cartLogic.Update(cart);
        }

        //Get Single Cart Details
        [HttpGet("getcart/{id}")]
        [Route("api/Cart/Details/{id}")]
        public Cart Details(int id)
        {
            return _cartLogic.Details(id);
        }

        //Delete Cart from records
        [HttpDelete]
        [Route("api/Cart/Delete")]
        public int Delete(int id)
        {
            return _cartLogic.Delete(id);
        }
    }
}
