using System;
using System.Collections.Generic;
using System.Text;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;

namespace HoneyBadgerTest.Business_Logic
{
    public class TestWishlist : IWishlistLogic
    {
        private readonly List<Wishlist> _wishlists;


        public TestWishlist()
        {
            _wishlists = new List<Wishlist>()
            {
                new Wishlist() {WishlistId = 12345, AccountId = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200", ItemInfo = "Botherland 3" },
                new Wishlist() {WishlistId = 45774, AccountId = "eu6mjdi5-17sd-3jcn3-a88a-11tgnfjs800", ItemInfo = "GTA 5" },
                new Wishlist() {WishlistId = 54357, AccountId = "h8jd99m3-77sf-9ksjn-bw67-28juf83m903", ItemInfo = "Uncle Mickey" }
            };
        }

        public int Add(Wishlist wishlist)
        {
            _wishlists.Add(wishlist);
            return 1;            
        }

        public int Delete(int id)
        {
            var existing = _wishlists.Find(a => a.WishlistId == id);
            _wishlists.Remove(existing);
            return 1;
        }

        public Wishlist Details(int id)
        {
            return _wishlists.Find(x => x.WishlistId == id);
        }

        public IEnumerable<Wishlist> GetAll()
        {
            return _wishlists;
        }

        public int Update(Wishlist wishlist)
        {
            throw new NotImplementedException();
        }
    }
}
