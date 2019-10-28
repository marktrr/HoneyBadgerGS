using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface ICartLogic
    {
        IEnumerable<Cart> GetAll();
        int Add(Cart cart);
        int Update(Cart cart);
        Cart Details(int id);
        int Delete(int id);
    }
}
