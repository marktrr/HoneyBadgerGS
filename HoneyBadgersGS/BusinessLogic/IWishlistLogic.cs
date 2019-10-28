using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface IWishlistLogic
    {
        IEnumerable<Wishlist> GetAll();
        int Add(Wishlist wishlist);
        int Update(Wishlist wishlist);
        Wishlist Details(int id);
        int Delete(int id);
    }
}
