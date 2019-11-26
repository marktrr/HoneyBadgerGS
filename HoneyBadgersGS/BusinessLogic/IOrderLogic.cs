using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface IOrderLogic
    {
        int Add(Order order);
        int Delete(int id);
        Order Details(int id);
        IEnumerable<Order> GetAll();
        int Update(Order order);
    }
}