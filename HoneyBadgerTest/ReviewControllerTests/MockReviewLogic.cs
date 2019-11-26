using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyBadgerTest.ReviewControllerTests
{
	class MockReviewLogic : IReviewLogic
	{

		private readonly List<Review> _ReviewList;

		public List<Review> ReviewCollection()
		{
			List<Review> reviewList = new List<Review>();
			reviewList.Add(new Review {GameId=800, RatingValue=1,ReviewInfo="this is a review", AccountId= "49bd380e-6e6d-439f-9ed9-2fe365ac911c" });
			reviewList.Add(new Review {GameId=300, RatingValue=3,ReviewInfo="game is sucks",	AccountId= "61c5bcb0-7550-42e4-8945-dacbb04c3173" });
			reviewList.Add(new Review {GameId=200, RatingValue=5,ReviewInfo="game is great",	AccountId= "195c148e-d028-4e93-8c2c-724e7883d636" });
			return reviewList;
		}

		public MockReviewLogic()
		{
			_ReviewList = ReviewCollection();
		}


		public int Add(Review review)
		{
			_ReviewList.Add(review);
			return 1;
		}

		public int Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Review Details(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Review> GetAll()
		{
			return _ReviewList;
		}

		public int Update(Review review)
		{
			int found_index = _ReviewList.FindIndex(x => x.AccountId == review.AccountId);
			_ReviewList[found_index] = review;
			return 1;
		}
	}
}
