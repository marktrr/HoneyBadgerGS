using System.Collections.Generic;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderDal _orderDal;

        public OrderLogic(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public int Add(Order order)
        {
            return _orderDal.Add(order);
        }

        public int Update(Order order)
        {
            return _orderDal.Update(order);
        }

        public Order Details(int id)
        {
            return _orderDal.GetData(id);
        }
        public int Delete(int id)
        {
            return _orderDal.Delete(id);
        }
    }
}