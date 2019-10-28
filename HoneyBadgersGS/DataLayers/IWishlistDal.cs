using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public interface IWishlistDal
    {
        IEnumerable<Wishlist> GetAll();
        int Add(Wishlist wishlist);
        int Update(Wishlist wishlist);
        Wishlist GetData(int id);
        int Delete(int id);
    }
}
