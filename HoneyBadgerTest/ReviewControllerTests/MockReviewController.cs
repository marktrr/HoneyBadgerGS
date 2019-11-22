using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Controllers;
using HoneyBadgers._0.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HoneyBadgerTest.ReviewControllerTests
{
	public class MockReviewController 
	{
		ReviewsController _controller;
		IReviewLogic _reviewLogic;

		public MockReviewController()
		{
			_reviewLogic = new MockReviewLogic();
			_controller = new ReviewsController(_reviewLogic);

		}

		//get all
		[Fact]
		public void GetAllReviews_ExpectThreeObject()
		{
			List<Review> result = (List<Review>) _controller.GetAllReviews();
			Assert.Equal(3, result.Count);	
		}
	
		//add review, valid
		[Fact]
		public void AddNewReviewValid_ExpectOne()
		{
			Review review = new Review();
			review.GameId = 3234;
			review.RatingValue = 3;
			review.ReviewInfo = "New Review";
			review.AccountId = "5081af63-b8dc-46ee-a9be-d7e18c98051c";

			int result = _controller.Add(review);
			Assert.Equal(1,result);
		}

		//add review, not valid
		[Fact]
		public void AddNewReviewNotValid_ExpectOne()
		{
			Review review = new Review();
			review.GameId = 3234;
			review.RatingValue = 3;
			review.ReviewInfo = "New Review";

			int result = _controller.Add(review);
			Assert.Equal(1, result);
		}

		//update review valid Item
		[Fact]
		public void UpdateReviewValid_ExpectOne()
		{
			Review review = new Review();
			review.GameId = 55;
			review.RatingValue = 3;
			review.ReviewInfo = "Updated Review";
			review.AccountId = "195c148e-d028-4e93-8c2c-724e7883d636";
			int result = _controller.Update(review);
			Assert.Equal(1, result);
		}
		//update revoew  not valid



	}
}
