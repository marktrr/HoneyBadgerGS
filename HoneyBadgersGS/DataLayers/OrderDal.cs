using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.DataLayers
{
    public class OrderDal : IOrderDal
    {
        private HoneyBadgerDBContext _db;

        public OrderDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Order.ToList();
        }
        public int Add(Order order)
        {
            _db.Order.Add(order);
            _db.SaveChangesAsync();
            return 1;
        }

        public int Update(Order order)
        {
            _db.Order.Update(order);
            _db.SaveChangesAsync();
            return 1;
        }

        public Order GetData(int id)
        {
            Order order = _db.Order.Find(id);
            return order;
        }

        public int Delete(int id)
        {
            Order order = _db.Order.Find(id);
            _db.Order.Remove(order);
            _db.SaveChangesAsync();
            return 1;
        }
        //TODO: ADD rest of functions based on https://dzone.com/articles/aspnet-core-crud-with-reactjs-and-entity-framework
    }
}
