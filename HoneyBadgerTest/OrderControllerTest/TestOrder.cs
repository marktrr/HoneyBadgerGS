using System;
using System.Collections.Generic;
using System.Text;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;

namespace HoneyBadgerTest.Business_Logic
{
    public class TestOrder : IOrderLogic
    {
        private readonly List<Order> _orders;

        public TestOrder()
        {
            _orders = new List<Order>()
            {
                new Order() {OrderId = 12345, CustomerInfo = "Mark", ItemInfo = "GTA 5"},
                new Order() {OrderId = 47563, CustomerInfo = "Kevin", ItemInfo = "Botherland 3"},
                new Order() {OrderId = 38563, CustomerInfo = "Leo", ItemInfo = "Mega Man"}
            };

        }

        public int Add(Order order)
        {
            _orders.Add(order);
            return 1;
        }

        public int Delete(int id)
        {
            var existing = _orders.Find(a => a.OrderId == id);
            _orders.Remove(existing);
            return 1;
        }

        public Order Details(int id)
        {
            return _orders.Find(x => x.OrderId == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public int Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
