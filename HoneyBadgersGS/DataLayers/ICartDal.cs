using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public interface ICartDal
    {
        IEnumerable<Cart> GetAll();
        int Add(Cart cart);
        int Update(Cart cart);
        Cart GetData(int id);
        int Delete(int id);
    }
}
