using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.DataLayers
{
    public class TransactionDal : ICartDal
    {
        private HoneyBadgerDBContext _db;

        public TransactionDal(HoneyBadgerDBContext db)
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
            _db.Entry(cart).State = EntityState.Modified;
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
