using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Controllers;
using HoneyBadgers._0.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HoneyBadgerTest.ProfileControllerTests
{
	public class MockProfileController
	{
		ProfilesController _controller;
		IProfileLogic _profileLogic;

		public MockProfileController()
		{
			_profileLogic = new MockProfileLogic();
			_controller = new ProfilesController(_profileLogic);
		}

		//get all
		[Fact]
		public void GetAllProfiles_ExpectListToContainThreeObjects()
		{
			List<Profile> result = (List<Profile>) _controller.GetAllProfiles();
			Assert.Equal(3, result.Count);
		}
		//get a profile with a correct object id.
		[Fact]
		public void GetAProfileWithExistingId_ExpectAObjectWithCOrrectIDAndName()
		{
			string expected_id = "763adcfc-2abc-493a-b35d-813d95905906";
			string expected_name = "Jimmy";
			 Profile ? result = _controller.Details(expected_id);

			Assert.Equal(expected_id, result.ProfileId);
			Assert.True(expected_name == result.ActualName);
		}

		//get a profile with a incorrect object id
		[Fact]
		public void GetNonExistingProfile_ExpectNull()
		{
			Profile ? result = _controller.Details("Something");
			Assert.Null(result);
		}

		//check that deletion functions correctly.
		[Fact]
		public void DeleteAnExistingUser_ExpectDigitOne()
		{
			string id = "763adcfc-2abc-493a-b35d-813d95905906";
			int result = _controller.Delete(id);
			Assert.Equal(1, result);
		}
		//check  deletion failure
		[Fact]
		public void DeleteAnNonExistingUser_ExpectDigitZero()
		{
			string id = "something";
			int result = _controller.Delete(id);
			Assert.Equal(1, result);
		}

		//Update
		[Fact]
		public void updateAnExistingUser_ExpectTrue()
		{
			Profile profile = new Profile();
			profile.ActualName = "Jimmy";

			//change the display name
			profile.DisplayName = "VImJim";
			profile.Dob = new DateTime(1987, 09, 20);
			profile.Email = "JimmyTheDragon@gmail.com";
			profile.Gender = "Male";
			profile.ProfileId = "763adcfc-2abc-493a-b35d-813d95905906";
			profile.ProfileImage = null;
			profile.Promotion = true;
			profile.UserAddress = "600 Golden Acre Valley";

			bool result = _controller.Update(profile);
			Assert.True(result);
		}

		//Update
		[Fact]
		public void updateNonExistingUser_ExpectFalse()
		{
			Profile profile = new Profile();
			profile.ActualName = "5";
			//change the display name
			profile.DisplayName = "VImJim";
			profile.Dob = new DateTime(1987, 09, 20);
			profile.Email = "JimmyTheDragon@gmail.com";
			profile.Gender = "Male";
			profile.ProfileId = "76";
			profile.ProfileImage = null;
			profile.Promotion = true;
			profile.UserAddress = "600 Golden Acre Valley";

			bool result = _controller.Update(profile);
			Assert.False(result);
		}

		//Add
		//Valid Object.

		[Fact]
		public void AddValidUser_True()
		{
			Profile profile = new Profile();
			profile.ActualName = "5ammy";
			//change the display name
			profile.DisplayName = "VImJim";
			profile.Dob = new DateTime(1987, 09, 20);
			profile.Email = "JimmyTheDragon@gmail.com";
			profile.Gender = "Male";
			profile.ProfileId = "417ebb5e-b605-409c-ae1a-9e346506b665";
			profile.ProfileImage = null;
			profile.Promotion = true;
			profile.UserAddress = "600 Golden Acre Valley";

			bool result = _controller.Add(profile);
			Assert.True(result);
		}

		[Fact]
		public void AddUserMissingValue_True()
		{
			Profile profile = new Profile();
			profile.ActualName = "5ammy";
			//change the display name
			profile.DisplayName = "VImJim";
			profile.Dob = new DateTime(1987, 09, 20);
			profile.Email = "JimmyTheDragon@gmail.com";
			profile.Gender = "Male";
			profile.ProfileImage = null;
			profile.Promotion = true;
			profile.UserAddress = "600 Golden Acre Valley";

			bool result = _controller.Add(profile);
			Assert.True(result);
		}


	}
}
