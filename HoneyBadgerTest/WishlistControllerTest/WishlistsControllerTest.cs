using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoneyBadgers._0.Controllers;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using HoneyBadgerTest.Business_Logic;


namespace HoneyBadgerTest.Controller
{
    public class WishlistsControllerTest
    {
        WishlistsController _controller;
        TestWishlist _service;

        public WishlistsControllerTest()
        {
            _service = new TestWishlist();
            _controller = new WishlistsController(_service);
        }


        [Fact]
        public void GetById_GivenWishlistID_ReturnsMatchResult()
        {
            // Act
            var okResult = _controller.Details(12345);

            //Arrange
            int expectedID = 12345;

            // Assert
            Assert.Equal(expectedID, okResult.WishlistId);
        }

        [Fact]
        public void AddItem_GivenItem_ReturnItemAddID()
        {
            var okResult = _controller.Details(56735);

            var expected = _controller.Details(12345);
            Assert.NotEqual(expected, okResult);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Wishlist()
            {
                WishlistId = 45678,
                AccountId = "b36ddbb8-3252-4e61-ac6d-cae4386fa4",
                ItemInfo = "Mega Man"
            };

            // Act
            int createdResponse = _controller.Add(testItem);

            // Assert
            Assert.Equal(1, createdResponse);
        }

        [Fact]
        public void Remove_ExistingIDPassed_RemovesOneItem()
        {
            // Arrange
            var existingID = 12345;

            // Act
            var okResponse = _controller.Delete(existingID);

            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }

        [Fact]
        public void Remove_ExistingIDPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = 12345;

            // Act
            var okResponse = _controller.Delete(existingGuid);

            // Assert
            Assert.IsType<int>(okResponse);
        }
    }

}
