using System.Collections.Generic;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class CartLogic : ICartLogic
    {
        private ICartDal _cartDal;

        public CartLogic(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartDal.GetAll();
        }

        public int Add(Cart cart)
        {
            return _cartDal.Add(cart);
        }

        public int Update(Cart cart)
        {
            return _cartDal.Update(cart);
        }

        public Cart Details(int id)
        {
            return _cartDal.GetData(id);
        }

        public int Delete(int id)
        {
            return _cartDal.Delete(id);
        }
    }
}
