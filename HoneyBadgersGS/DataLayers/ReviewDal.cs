using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;
using Microsoft.EntityFrameworkCore;

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
            _db.Review.Update(review);
            _db.SaveChangesAsync();
            return 1;
        }

        public Review GetData(int id)
        {
            Review review = _db.Review.Find(id);
            return review;
        }

        public int Delete(int id)
        {
            Review review = _db.Review.Find(id);
            _db.Review.Remove(review);
            _db.SaveChangesAsync();
            return 1;
        }
    }
}
