using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public class ReviewsDal
    {
        private readonly HoneyBadgerDBContext _db;

        public ReviewsDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Review> GetAll()
        {
            return _db.Review.ToList();
        }
    }
}