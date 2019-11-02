using System;
using System.Collections.Generic;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class WishlistLogic : IWishlistLogic
    {
        private IWishlistDal _wishlistDal;

        public WishlistLogic(IWishlistDal wishlistDal)
        {
            _wishlistDal = wishlistDal;
        }

        public IEnumerable<Wishlist> GetAll()
        {
            return _wishlistDal.GetAll();
        }

        public int Add(Wishlist wishlist)
        {
            return _wishlistDal.Add(wishlist);
        }

        public int Update(Wishlist wishlist)
        {
            return _wishlistDal.Update(wishlist);
        }

        public Wishlist Details(int id)
        {
            return _wishlistDal.GetData(id);
        }

        public int Delete(int id)
        {
            return _wishlistDal.Delete(id);
        }
    }
}
