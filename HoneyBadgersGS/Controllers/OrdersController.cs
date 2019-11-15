using System.Collections.Generic;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderLogic _orderLogic;

        public OrdersController(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _orderLogic.GetAll();
        }

        //Creates new order instance
        [HttpPost("add/")]
        public int Add([FromBody] Order order)
        {
            return _orderLogic.Add(order);
        }

        //Updates order in record
        [HttpPut]
        public int Update(Order order)
        {
            return _orderLogic.Update(order);
        }

        //Get Single Order Details
        [HttpGet("{id}")]
        public Order Details(int id)
        {
            return _orderLogic.Details(id);
        }

        //Delete Order from records
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _orderLogic.Delete(id);
        }
    }
}
