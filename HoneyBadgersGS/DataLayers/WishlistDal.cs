using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.DataLayers
{
    public class WishlistDal : IWishlistDal
    {
        private HoneyBadgerDBContext _db;

        public WishlistDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Wishlist> GetAll()
        {
            return _db.Wishlist.ToList();
        }

        public int Add(Wishlist wishlist)
        {
            _db.Wishlist.Add(wishlist);
            _db.SaveChangesAsync();
            return 1;
        }

        public int Update(Wishlist wishlist)
        {
            _db.Wishlist.Update(wishlist);
            _db.SaveChangesAsync();
            return 1;
        }

        public Wishlist GetData(int id)
        {
            Wishlist wishlist = _db.Wishlist.Find(id);
            return wishlist;
        }

        public int Delete(int id)
        {
            Wishlist wishlist = _db.Wishlist.Find(id);
            _db.Wishlist.Remove(wishlist);
            _db.SaveChangesAsync();
            return 1;
        }
    }
}
