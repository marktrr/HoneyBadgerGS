using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public class CartDal : ICartDal
    {
        private HoneyBadgerDBContext _db;

        public CartDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _db.Cart.ToList();
        }

        public int Add(Cart cart)
        {
            _db.Cart.Add(cart);
            _db.SaveChangesAsync();
            return 1;
        }

        public int Update(Cart cart)
        {
            _db.Cart.Update(cart);
            _db.SaveChangesAsync();
            return 1;
        }

        public Cart GetData(int id)
        {
            Cart cart = _db.Cart.Find(id);
            return cart;
        }

        public int Delete(int id)
        {
            Cart cart = _db.Cart.Find(id);
            _db.Cart.Remove(cart);
            _db.SaveChangesAsync();
            return 1;
        }
    }
}
