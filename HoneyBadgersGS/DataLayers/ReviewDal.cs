using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public class ReviewDal : IReviewDal
    {
        private HoneyBadgerDBContext _db;

        public ReviewDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Review> GetAll()
        {
            return _db.Review.ToList();
        }

        public int Add(Review review)
        {
            _db.Review.Add(review);
            _db.SaveChangesAsync();
            return 1;
        }

        public int Update(Review review)
        {
            throw new NotImplementedException();
        }

        public Review GetData(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
