using HoneyBadgers._0.Controllers;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using HoneyBadgerTest.Business_Logic;

namespace HoneyBadgerTest.Controller
{
    public class OrdersControllerTest
    {
        OrdersController _controller;
        TestOrder _service;

        public OrdersControllerTest()
        {
            _service = new TestOrder();
            _controller = new OrdersController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllOrders()
        {
            // Act
            var okResult = _controller.GetOrders();

            // Assert
            var items = Assert.IsType<List<Order>>(okResult);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_ExistingIDPassed_ReturnsRightItem()
        {
            // Arrange
            var testID = 12345;

            // Act
            var okResult = _controller.Details(testID);

            // Assert
            Assert.IsType<Order>(okResult);
            Assert.Equal(testID, okResult.OrderId);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedGetOneMoreItem()
        {
            // Arrange
            var testItem = new Order()
            {
                OrderId = 99999,
                CustomerInfo = "Nickki",
                ItemInfo = "Devil May Cry 5"
            };

            // Act
            var createdResponse = _controller.Add(testItem);
            var item = createdResponse;

            // Assert
            Assert.Equal(4, _service.GetAll().Count());
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingID = 12345;

            // Act
            var okResponse = _controller.Delete(existingID);

            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }
    }
}
