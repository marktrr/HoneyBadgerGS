using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class ReviewLogic : IReviewLogic
    {
        private IReviewDal _reviewDal;

        public ReviewLogic(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public IEnumerable<Review> GetAll()
        {
            return _reviewDal.GetAll();
        }

        public int Add(Review review)
        {
            return _reviewDal.Add(review);
        }

        public int Update(Review review)
        {
            return _reviewDal.Update(review);
        }

        public Review Details(int id)
        {
            return _reviewDal.GetData(id);
        }

        public int Delete(int id)
        {
            return _reviewDal.Delete(id);
        }
    }
}
