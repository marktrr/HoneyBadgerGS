using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Controllers;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HoneyBadgerTest
{
	
	public class MockGameController 
	{
		GamesController _controller;
		IGameLogic _gameLogic;

		public MockGameController()
		{
			_gameLogic = new MockGameLogic();
			_controller = new GamesController(_gameLogic);
		}


		//get all the product , expect the list return to match.
		[Fact]
		public void GetGames_ReturnsOkResult()
		{
			//Act
			var okResult = _controller.GetAllGames();
			//Assert
			Assert.Equal(3, okResult.Count());
		}

		// sends a game id which does exist, expects both game ids to match.
		[Fact]
		public void GetAGameWithExistingId_ReturnGameWithCorrectId()
		{
			//Arrange
			var okResult = _controller.Details(1);
			int expected_Id = 1;
			//Act
			Assert.Equal( expected_Id, okResult.GameId);		
		}

		//Sends a game id which doesn't exist, expects a null instead of the  game object.
		[Fact]
		public void GetAGameWithNonExistingId_()
		{
			//Arrange
			var okResult = _controller.Details(5);
			Game ? expected = null;
			//Act
			Assert.Equal(expected, okResult);
		}
		//add
		[Fact]
		public void AddValidGame_ExpectOne()
		{

			Game newGame = new Game
			{

				GameId = 4,
				GameName = " randomGame",
				Publisher = "Activision",
				Developer = "Etranges Libellules",
				Genre = "Platformer",
				Platform = "All",
				GameDescription = "SOme new game",
				GameArtUrl = "https://www.giantbomb.com/images/1300-2136555",
				ReleaseDate = new DateTime(2008, 10, 21),
				Price = 50.54

			};

			int result = _controller.Add(newGame);
			Assert.Equal(1, result);

		}

		[Fact]
		public void UpdateValidGame_ExpectOne()
		{

			Game newGame = new Game
			{

				GameId = 1,
				GameName = " updatedGame",
				Publisher = "Activision",
				Developer = "Etranges Libellules",
				Genre = "Platformer",
				Platform = "All",
				GameDescription = "SOme new game",
				GameArtUrl = "https://www.giantbomb.com/images/1300-2136555",
				ReleaseDate = new DateTime(2008, 10, 21),
				Price = 50.54

			};
			int result = _controller.Update(newGame);
			Assert.Equal(0, result);
		}
		[Fact]
		public void DeleteGame_ExpectOne()
		{
			int id = 1;
			int result = _controller.Delete(id);
			Assert.Equal(1, result);
		}




	}
}
